var Forecast_BaseURL = "http://183.91.4.95:8589";
var Forecast_TestURL = "http://localhost:8589";

var ForecastPageSize = 6;
var ForecastData = [];
var ForecastPageNumber = 1;
var ForecastTotalPage = 1;
var ForecastHeight = 0;
var ForecastInnerHeight = 0;

$(document).ready(async function () {
    GetNews("3af42b3e-5e0c-4f30-bdce-9b020ee4b0c3", "TT");
    GetNews("dac7f4bf-b0c0-4003-bde0-d5eeea71ba03", "NB");
    GetNews("328e5dbf-966a-4fbd-8642-e5a6f2be6033", "XH");

    await GetForecast();

    
});
$("#PreviousForecast").click(function () {
    PreviousForecastPage();
});
$("#NextForecast").click(function () {
    NextForecastPage();
});

var GetNews = function (NewsCategoryId, Code) {
    var postData = {};
    postData.FilterText = "";
    postData.NewsCategoryId = NewsCategoryId;
    postData.PageNumber = 1;
    postData.PageSize = 6;
    postData.UserId = null;

    $.ajax({
        url: "/api/v1/news/filter",
        method: "POST",
        contentType: "json",
        data: JSON.stringify(postData),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {

            if (Code == 'NB' && data.length != 0) {
                $("#tab_default_1").html("<div class='card-deck' id='tab_default_1_content'></div>");
                for (var i = 0; i < data.length; i++) {
                    $("#tab_default_1_content").append(
                        "<div class='card' style='border: 1px solid black; margin-bottom: 20px;' >"
                        + "<img class='card-img-top' src='" + data[i].Thumbnail + "' style='width: 100%' alt='Card image cap'>"
                        + "<div class='card-body' style='padding-left: 15px'>"
                        + "<h6 style='color: #808080'>Ngày đăng " + FormatDateTime(data[i].CreatedOnDate) + "</h6>"
                        + "<h4 class='card-title'><a href='tin-tuc/noi-bo?tin=" + data[i].NewsId + "'>" + data[i].Name + "</a></h4>"
                        + "<p class='card-text'>" + data[i].Introduction + "</p>"
                        + "</div>"
                        + "</div>"
                        + "</div>");
                }
            }
            else if (Code == 'TT' && data.length != 0) {
                $("#tab_default_2").html("<div class='card-deck' id='tab_default_2_content'></div>");
                for (var i = 0; i < data.length; i++) {
                    $("#tab_default_2_content").append(
                        "<div class='card' style='border: 1px solid black; margin-bottom: 20px;' >"
                        + "<img class='card-img-top' src='" + data[i].Thumbnail + "' style='width: 100%' alt='Card image cap'>"
                        + "<div class='card-body' style='padding-left: 15px'>"
                        + "<h6 style='color: #808080'>Ngày đăng " + FormatDateTime(data[i].CreatedOnDate) + "</h6>"
                        + "<h4 class='card-title'><a href='tin-tuc/thoi-tiet?tin=" + data[i].NewsId + "'>" + data[i].Name + "</a></h4>"
                        + "<p class='card-text'>" + data[i].Introduction + "</p>"
                        + "</div>"
                        + "</div>"
                        + "</div>");
                }
            }
            else if (Code == 'XH' && data.length != 0) {
                $("#tab_default_3").html("<div class='card-deck' id='tab_default_3_content'></div>");
                for (var i = 0; i < data.length; i++) {
                    $("#tab_default_3_content").append(
                        "<div class='card' style='border: 1px solid black; margin-bottom: 20px;' >"
                        + "<img class='card-img-top' src='" + data[i].Thumbnail + "' style='width: 100%;' alt='Card image cap'>"
                        + "<div class='card-body' style='padding-left: 15px'>"
                        + "<h6 style='color: #808080'>Ngày đăng " + FormatDateTime(data[i].CreatedOnDate) + "</h6>"
                        + "<h4 class='card-title'><a href='tin-tuc/xa-hoi?tin=" + data[i].NewsId + "'>" + data[i].Name + "</a></h4>"
                        + "<p class='card-text'>" + data[i].Introduction + "</p>"
                        + "</div>"
                        + "</div>"
                        + "</div>");
                }
            }
            //$("#tab_default_2").append("</div>");
        },
        error: function () {
            alert("Kết nối thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
};

var GetForecast = async function () {
    await $.ajax({
        url: Forecast_BaseURL + "/api/v1/MRFDLY/demodaily",
        method: "GET",
        dataType: 'json',
        success: async function (response) {
            ForecastData = response.Data;
            ForecastTotalPage = Math.ceil(response.TotalCount / ForecastPageSize);
            //console.log(response);
            await ShowForecast(ForecastPageNumber);
            ForecastHeight = await $("#citiesWeather").height();
            ForecastInnerHeight = await $("#ForecastContent tr").height();
            $("iframe").height(ForecastHeight);
            $("#citiesWeather").height(ForecastHeight);
            //$("#ForecastContent").height(ForecastInnerHeight);
            $("#ForecastPageNumber").html(ForecastPageNumber);
            $("#ForecastTotalPage").html(ForecastTotalPage);
        },
        error: function (response) {
            console.log(response);
            alert("Không thể tải dữ liệu dự báo thời tiết! Xin hãy kiểm tra đường truyền.")
        }
    });
};

var ShowForecast = async function (pageNumber) {
    var excludedRows = (pageNumber - 1) * ForecastPageSize;
    var min = excludedRows;
    var max = excludedRows + ForecastPageSize;
    $("#ForecastContent").html("");
    for (var i = min; i < max; i++) {
        if (ForecastData[i] != undefined) {
            var icon = await GetWeatherIcon(ForecastData[i].WX_1DAY);
            $("#ForecastContent").append("<tr>"
                + "<td style='padding-right: 5px;width: 70px'>"
                + " <img src='"+icon+"' alt='Icon here' width='50px' />"
                + "</td>"
                + "<td>"
                + "<span class='text-uppercase' style='font-size: 14px'>" + ForecastData[i].Location + "</span>"
                + "<span class='pull-right' style='color: #dec402; font-size: 14px; padding-top: 5px'>" + Math.floor(ForecastData[i].AIRTMP_1DAY_MIN) + "-" + Math.floor(ForecastData[i].AIRTMP_1DAY_MAX) + "&#176;C</span>"
                + "<br />"
                + "<span style='font-size: 12px; color: grey;'>" + ForecastData[i].WeatherCondition + "</span>"
                + "</td>"
                + "</tr>");
        }
        else {
            $("#ForecastContent").append("<tr><td style='height:" + ForecastInnerHeight + "px'></td></tr>");
        }
    }
    UpdatePageNumber();
    ToggleForecastNavigation();
}

var PreviousForecastPage = function () {
    if (ForecastPageNumber > 1) {
        ForecastPageNumber--;
    }
    else ForecastPageNumber = 1;

    ShowForecast(ForecastPageNumber);
}
var NextForecastPage = function () {
    if (ForecastPageNumber < ForecastTotalPage) {
        ForecastPageNumber++;
    }
    else ForecastPageNumber = ForecastTotalPage;

    ShowForecast(ForecastPageNumber);
}

var UpdatePageNumber = function () {
    $("#ForecastPageNumber").html(ForecastPageNumber);
};
var ToggleForecastNavigation = function () {
    if (ForecastPageNumber == 1) {
        $("#PreviousForecast").hide();
    }
    else if (ForecastPageNumber == ForecastTotalPage) {
        $("#NextForecast").hide();
    }
    else {
        $("#NextForecast").show();
        $("#PreviousForecast").show();
    }
}

var GetWeatherIcon = function (WX_1DAY) {
    return IconsMapping.find(x => x.WX_1DAY == WX_1DAY).Icon;
};

var IconsMapping = [
    {
        WX_1DAY: 100,
        Name: "Trời nắng",
        Icon: "Content/Images/Icon/Icon/100.png"
    },
    {
        WX_1DAY: 101,
        Name: "Ít mây",
        Icon: "Content/Images/Icon/Icon/101.png"
    },
    {
        WX_1DAY: 200,
        Name: "Trời có mây",
        Icon: "Content/Images/Icon/Icon/200.png"
    },
    {
        WX_1DAY: 201,
        Name: "Trời nhiều mây",
        Icon: "Content/Images/Icon/Icon/201.png"
    },
    {
        WX_1DAY: 202,
        Name: "Trời có mây và có thể có mưa",
        Icon: "Content/Images/Icon/Icon/202-203.png"
    },   
    {
        WX_1DAY: 203,
        Name: "Trời có mây và thỉnh thoảng có mưa",
        Icon: "Content/Images/Icon/Icon/202-203.png"
    },
    {
        WX_1DAY: 300,
        Name: "Mưa",
        Icon: "Content/Images/Icon/Icon/300-302.png"
    },
    {
        WX_1DAY: 302,
        Name: "Mưa thất thường",
        Icon: "Content/Images/Icon/Icon/300-302.png"
    },
    {
        WX_1DAY: 500,
        Name: "Thời tiết đẹp",
        Icon: ""
    },
    {
        WX_1DAY: 0,
        Name: "Trời nắng",
        Icon: "Content/Images/Icon/Icon/tornado.png"
    },
];