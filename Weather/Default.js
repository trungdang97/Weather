var Forecast_BaseURL = "http://183.91.4.95:8589";
var Forecast_TestURL = "http://localhost:8589";

$(document).ready(function () {
    GetNews("3af42b3e-5e0c-4f30-bdce-9b020ee4b0c3", "TT");
    GetNews("dac7f4bf-b0c0-4003-bde0-d5eeea71ba03", "NB");
    GetNews("328e5dbf-966a-4fbd-8642-e5a6f2be6033", "XH");

    GetForecast();
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

//var GetForecast = async function () {
//    var data = null;
//     await $.ajax({
//        url: "http://localhost:8589/api/v1/MRFDLY/demodaily",
//        dataType: 'jsonp',
//        //crossDomain: true,
//        //headers: { 'Access-Control-Allow-Origin': 'http://localhost:8589' },
//        success: function (response) {
//            data = response;
//            console.log(response);
//        },
//        error: function (response) {
//            console.log(response);
//            alert("Không thể tải dữ liệu dự báo thời tiết! Xin hãy kiểm tra đường truyền.")
//        }
//    });

//    //script = document.createElement("script");
//    //script.type = "text/javascript";
//    //script.src = "http://localhost:8589/api/v1/MRFDLY/demodaily?callback=GetForecastData";

//    //$.getJSON("http://localhost:8589/api/v1/MRFDLY/demodaily?method=getQuote&format=jsonp&lang=en&jsonp=GetForecastData&?callback=?", function (result) {
//    //    //response data are now in the result variable
//    //    console.log(result);
//    //});
//};

//var GetForecastData = function (data) {
//    console.log(data.Data);
//};
