$(document).ready(function () {
    /*
    * Initialize data
    **/
    var m_store = $('span.um-store');
    var m_countyName = m_store.attr('county_name');
    var m_webUrl = m_store.attr('weburl');
    var m_users = null;
    var m_canSave = false;

    if (m_countyName == "") {
        $('div.um-panel').css('display', 'none')
        .parent().append("<h2>Viktiga Inställningar saknas, välj redigera webbdel.</h2>");
    }

    $('button.btn-save').prop('disabled', true);

    /*
    * Functions
    **/
    function fnUmService(method, data, success, error) {
        data["countyName"] = m_countyName;
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
                    success(data, status);
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
        fnUmService("UserExist", {
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
        return false;
    });

    /*
    * EVENT: Cancel click
    **/
    $('button.um-btncancel').click(function (e) {
        $('input.um-givenname').val("");
        $('input.um-surname').val("");
        $('input.um-username').val("").prop('disabled', false);
        $('input.um-email').val("");
        $('div.um-sitegroups input[type="checkbox"]').prop('checked', false);
        e.preventDefault();
        return false;
    });

    /*
    * EVENT: Search for givenName
    **/
    $('input.um-givenname').keypress(function () {
        fnSearch("givenName=" + encodeURIComponent($(this).val()) + "*",
            function (data, success) {
                guiDisplayUsers(data.d);
            });
    });

    /*
    * EVENT: Check if username exist
    **/
    $('input.um-username').blur(function () {
        m_canSave = false;
        var input = $(this);
        fnUserExist(input.val(), function (data) {            
            if (data.d) {
                m_canSave = false;
                $('button.um-btnsave').prop('disabled', true);
                $('span.um-error').text("Det finns redan en användare med det här användarnamnet.");
                input.css({
                    "color": "red"
                });
            } else {
                m_canSave = true;
                $('button.um-btnsave').prop('disabled', false);
                $('span.um-error').text("");
                input.css({
                    "color": "black"
                });
            }
        });
    });

    /*
    * GUI: Gui functions
    **/
    function guiDisplayUsers(users) {
        var template = '<span class="um-col-name"=>{0}</span><span class="um-col-mail>{1}</span><span class="um-col-path">{2}</span>';
        var div = $('div.um-search-result div').empty();
        m_users = users;
        for (var i = 0; i < users.length; i++) {
            div.append(
                $('<a href="#" class="um-user-item"></a>')
                .click(function () {
                    var a = $(this);
                    var u = m_users[a.attr("uid")];
                    $('input.um-givenname').val(u["givenName"]);
                    $('input.um-surname').val(u["sn"]);
                    $('input.um-username').val(u["sAMAccountName"]).prop('disabled', true);
                    $('input.um-email').val(u["mail"]);
                })
                .attr("uid", i)
                .html(template.replace("{0}", users[i]["name"])
                .replace("{1}", users[i]["mail"].length == 0 ? "" : "<" + users[i]["mail"] + ">")
                .replace("{2}", "Sökväg: " + users[i]["distinguishedName"]
                                    .replace(",OU=Kommuner,OU=Upcor,DC=safe4,DC=se", "")
                                    .replace(/[,]?[A-Z]+=/g, "/"))));
        }
    }
});