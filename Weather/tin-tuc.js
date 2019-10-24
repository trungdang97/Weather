//var News = {};

var BackupImage = "/Content/Images/sky-1467177_1280.jpg"

var previousPage = 1;
var NewsId = $("#newsid").val();
var NewsCategoryId = $("#newsCategory").val();
var TotalQuantity = 0;

var ListNews = [];
var Filter = {};
Filter.PageSize = 10;
Filter.PageNumber = 1;
Filter.NewsCategoryId = NewsCategoryId;

var GetTotalQuantity = function () {
    $.ajax({
        url: '/api/v1/news/quantity/total?newsCategoryId=' + Filter.NewsCategoryId,
        method: "GET",
        contentType: "json",
        success: function (data) {
            TotalQuantity = data;
            $("#TotalPage").html(Math.floor(TotalQuantity / Filter.PageSize + 1))
        }, error: function () {
            alert("Có lỗi xảy ra khi kết nối");
        }
    });
};


//$("#PageNumber").change(function () {
//    ShowListNews();
//});

$(document).ready(function () {
    ///prevent submitting form
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
    ////

    NewsId = $("#newsid").val();
    NewsCategoryId = $("#newsCategory").val();
    $("#PageNumber").val(Filter.PageNumber);

    GetTotalQuantity();
    GetCategoryQuantity();
    GetRecentCategoryNews();
    GetRecentNews();

    if (NewsId != null && NewsId != undefined && NewsId != "") {
        $("#News").show();
        $("#ListNews").hide();
        ShowNews();
    }
    else if (NewsCategoryId != null && NewsCategoryId != undefined && NewsCategoryId != "") {
        $("#News").hide();
        $("#ListNews").show();
        Filter.NewsCategoryId = NewsCategoryId;
        ShowListNews();
    }
    else {
        $("#News").hide();
        $("#ListNews").show();
        Filter.NewsCategoryId = null;
        ShowListNews();
    }
});

var ShowListNews = async function () {
    var ListNews = await GetNewsByFilter();
    //console.log(ListNews);

    if (ListNews.length == 0) {
        alert("Không còn trang tin cũ hơn, trang cuối là trang số " + Math.floor(TotalQuantity / Filter.PageSize + 1));
        Filter.PageNumber = previousPage;
        $("#PageNumber").val(Filter.PageNumber);
        return;
    }
    else {
        $("#InnerList").html("");
        for (var i = 0; i < ListNews.length; i++) {
            $("#InnerList").append("<div class='row' style='padding: 10px 0;'>"
                + "<div class='col-md-12' style='padding-bottom: 10px'><b><a href='?tin=" + ListNews[i].NewsId + "'>" + ListNews[i].Name + "<a/></b></div>"
                + "<div class='col-md-12'>"
                + "<div class='col-md-4'><img width='100%' src='" + ((ListNews[i].Thumbnail == null || ListNews[i].Thumbnail == "") ? BackupImage : ListNews[i].Thumbnail) + "' /></div>"
                + "<div class='col-md-8'>" + ListNews[i].Introduction + "</div>"
                + "</div>"
                + "</div>"
                + "<hr/>");
        }
        window.scrollTo(0, 0);
        Pagination();
    }
}


