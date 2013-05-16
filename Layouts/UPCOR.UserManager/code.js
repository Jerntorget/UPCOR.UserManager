$(document).ready(function () {
    /*
    * Initialize data
    **/
    var m_store = $('span.um-store');
    var m_countyName = m_store.attr('county_name');
    var m_webUrl = m_store.attr('weburl');
    var m_canSave = false;
    var m_user = {};

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
        data["orgName"] = data.orgName == null ? "" : encodeURIComponent(data.orgName);
        $.ajax({
            type: "POST",
            url: "/_layouts/15/upcor.usermanager/umservice.asmx/" + method,
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            dataType: "json",
            success: function (data, status) {
                console.log(data);
                console.log(status);
                if (typeof success === 'function')
                    success(data.d, status);
            },
            error: function (xmlRequest) {
                console.log(xmlRequest);
                if (typeof error === 'function')
                    error(xmlRequest);
            }
        });
    }

    function fnSearch(filter, success, error) {
        fnUmService("Search", {
            "filter": filter
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
            "sendTo": encodeURIComponent($.trim(getf("sendto").val()))
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
                    if(o.attr('ingroup') == "true")
                        delGroupIds.push(o.val());
                }
            });
            data.addGroupIds = addGroupIds;
            data.delGroupIds = delGroupIds;
            fnUmService("Update", data, function (res) {
                guiShowMessage("Användaren: " + data.givenName + " " + data.surName + " updaterad.");
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
                guiShowMessage("Användaren: " + data.givenName + " " + data.surName + " skapad.");
                guiClear();
            });
        }
        console.log(data);

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

    function guiShowMessage(msg) {
        var div = $('div class').css({
            "position": "relative",
            "padding": "10px",
            "border": "1px solid #444",
            "background-color": "ccc"
        }).text(msg);
        $('div.um-panel').append(div);
        div.delay(1000).fadeOut('slow', function () {
            div.remove();
        });
    }

    function guiClear() {
        getf("givenname").val("");
        getf("surname").val("");
        getf("username").val("").prop('disabled', false);
        getf("email").val("");
        getf("password1").val("");
        getf("password2").val("");
        $('div.um-sitegroups input[type="checkbox"]').prop('checked', false);
        $('button.um-btnsave').attr('update', 'false');
        $('.um-sitegroups input[type="checkbox"]').prop('checked', false);
        error("");
        $('div.um-search-result div').empty();
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
        console.log("rd", rd);
        var template = '<span class="um-col-name"=>{0}</span><span class="um-col-mail>{1}</span><span class="um-col-path">{2}</span>';
        var div = $('div.um-search-result div').empty();
        m_users = rd.dicts;
        for (var i = 0; i < m_users.length; i++) {
            div.append(
                $('<a href="#" class="um-user-item"></a>')
                .click(function () {
                    var a = $(this);
                    var u = m_users[a.attr("uid")];
                    guiClear();
                    getf("givenname").val(u["givenName"]);
                    getf("surname").val(u["sn"]);
                    getf("username").val(u["sAMAccountName"]).prop('disabled', true);
                    getf("email").val(u["mail"]);
                    $('button.um-btnsave').attr('update', 'true');
                    fnUserGroups(u["sAMAccountName"], guiSetGroups);
                    m_canSave = true;
                })
                .attr("uid", i)
                .html(template.replace("{0}", m_users[i]["name"])
                .replace("{1}", m_users[i]["mail"].length == 0 ? "" : "<" + m_users[i]["mail"] + ">")
                .replace("{2}", "Sökväg: " + m_users[i]["distinguishedName"]
                                    .replace(",OU=Kommuner,OU=Upcor,DC=safe4,DC=se", "")
                                    .replace(/[,]?[A-Z]+=/g, "/"))));
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
            console.log("value: " + data.ints[i]);
            $('.um-sitegroups input[type="checkbox"][value="{id}"]'.replace("{id}", data.ints[i])).prop('checked', true).attr('ingroup', 'true');
        }
    }
});