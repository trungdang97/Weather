var userid = $("#UserId").val();
$(document).ready(async function () {
    startTime();
    GetNewsCategory();
    //await GetServices();
    //if (userid != "") {
    //    GetLstApi();
    //}

    //$(document).on('click', 'a.service', function () {
    //    //var id = $("#UserId").val();
    //    if (userid == "") {
    //        alert("Bạn cần đăng nhập để sử dụng dịch vụ");
    //        $("#LoginModal").click();
    //    }
    //    else {
    //        var APIId = $(this).attr("id");
    //        //alert(APIId);
    //        var right = LstApi.find(function (s) {
    //            return s.APIId == APIId;
    //        });
    //        if (right != null || right != undefined) {
    //            alert("Bạn đã đăng ký sử dụng dịch vụ này");
    //        }
    //        else {
    //            alert("Bạn chưa đăng ký sử dụng dịch vụ này");
    //        }
    //    }
    //});
});

var LstApi = [];
var GetLstApi = function () {
    $.ajax({
        url: "/api/v1/API/list?userid=" + userid,
        method: "GET",
        dataType: "json",
        success: function (data) {
            LstApi = data;
        },
        error: function () {
            alert("Đã xảy ra lỗi khi lấy dữ liệu dịch vụ.");
        }
    });
};

var Services = [];
var GetServices = async function () {
    $.ajax({
        url: "/api/v1/APIType?filterText=",
        method: "GET",
        dataType: "json",
        success: await async function (data) {
            for (var i = 0; i < data.length; i++) {
                var service = {};
                service.Id = data[i].APITypeId;
                service.Name = data[i].Name;
                Services.push(service);
                $("#TopNav").append("<li class='new-nav-link'>"
                    + "<a class='dropdown-toggle' data-toggle='dropdown' role='button' aria-haspopup='true' aria-expanded='false' href='#'>" + Services[i].Name + "<span class='caret'></span></a>"
                    + "<ul class='dropdown-menu' id='" + Services[i].Id + "'>"
                    + "</ul>"
                    + "</li>");
                await GetFilter(i);

            }
            console.log(Services);

        },
        error: function () {
            alert("Đã xảy ra lỗi khi lấy dữ liệu danh mục.");
        }
    });
};
async function GetFilter(index) {
    var filter = {};
    filter.FilterText = "";
    filter.APITypeId = Services[index].Id;

    $.ajax({
        url: "/api/v1/API/filter?filterString=" + JSON.stringify(filter),
        method: "GET",
        contentType: "json",
        success: await function (data) {
            //console.log("OK DETAIL", data);
            Services[index].Available = data;

            for (var j = 0; j < Services[index].Available.length; j++) {
                $("#" + Services[index].Id).append("<li><a href='#' class='service' id='" + Services[index].Available[j].APIId + "'>" + Services[index].Available[j].Name + "</a></li>");
            }

        },
        error: function () {
            alert("Kết nối thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
}

function startTime() {
    var today = new Date();
    var H = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    var d = today.getDate();
    var M = today.getMonth();
    var y = today.getFullYear();

    var timezone = today.getTimezoneOffset() / 60 * (-1);
    if (timezone > 0) {
        timezone = '(GMT+' + timezone + ')';
    }
    $('#basicDateTime').html(getDayOfWeek() + ', ' + checkTime(d) + "/" + checkTime(M + 1) + "/" + checkTime(y) + ', ' + checkTime(H) + ":" + checkTime(m) + ' ' + timezone);
    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) {
        return '0' + i;
    }
    return i;
}

function getDayOfWeek() {
    var d = new Date().getDay();
    switch (d) {
        case 0:
            return 'Chủ Nhật';
        case 1:
            return 'Thứ Hai';
        case 2:
            return 'Thứ Ba';
        case 3:
            return 'Thứ Tư';
        case 4:
            return 'Thứ Năm';
        case 5:
            return 'Thứ Sáu';
        case 6:
            return 'Thứ Bảy';
    }
}

function FormatDateTime(datetime) {
    var time = new Date(datetime);
    var d, M, y, H, m, s;
    if (time.getDate() < 10) {
        d = '0' + time.getDate();
    }
    else {
        d = time.getDate();
    }
    if (time.getMonth() + 1 < 10) {
        M = '0' + (time.getMonth() + 1);
    }
    else {
        M = time.getMonth() + 1;
    }
    if (time.getHours() < 10) {
        H = '0' + time.getHours();
    }
    else {
        H = time.getHours();
    }
    if (time.getMinutes() < 10) {
        m = '0' + time.getMinutes();
    }
    else {
        m = time.getMinutes();
    }
    if (time.getSeconds() < 10) {
        s = '0' + time.getSeconds();
    }
    else {
        s = time.getSeconds();
    }
    var formattedString = d + "/" + M + "/" + time.getFullYear() + " lúc " + H + ":" + m + ":" + s;
    return formattedString;
}

//Lấy dữ liệu để in ra nav bar: các thể loại tin thời tiết
var GetNewsCategory = function () {
    $.ajax({
        url: "/api/v1/news/category?Type=" + "TT",
        method: "GET",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                $("#TopNav").append("<li class='new-nav-link'>"
                    + "<a href='kttv/" + data[i].Description + "'>" + data[i].Name + "</a>"
                    + "</li>");
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
}

var Format