//var News = {};
var ListNews = [];
var Filter = {};
Filter.PageSize = 10;
Filter.PageNumber = 1;
Filter.NewsCategoryId = NewsCategoryId;

var NewsId = $("#newsid").val();
var NewsCategoryId = $("#newsCategory").val();

$(document).ready(function () {
    NewsId = $("#newsid").val();
    NewsCategoryId = $("#newsCategory").val();

    if (NewsId != null && NewsId != undefined && NewsId != "") {
        $("#News").show();
        $("#ListNews").hide();
        ShowNews();
    }
    else {
        $("#News").hide();
        $("#ListNews").show();
        Filter.NewsCategoryId = NewsCategoryId;
        ShowListNews();
    }
});

var ShowListNews = async function () {
    var ListNews = await GetNewsByFilter();
    //console.log(ListNews);
    for (var i = 0; i < ListNews.length; i++) {
        $("#InnerList").append("<div class='row' style='padding: 5px 0;'>"
            + "<div class='col-md-12' style='padding-bottom: 10px'><b><a href='?tin=" + ListNews[i].NewsId + "'>" + ListNews[i].Name + "<a/></b></div>"
            + "<div class='col-md-12'>"
            + "<div class='col-md-4'><img width='100%' src='" + ListNews[i].Thumbnail + "' /></div>"
            + "<div class='col-md-8'>" + ListNews[i].Introduction + "</div>"
            + "</div>"
            + "</div>"
            + "<hr/>");
    }
}


var ShowNews = async function () {
    var News = await GetNewsById(NewsId);
    $("#CreatedOnDate").html("Ngày " + FormatDateTime(News.CreatedOnDate));
    $("#Name").html(News.Name);
    $("#Introduction").html(News.Introduction);
    $("#Body").html(News.Body);
    $("#Credit").html("<b>Người thực hiện: " + News.Writer + "</b>");
}

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

async function GetNewsByFilter() {
    var listNews = [];
    await $.ajax({
        url: '/api/v1/news/filter',
        method: "POST",
        contentType: "json",
        data: JSON.stringify(Filter),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            listNews = data;
        }, error: function () {
            alert("Có lỗi xảy ra khi kết nối");
        }
    });
    return listNews;
}