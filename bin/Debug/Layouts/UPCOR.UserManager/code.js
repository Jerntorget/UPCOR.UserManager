$(document).ready(function () {
    /*
    * Initialize data
    **/
    var m_regex = /[#,+"\/<>;\n\r=]+/g; // regex for AD distinguished name
    var m_store = $('span.um-store');
    var m_countyName = m_store.attr('county_name');
    var m_webUrl = m_store.attr('weburl');
    var m_canSave = false;
    var m_user = {};

    var m_nums = "0123456789";
    var m_chars = "abcdefghijklmnopqrstuvwxyz";

    if (m_countyName == "") {
        $('div.um-panel').css('display', 'none')
        .parent().append("<h2>Viktiga Inställningar saknas, välj redigera webbdel.</h2>");
    }

    $('button.btn-save').prop('disabled', true).attr('update', 'false');

    /*
    * Functions
    **/
    function getf(name) {
        return $('input.um-{0}'.replace("{0}", name));
    }

    function error(message) {
        $('span.um-error').text(message);
    }

    function validate(input, errText) {
        if ($.trim(input.val()).length != 0) {
            m_canSave = true;
            error("");
            return true;
        } else {
            m_canSave = false;
            error(errText);
            return false;
        }
    }

    /*
    * Main service to call umservice.asmx
    * */
    function fnUmService(method, data, success, error) {
        data["webUrl"] = encodeURIComponent(m_webUrl);
        data["countyName"] = encodeURIComponent(m_countyName);
        data["orgName"] = data.orgName == null ? "" : encodeURIComponent(data.orgName.replace(m_regex, ""));
        $.ajax({
            type: "POST",
            url: "/_layouts/15/upcor.usermanager/umservice.asmx/" + method,
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            dataType: "json",
            success: function (data, status) {
                if (typeof success === 'function')
                    success(data.d, status);
            },
            error: function (xmlRequest) {
                if (typeof error === 'function')
                    error(xmlRequest);
            }
        });
    }

    function fnSendMail(to, subject, body, success, error) {
        fnUmService("SendMail", {
            "to": to,
            "subject": subject,
            "body": body
        },
        success,
        error);
    }

    function fnSearch(filter, orgName, success, error) {
        fnUmService("Search", {
            "filter": filter,
            "orgName": orgName
        },
        success,
        error);
    }

    function fnUserExist(userName, success, error) {
        fnUmService("Exist", {
            "userName": userName
        },
        success,
        error);
    }

    function fnUserGroups(userName, success, error) {
        fnUmService("Groups", {
            "userName": userName
        },
        success,
        error);
    }

    /*
    * EVENT: Save click
    **/
    $('button.um-btnsave').click(function (e) {
        e.preventDefault();
        guiShowLoader();
        /* validate fields */
        if (!m_canSave) {
            error("Kan inte spara...");
            return false;
        }
        if (!validate(getf("givenname"), "Kan inte spara, förnamn saknas.")) return false;
        if (!validate(getf("surname"), "Kan inte spara, efternamn saknas.")) return false;
        if (!validate(getf("email"), "Kan inte spara, mailadress saknas.")) return false;

        var b = $(this);
        /* validate passwords */
        var pw1 = getf("password1").val();
        var pw2 = getf("password2").val();

        if (pw1 != pw2) {
            error("Lösenordsverifieringen stämmer inte.");
            return false;
        }

        if (pw1.length != 0 && pw1.length < 6) {
            error("Lösenordet måste vara minst 6 tecken långt");
            return false;
        }

        /* populate data */
        data = {
            "givenName": encodeURIComponent($.trim(getf("givenname").val())),
            "surName": encodeURIComponent($.trim(getf("surname").val())),
            "password": encodeURIComponent(pw2),
            "userName": encodeURIComponent($.trim(getf("username").val())),
            "email": encodeURIComponent($.trim(getf("email").val())),
        };

        var opt = $('select.um-organization option:selected');
        if (opt.val() != "0") {
            data.orgName = opt.text();
        }

        if (b.attr('update') == 'true') {
            /* update user */
            var addGroupIds = [];
            var delGroupIds = [];
            $('.um-sitegroups input[type="checkbox"]').each(function () {
                var o = $(this);
                if (o.prop('checked')) {
                    addGroupIds.push(o.val());
                } else {
                    if (o.attr('ingroup') == "true")
                        delGroupIds.push(o.val());
                }
            });
            data.addGroupIds = addGroupIds;
            data.delGroupIds = delGroupIds;
            fnUmService("Update", data, function (res) {
                guiShowMessage("Användaren: " + $.trim(getf("givenname").val()) + " " + $.trim(getf("surname").val()) + " updaterad.");
                fnSendMail($.trim(getf("sendto").val()),
                    encodeURIComponent("Din användare på skolan.it har blivit uppdaterad"),
                    encodeURIComponent("Hej " +
                                        $.trim(getf("givenname").val()) + " " + $.trim(getf("surname").val()) + ",\r\n\r\n" +
                                        "Din användare har blivit uppdaterad.\r\n" +
                                        "Användaruppgifter:\r\n" +
                                        "Användarnamn: \"SAFE4\\" + $.trim(getf("username").val()) + "\"" +
                                        "\r\nLösenord: \"" + pw2 + "\"." +
                                        "\r\n\r\nMed vänliga hälsningar\r\nwww.tillsynen.se <support@tillsynen.se>"),
                    function (data) {
                        guiShowMessage("Meddelande skickat till " + to + ".");
                    },
                    function (err) {
                        guiHideLoader();
                    });
                guiClear();
            });
        } else {
            /* new user */
            var groupIds = [];
            $('.um-sitegroups input[type="checkbox"]:checked').each(function () {
                var o = $(this);
                groupIds.push(o.val());
            });
            data.groupIds = groupIds;
            fnUmService("Create", data, function (res) {
                var to = $.trim(getf("sendto").val());
                guiShowMessage("Användaren: " + $.trim(getf("givenname").val()) + " " + $.trim(getf("surname").val()) + " sparad.");
                if (to.length > 0) {
                    fnSendMail(to,
                        encodeURIComponent("En användare har skapats på skolan.it"),
                        encodeURIComponent("Hej " +
                                            $.trim(getf("givenname").val()) + " " + $.trim(getf("surname").val()) + ",\r\n\r\n" +
                                            "Välkommen till tillsynen.se!\r\n" +
                                            "Tillsynen.se är en portal för dig som säljer tobak eller folköl.\r\n" +
                                            "Portalen tillhandahålls som en service från din kommun.\r\n\r\n" +
                                            "Via tillsynen.se får du tillgång till ditt företags information\r\n" +
                                            "om försäljning av tobak och folköl.\r\n\r\n" +
                                            "Användaruppgifter:\r\n" +
                                            "Användarnamn: \"SAFE4\\" + $.trim(getf("username").val()) + "\"" +
                                            "\r\nLösenord: \"" + pw2 + "\".\r\n\r\n" +
                                            "Surfa till http://www.tillsynen.se för att logga in." +
                                            "\r\n\r\nMed vänliga hälsningar\r\n www.tillsynen.se <support@tillsynen.se>"),
                        function (data) {
                            guiShowMessage("Meddelande skickat till " + to + ".");
                        },
                        function (err) {
                            guiHideLoader();
                        });
                }
                guiHideLoader();
                guiClear();
            });
        }
        return false;
    });

    /*
    * EVENT: Cancel click
    **/
    $('button.um-btncancel').click(function (e) {
        guiClear();
        e.preventDefault();
        return false;
    });

    /*
    * EVENT: Select
    **/
    $('#idBtnAuto').click(function (e) {
        var opt = $('select.um-organization option:selected');
        var name = opt.val().replace("-", "");
        getf("givenname").val(name);
        getf("surname").val(opt.text().replace(m_regex, ""));
        getf("username").val(name);
        getf("email").val(name + "@safe4.se");
        var password = "";
        for (var i = 0; i < 3; i++) {
            password += m_chars.substr(Math.floor(Math.random() * m_chars.length), 1);
        }
        for (var i = 0; i < 3; i++) {
            password += m_nums.substr(Math.floor(Math.random() * m_nums.length), 1);
        }
        getf("password1").val(password);
        getf("password2").val(password);

        $('label:contains("' + opt.val() + '")').prev().prop('checked', true);
        $('label:contains("Besökare på ' + m_countyName + '")').prev().prop('checked', true);
        m_canSave = true;
        e.preventDefault();
        return false;
    });

    $('select.um-organization').change(function () {
        guiClear();
        var orgName = "";
        var opt = $('select.um-organization option:selected');
        if (opt.val() != "0") {
            orgName = opt.text();
        }
        fnSearch("sAMAccountName=*", orgName,
             function (data, success) {
                 guiDisplayUsers(data);
             });
    });

    function guiShowMessage(msg) {
        var div = $('<div class="um-message">').text(msg);
        $('div.um-notif').prepend(div);
        div.delay(2000).fadeOut('slow', function () {
            div.remove();
        });
    }

    function guiShowLoader() {
        //    "/_layouts/15/upcor.usermanager/style.css"
        var div = $('<div class="um-loader">').append($('<img>').attr('src', '/_layouts/15/upcor.usermanager/gif-load.gif'));
        $('div.um-notif').prepend(div);
    }

    function guiHideLoader() {
        $('div.um-loader').remove();
    }

    function guiClear() {
        getf("givenname").val("");
        getf("surname").val("");
        getf("username").val("").prop('disabled', false);
        getf("email").val("");
        getf("password1").val("");
        getf("password2").val("");
        getf("sendto").val("");
        $('div.um-sitegroups input[type="checkbox"]').prop('checked', false);
        $('button.um-btnsave').attr('update', 'false');
        $('.um-sitegroups input[type="checkbox"]').prop('checked', false);
        error("");
        $('div.um-search-result div').empty();
        guiHideLoader();
    };

    /*
    * EVENT: Search for givenName
    **/
    $('input.um-givenname, input.um-surname, input.um-email, input.um-username').keypress(function () {
        var searchOpt = "";
        var o = $(this);
        if (o.hasClass('um-givenname'))
            searchOpt = "givenName";
        if (o.hasClass('um-surname'))
            searchOpt = "sn";
        if (o.hasClass('um-email'))
            searchOpt = "mail";
        if (o.hasClass('um-username'))
            searchOpt = "sAMAccountName";

        fnSearch(searchOpt + "=" + encodeURIComponent(o.val()) + "*",
            function (data, success) {
                guiDisplayUsers(data);
            });
    });

    /*
    * EVENT: email
    **/
    $('input.um-email').blur(function () {
        $('input.um-sendto').val($(this).val());
    });

    /*
    * EVENT: Check if username exist
    **/
    $('input.um-username').blur(function () {
        m_canSave = false;
        var input = $(this);

        fnUserExist($.trim(input.val()), function (rd) {
            if (rd.boolVal) {
                m_canSave = false;
                $('button.um-btnsave').prop('disabled', true);
                error("Det finns redan en användare med det här användarnamnet.");
                input.css({
                    "color": "red"
                });
            } else {
                m_canSave = true;
                $('button.um-btnsave').prop('disabled', false);
                error("");
                input.css({
                    "color": "black"
                });
            }
        });
    });

    /*
    * GUI: Gui functions
    **/
    function guiDisplayUsers(rd) {
        var template = '<span class="um-col-name"=>{0}</span><span class="um-col-mail>{1}</span>';
        var div = $('div.um-search-result div').empty();
        m_users = rd.dicts;
        var users = [];
        var user = {};
        for (var i = 0; i < m_users.length; i++) {
            var u = m_users[i];
            var key = u["Key"];
            var val = u["Value"];
            user[key] = val;
            if (key == "distinguishedName") {
                users.push(user);
                user = {};
            }

        }
        for (var i = 0; i < users.length; i++) {
            var u = users[i];
            div.append(
                $('<a href="#" class="um-user-item"></a>')
                .click(function () {
                    var a = $(this);
                    guiClear();
                    getf("givenname").val(a.attr("givenName"));
                    getf("surname").val(a.attr("sn"));
                    getf("username").val(a.attr("sAMAccountName")).prop('disabled', true);
                    getf("email").val(a.attr("mail"));
                    $('button.um-btnsave').attr('update', 'true');
                    fnUserGroups(a.attr("sAMAccountName"), guiSetGroups);
                    m_canSave = true;
                })
                .attr("uid", i)
                .attr("givenName", u["givenName"])
                .attr("sn", u["sn"])
                .attr("sAMAccountName", u["sAMAccountName"])
                .attr("mail", u["mail"])
                .html(template.replace("{0}", u["name"])
                .replace("{1}", !u["mail"] ? "" : "<" + u["mail"] + ">")));
        }
    }

    function guiSetGroups(data) {
        /* new user, don't exist in sharepoint */
        if (data.ints.length == 0) {
            if (data.errs[0].length > 0) {
                $('button.btn-save').attr('update', 'false');
            } else {
                $('button.btn-save').attr('update', 'true');
            }
        }
        for (var i = 0; i < data.ints.length; i++) {
            $('.um-sitegroups input[type="checkbox"][value="{id}"]'.replace("{id}", data.ints[i])).prop('checked', true).attr('ingroup', 'true');
        }
    }
});