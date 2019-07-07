var News = {};

$(document).ready(async function () {
    News = await GetNewsById($("#newsid").val());
    $("#CreatedOnDate").html("Ngày " + FormatDateTime(News.CreatedOnDate));
    $("#Name").html(News.Name);
    $("#Introduction").html(News.Introduction);
    $("#Body").html(News.Body);
    $("#Credit").html("<b>Người thực hiện: " + News.Writer + "</b>");
});

async function GetNewsById(NewsId) {
    var news = {};
    await $.ajax({
        url: '/api/v1/news?NewsId=' + NewsId,
        method: "GET",
        contentType: "json",
        success: function (data) {
            news = data;
        }, error: function () {
            alert("Có lỗi xảy ra khi kết nối");
        }
    });
    return news;
}