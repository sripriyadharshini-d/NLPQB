//debugger;
var uri = "api/Search/Process";
$(document).ready(function () {

});
function search() {
    debugger;
    var query = $('#searchControl').val();
    var searchModel = { SearchText: query };
    $.ajax({
        type: "Post",
        url: uri,
        data: searchModel,
        contenttype: "application/JSON",
        error: function () { },
        dataType: 'json',
        statusCode: {
            200: function (response) {
                debugger;
                var jsonResponse = JSON.stringify(response);
                
                var txt = "";
                    txt += "<table border='1'> <tr>"
                for (var columnHeader in response[0]) {
                    txt += "<td>" + columnHeader + "</td>"
                }
                txt += "</tr>"

                txt += "<tr>"
                for (var columnHeader in response[0]) {
                    txt += "<td>" + response[0][columnHeader] + "</td>"
                }
                txt += "</tr>"

                txt += "</table>"
                $("#dataGrid").html(txt);
            },
            201: function (response) {
                var jsonResponse = JSON.stringify(response);
                $("#dataGrid").html(jsonResponse);
            },
            400: function (response) {
                $("#dataGrid").html('<span style="color:Red;">Error While Saving Outage Entry Please Check</span>', function () { });
            },
            404: function (response) {
                $("#dataGrid").html('<span style="color:Red;">Error While Saving Outage Entry Please Check</span>', function () { });
            }
        },
        success: function (response) {
            debugger;
            //var jsonResponse = JSON.parse(response);
            var jsonResponse = JSON.stringify(response);
            $("#ResponseView").html(jsonResponse);
        }
    });
}