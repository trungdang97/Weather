$(document).ready(function () {
    GetNews("3af42b3e-5e0c-4f30-bdce-9b020ee4b0c3");

});

var GetNews = function (NewsCategoryId) {
    var postData = {};
    postData.FilterText = "";
    postData.NewsCategoryId = NewsCategoryId;
    postData.PageNumber = 1;
    postData.PageSize = 6;
    postData.UserId = $("#UserId").val();

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
            $("#tab_default_2").html("<div class='row' id='tab_default_2_content'></div>");
            for (var i = 0; i < data.length; i++) {                
                $("#tab_default_2_content").append(
                    "<div class='col-md-4'>"
                    + "<div class='card'style='border: 1px solid black; margin-bottom: 20px;' >"
                    + "<img class='card-img-top' src='http://giaothongvietnam.vn/wp-content/uploads/2018/03/vinh-bac-bo.jpg' style='width: 100%' alt='Card image cap'>"
                    + "<div class='card-body' style='padding-left: 15px'>"
                    + "<h6 style='color: #808080'>Ngày đăng " + FormatDateTime(data[i].CreatedOnDate) + "</h6>"
                    + "<h4 class='card-title'><b>"+ data[i].Name +"</b></h4>"
                    + "<p class='card-text'>"+ data[i].Introduction +"</p>"
                    + "</div>"
                    + "</div>"
                    + "</div>");
            }
            //$("#tab_default_2").append("</div>");
        },
        error: function () {
            alert("Kết nối thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
};

function FormatDateTime(datetime) {
    var time = new Date(datetime);
    var d, M, y, H, m, s;
    if (time.getDate() < 10) {
        d = '0' + time.getDate();
    }
    else {
        d = time.getDate();
    }
    if (time.getMonth() < 10) {
        M = '0' + time.getMonth();
    }
    else {
        M = time.getMonth();
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