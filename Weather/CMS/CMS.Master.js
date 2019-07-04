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
        url: "/api/v1/user/update",
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