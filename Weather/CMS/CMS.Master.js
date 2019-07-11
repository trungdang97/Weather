$("#ChangePasswordBtn").prop("disabled", true);

var CheckRepeat = function () {
    HideAllWarningPassword();
    if ($("#NewPassword").val() == "") {
        $("#NewPasswordWarningEmpty").show();
        $("#NewPassword").css("border", "2px solid red");
        $("#ChangePasswordBtn").prop("disabled", true);

        return;
    }
    if ($("#OldPassword").val() == $("#NewPassword").val()) {
        $("#NewPasswordWarning").show();
        $("#NewPassword").css("border", "2px solid red");
        $("#ChangePasswordBtn").prop("disabled", true);
    }
    else {
        $("#NewPasswordWarning").hide();
        $("#NewPassword").css("border", "2px solid green");
        $("#ChangePasswordBtn").prop("disabled", false);
    }
}

var ConfirmPassword = function () {
    HideAllWarningPassword();
    if ($("#NewPassword").val() != $("#ConfirmNewPassword").val()) {
        $("#ConfirmNewPasswordWarning").show();
        $("#ConfirmNewPassword").css("border", "2px solid red");
        $("#ChangePasswordBtn").prop("disabled", true);
    }
    else {
        $("#ConfirmNewPasswordWarning").hide();
        $("#ConfirmNewPassword").css("border", "2px solid green");
        $("#ChangePasswordBtn").prop("disabled", false);
    }
}



var HideAllWarningPassword = function () {
    $("#NewPasswordWarningEmpty").hide();
    $("#NewPasswordWarning").hide();
    $("#ConfirmNewPasswordWarning").hide();
}

var ChangePassword = function () {
    var postData = {};
    postData.OldPassword = $("input[name=oldpassword]").val();
    postData.NewPassword = $("input[name=newpassword]").val();
    postData.UserId = $("#UserId").val();
    $.ajax({
        url: "/api/v1/user/update/password",
        method: "PUT",
        contentType: "json",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(postData),
        success: function (msg) {
            if (msg) {
                $("#OldPasswordWarning").hide();
                alert("Đổi mật khẩu thành công! Xin mời đăng nhập lại!");
                $("#LogoutBtn")[0].click();
            }
            else {
                $("#OldPasswordWarning").show();
                $("OldPassword").val("");
                $("NewPassword").val("");
                $("ConfirmNewPassword").val("");
            }
        }
    });
}

var ResetModal = function () {

}

var GetUserInfo = function () {
    var id = $("#UserId").val();
    $.ajax({
        url: "/api/v1/user/single/" + id,
        dataType: "json",
        method: "GET",
        success: function (data) {
            //console.log(data);
            $("#ListRoles").val(data.RoleId);
            $("#FullName").val(data.FullName);
            $("#ShortName").val(data.ShortName);
            $("#Phone").val(data.Phone);
            $("#Email").val(data.Email);
            $("#Username").val(data.Username);
        },
        error: function () {
            console.log("ERROR");
        }
    });
}

var SaveUserInfo = function () {
    var postData = {};
    postData.UserId = $("#UserId").val();
    postData.FullName = $("#FullName").val();
    postData.ShortName = $("#ShortName").val();
    postData.Phone = $("#Phone").val();
    postData.Email = $("#Email").val();
    //console.log(postData);
    $.ajax({
        url: "/api/v1/user/update",
        dataType: "json",
        method: "PUT",
        data: postData,
        success: function () {
            $("#userInfo").modal('hide');
            alert("Cập nhật thông tin thành công!");
            //$("#ListRoles").val(data.RoleId);
            //$("#FullName").val(data.FullName);
            //$("#ShortName").val(data.ShortName);
            //$("#Phone").val(data.Phone);
            //$("#Email").val(data.Email);
            //$("#Username").val(data.Username);
        },
        error: function () {
            console.log("ERROR");
        }
    });
}