$("#Register").click(function () {
    var postData = {};
    postData.Username = $("#Username").val();
    postData.Phone = $("#Phone").val();
    postData.FullName = $("#FullName").val();
    postData.ShortName = $("#ShortName").val();
    postData.Password = $("#Password").val();

    $.ajax({
        url: "/api/v1/user/register",
        dataType: "json",
        method: "POST",
        data: postData,
        success: function (data) {
            console.log(data);
        },
        error: function () {
            alert("Không thể gửi được yêu cầu. Xin hãy thử lại sau ít phút.");
        }
    });
});