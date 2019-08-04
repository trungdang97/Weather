//var News = {};
var ListNews = [];
var Filter = {};
Filter.PageSize = 10;
Filter.PageNumber = 1;
Filter.NewsCategoryId = NewsCategoryId;

var NewsId = $("#newsid").val();
var NewsCategoryId = $("#newsCategory").val();


$("#PageNumber").change(function () {
    ShowListNews();
});

$(document).ready(function () {
    NewsId = $("#newsid").val();
    NewsCategoryId = $("#newsCategory").val();

    GetCategoryQuantity();
    GetRecentCategoryNews();
    GetRecentNews();

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
    $("#InnerList").html("");
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
    $("#Thumbnail").html("<img src='" + News.Thumbnail + "'/>");
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
    Filter.PageNumber = $("#PageNumber").val();
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

function GetCategoryQuantity() {
    //var lstCM = [];
    $.ajax({
        url: "/api/v1/news/category/quantity",
        dataType: "json",
        method: "GET",
        success: function (data) {
            //lstCM = data;
            //console.log(lstCM);
            $("#LstCM").html("");
            for (var i = 0; i < data.length; i++) {
                $("#LstCM").append("<div style='padding: 10px 0px;'><a style='color:black;' href='#'>" + data[i].Name + " (" + data[i].Quantity + ")</a></div>");
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
}

function GetRecentCategoryNews() {
    $.ajax({
        url: "/api/v1/news/category/recent?quantity=6" + "&NewsId=" + NewsId + "&Category=",
        dataType: "json",
        method: "GET",
        success: function (data) {
            $("#LstRecentCategoryNews").html("");
            for (var i = 0; i < data.length; i++) {
                $("#LstRecentCategoryNews").append("<div class='row' style='padding-top:5px'>"
                    + "<div class='col-md-9'><i style='font-size: 10px' class='fa fa-circle' aria-hidden='true'></i><a style='color:black' href = '" + window.location.pathname + "?tin=" + data[i].NewsId + "' > " + data[i].Name + "</a></div>"
                    + "<div class='col-md-3'><i>" + FormatDate(data[i].CreatedOnDate) +"</i><div>"
                    + "</div>");
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
}

function GetRecentNews() {
    $.ajax({
        url: "/api/v1/news/category/recent?quantity=6" + "&NewsId=" + NewsId + "&Category=" + NewsCategoryId,
        dataType: "json",
        method: "GET",
        success: function (data) {
            $("#LstRecentNews").html("");
            for (var i = 0; i < data.length; i++) {
                $("#LstRecentNews").append("<div class='row' style='padding: 10px 0px;'>"
                    + "<div class='col-md-5' style='display: inline-block; height: 50px; padding-left: 0'>"
                    + "<img height='100%' src='" + data[i].Thumbnail + "'>"
                    + "</div>"
                    + "<div class='col-md-7 pull-right' style='display: inline-block'>"
                    + "<div><a href=" + window.location.pathname + "?tin=" + data[i].NewsId + ">" + data[i].Name + "</a></div>"
                    + "<div style='padding-top:5px; color:grey'>31/07/2019</div>"
                    + "</div>"
                    + "</div>");
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
}

