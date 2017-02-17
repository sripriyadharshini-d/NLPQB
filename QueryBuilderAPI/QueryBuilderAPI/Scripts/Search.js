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
                //var jsonResponse = JSON.parse(response);
                $("#ResponseView").html(response['Result']);
            },
            201: function (response) {
                $("#ResponseView").html(response);
            },
            400: function (response) {
                $("#ResponseView").html('<span style="color:Red;">Error While Saving Outage Entry Please Check</span>', function () { });
            },
            404: function (response) {
                $("#ResponseView").html('<span style="color:Red;">Error While Saving Outage Entry Please Check</span>', function () { });
            }
        },
        success: function (response) {
            debugger;
            //var jsonResponse = JSON.parse(response);
            $("#ResponseView").html(response['Result']);
        }
    });
}
