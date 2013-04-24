$(document).ready(function () {
    var store = $('span.um-store');
    var countyName = store.attr('county_name');
    var webUrl = store.attr('weburl');

    if (countyName == "") {
        $('div.um-panel').css('display', 'none')
        .parent().append("<h2>Viktiga Inställningar saknas, välj redigera webbdel.</h2>");
    } else {
        fnUserExist("jondof", countyName);
    }

    function fnUmService(method, data, success, error) {
        data["countyName"] = countyName;
        $.ajax({
            type: "POST",
            url: "/_layouts/15/upcor.usermanager/umservice.asmx/" + method,
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            dataType: "json",
            success: function (data, status) {
                //console.log(data);
                //console.log(status);
                if (typeof success === 'function')
                    success(data, status);
            },
            error: function (xmlRequest) {
                //console.log(xmlRequest);
                if (typeof error === 'function')
                    error(xmlRequest);
            }
        });
    }

    function fnSearch(properties, filter, success, error) {
        fnUmService("Search", {
            "properties": properties,
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
    * Check if username exist
    **/
    $('input.um-username').blur(function () {
        fnUserExist($(this).val(), countyName, function (data) {
            console.log(data);
        });
        /*
        $.post("/_layouts", { name: "John", time: "2pm" })
        .done(function (data) {
            alert("Data Loaded: " + data);
        }); */
    });
});