var ShowNews = async function () {
    var News = await GetNewsById(NewsId);
    $("#CreatedOnDate").html("Ngày " + FormatDateTime(News.CreatedOnDate));
    $("#Name").html(News.Name);
    $("#Thumbnail").html("<img width='60%' src='" + News.Thumbnail + "'/>");
    $("#Introduction").html("<b>" + News.Introduction + "</b>");
    $("#Body").html(News.Body);
    $("#Credit").html("<b>Người đăng bài: " + News.Writer + "</b>");
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
    //Filter.PageNumber = $("#PageNumber").val();
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
    var lstTTSK = [];
    var lstRest = [];
    $.ajax({
        url: "/api/v1/news/category/quantity",
        dataType: "json",
        method: "GET",
        success: function (data) {
            $("#LstCM").html("");
            lstTTSK = data.filter(function (item) {
                return item.Description == 'noi-bo' || item.Description == 'thoi-tiet' || item.Description == 'hai-van' || item.Description == 'thuy-van';// || item.Description == 'gioi-thieu';
            });
            lstRest = data.filter(function (item) {
                return item.Description != 'noi-bo' && item.Description != 'thoi-tiet' && item.Description != 'hai-van' && item.Description != 'thuy-van';// || item.Description == 'gioi-thieu';
            });
            $("#LstCM").append(
                "<div style='padding: 10px 0px;'><a style='color:black;' href='javascript:ToggleTTSK();' on-click='' class='tree-toggle'>Tin tức sự kiện</a>"
                + "<ul class='nav tree' id='TTSK'>"
                + "</ul></div>"
            );
            $("#TTSK").hide();
            for (var i = 0; i < lstTTSK.length; i++) {
                $("#TTSK").append(
                    "<li>"
                    + "<a style='color:black;' href='/tin-tuc/" + lstTTSK[i].Description + "'> &gt;" + lstTTSK[i].Name + " (" + lstTTSK[i].Quantity + ")</a>"
                    +"</li>"
                );
            }
            for (var i = 0; i < lstRest.length; i++) {
                $("#LstCM").append("<div style='padding: 10px 0px;'><a style='color:black;' href='/tin-tuc/" + lstRest[i].Description + "'>" + lstRest[i].Name + " (" + lstRest[i].Quantity + ")</a></div>");
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
}
function ToggleTTSK() {
    $("#TTSK").toggle();
}

function GetRecentCategoryNews() {
    $.ajax({
        url: "/api/v1/news/category/recent?quantity=6" + "&NewsId=" + NewsId + "&Category=" + NewsCategoryId,
        dataType: "json",
        method: "GET",
        success: function (data) {
            $("#LstRecentCategoryNews").html("");
            for (var i = 0; i < data.length; i++) {
                $("#LstRecentCategoryNews").append("<div class='row' style='padding-top:5px'>"
                    + "<div class='col-md-9'><i style='font-size: 10px' class='fa fa-circle' aria-hidden='true'></i><a style='color:black' href = '" + window.location.pathname + "?tin=" + data[i].NewsId + "' > " + data[i].Name + "</a></div>"
                    + "<div class='col-md-3'><i class='pull-right'>" + FormatDate(data[i].CreatedOnDate) + "</i><div>"
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
        url: "/api/v1/news/category/recent?quantity=6" + "&NewsId=" + NewsId + "&Category=",
        dataType: "json",
        method: "GET",
        success: function (data) {
            $("#LstRecentNews").html("");
            for (var i = 0; i < data.length; i++) {
                $("#LstRecentNews").append("<div class='row' style='padding: 15px 0px;'>"
                    + "<div class='col-md-5' style='display: inline-block; height: 50px; padding-left: 0'>"
                    + "<img class='img-thumbnail' height='100%' src='" + ((data[i].Thumbnail == null || data[i].Thumbnail == "") ? BackupImage : data[i].Thumbnail) + "'>"
                    + "</div>"
                    + "<div class='col-md-7 pull-right' style='display: inline-block'>"
                    + "<div><a href=" + window.location.pathname + "?tin=" + data[i].NewsId + ">" + data[i].Name + "</a></div>"
                    + "<div style='padding-top:5px; color:grey'>" + FormatDate(data[i].CreatedOnDate) + "</div>"
                    + "</div>"
                    + "</div>");
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
}

//PAGINATION
var NextPage = function () {
    previousPage = Filter.PageNumber;
    Filter.PageNumber++;

    ShowListNews();

};

var PreviousPage = function () {
    if (Filter.PageNumber > 1) {
        previousPage = Filter.PageNumber;
        Filter.PageNumber--;
        ShowListNews();
        //window.scrollTo(0, 0); 
    }
};

$("#NextPage").click(function () {
    NextPage();
});

$("#PreviousPage").click(function () {
    PreviousPage();
});

var Pagination = function () {
    $("#Pages").html("");
    var show = 5;
    //var totalPages = Math.floor(TotalQuantity / Filter.PageSize < 5);
    //if (TotalQuantity / Filter.PageSize < 5) {
    //    show = Math.floor(TotalQuantity / 10 + 1);
    //}
    if ((Math.floor(TotalQuantity / Filter.PageSize + 1)) < show) {
        show = Math.floor(TotalQuantity / Filter.PageSize + 1);
    }
    if (Filter.PageNumber < 3) {
        for (var i = 1; i <= show; i++) {
            if (i == Filter.PageNumber) {
                $("#Pages").append("<button class='btn-primary' onclick='GoToPage(" + i + ")' type='button'>" + i + "</button>");
            }
            else {
                $("#Pages").append("<button onclick='GoToPage(" + i + ")' type='button'>" + i + "</button>");
            }
        }
    }
    else {
        for (var i = -2; i < show - 2; i++) {
            if (i == 0) {
                $("#Pages").append("<button class='btn-primary' onclick='GoToPage(" + (parseInt(Filter.PageNumber) + i) + ")' type='button'>" + (Filter.PageNumber + i) + "</button>");
            }
            else {
                $("#Pages").append("<button onclick='GoToPage(" + (parseInt(Filter.PageNumber) + i) + ")' type='button'>" + (Filter.PageNumber + i) + "</button>");
            }
        }
    }
};

var GoToPage = function (pageNumber) {
    previousPage = Filter.PageNumber;
    Filter.PageNumber = pageNumber;
    ShowListNews();
};

$("#PageNumber").keyup(function (e) {
    if (e.keyCode == 13) {
        GoToPage(parseInt($("#PageNumber").val()));
    }
});