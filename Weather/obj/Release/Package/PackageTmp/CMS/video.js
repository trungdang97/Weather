var listVideos = [];

$(document).ready(function () {
    GetVideos();

    $("#BtnSave").click(async function () {
        await CreateVideo();
    });

    $("#BtnReset").click(function () {
        modalReset();
    });
    $("#BtnReset1").click(function () {
        modalReset1();
    });

    $("#File").change(function () {
        $("#FileName").val(($("#File").get(0).files[0].name));
    });
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
            + "<td class='text-center'><button type='button' class='btn btn-primary' onclick='prepareTitle(this)' value='" + listVideos[i].Id + "' data-toggle='modal' data-target='#exampleModal1'><i class='fa fa-pencil'></i></button >&ensp;<button type='button' value='" + listVideos[i].Id + "' class='btn btn-danger' onclick='DeleteVideo(this)' data-toggle='modal' data-target='#myModal'><i class='fa fa-trash'></i></button></td>"
            + "</tr>")
    }
};

var prepareTitle = function (btn) {
    var newList = listVideos.filter(function (element) {
        return element.Id == btn.value;
    });
    $("#Name1").val(newList[0].Name);
    videoId = btn.value;
};

var modalReset = function () {
    $("#Name").val("");
    $("#FileName").val("");
    $("#File").val("");
    $('#exampleModal').modal('hide');
}
var modalReset = function () {
    $("#Name1").val("");
}

var CreateVideo = function () {
    var video = {};
    video.Name = $("#Name").val();
    video.FullPath = $("#FileName").val();

    //video.File = $("#File").get(0).files[0];

    $.ajax({
        url: "/api/v1/videos/create",
        method: "POST",
        data: JSON.stringify(video),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        contentType: "json",
        success: function (response) {
            var data = new FormData();

            var files = $("#File").get(0).files;

            // Add the uploaded image content to the form data collection
            if (files.length > 0) {
                data.append("UploadedVideo", files[0]);
            }

            // Make Ajax request with the contentType = false, and procesDate = false
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "/api/v1/videos/upload",
                contentType: false,
                processData: false,
                data: data
            });

            ajaxRequest.done(function (xhr, textStatus) {
                alert("Upload video thành công!");
                modalReset();
                GetVideos();
            });
        },
        error: function (response) {
            console.log(response);
        }
    });
};

var videoId = null;
var DeleteVideo = function (btn) {
    videoId = btn.value;
};

var Delete = function () {
    $.ajax({
        url: "/api/v1/videos/delete?id=" + videoId,
        method: "DELETE",
        success: function (response) {
            alert("Xóa video thành công!");
            GetVideos();
        },
        error: function (response) {
            console.log(response);
            alert("Có lỗi xảy ra khi xóa video!");
        }
    });
};

var Update = function () {
    $.ajax({
        url: "/api/v1/videos/update?id=" + videoId + "&name=" + $("#Name1").val(),
        method: "PUT",
        success: function (response) {
            alert("Cập nhật tiêu đề thành công!");
            $('#exampleModal1').modal('hide');
            GetVideos();
        },
        error: function (response) {
            console.log(response);
            alert("Có lỗi xảy ra khi sửa tiêu đề video!");
        }
    });
}