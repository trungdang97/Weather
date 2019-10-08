var listVideos = [];

$(document).ready(function () {
    GetVideos();
});

var GetVideos = function () {
    $.ajax({
        url: "/api/v1/videos",
        method: "GET",
        contentType: "json",
        success: function (response) {
            listVideos = response;
            ShowListVideo();
        },
        error: function (response) {
            console.log(response);
            alert("Có lỗi xảy ra khi lấy dữ liệu!");
        }
    });
};

var ShowListVideo = function () {
    $("#table-body").html("");
    for (var i = 0; i < listVideos.length; i++) {
        $("#table-body").append("<tr>"
            + "<td>" + listVideos[i].Name + "</td>"
            + "<td class='text-center'>" + FormatDateTime(listVideos[i].CreatedOnDate) + "</td>"
            + "<td>" + listVideos[i].FullPath + "</td>"
            //+ "<td class='text-center'><button type='button' value='" + listVideos[i].Id + "' class='btn btn-danger' onclick='DeleteVideo(this)'><i class='fa fa-trash'></i></button></td>"
            + "</tr>")
    }
};

var DeleteVideo = function (btn) {
    $.ajax({
        url: "/api/v1/videos?id=" + btn.value,
        method: "DELETE",
        contentType: "json",
        dataType:"json",
        success: function (response) {
            alert("Xóa video thành công!");
        },
        error: function (response) {
            console.log(response);
            alert("Có lỗi xảy ra khi xóa video!");
        }
    });
};