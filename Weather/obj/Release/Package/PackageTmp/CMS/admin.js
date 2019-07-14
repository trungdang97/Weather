$("#BtnReset").click(function () {
    $('#exampleModal').modal('hide');
    $('#MainContent_ListRoles').get(0).selectedIndex = 0;
    $("#username").val("");
    $("#password").val("");
    $("#fullname").val("");
    $("#shortname").val("");
});

$("#BtnSave").click(function () {
    var postData = {};
    if (CreateState == true) {
        postData.username = $("#username").val();
        postData.password = $("#password").val();
        postData.roleid = $("#MainContent_ListRoles").find(":selected").val();
        postData.fullname = $("#fullname").val();
        postData.shortname = $("#shortname").val();
        $.ajax({
            url: "/api/v1/user/create",
            method: "POST",
            contentType: "json",
            data: JSON.stringify(postData),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            success: function () {
                alert("Thêm mới người dùng thành công!");
                $("#BtnReset").click();
            },
            error: function () {
                alert("Thêm mới người dùng thất bại. Xin hãy kiểm tra lại kết nôi.");
            }
        });
    }
    else if (CreateState == false) {

    }
});


$(document).ready(function () {
    GetFilter();
});

var Delete = function () {

};

//var GetData = function () {
//    $.ajax({
//        url: "/api/v1/user",
//        method: "GET",
//        contentType: "json",
//        //data: JSON.stringify(postData),
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        },
//        success: function (data) {
//            $("#table-body").html("");
//            if (data.length == 0) {
//                $("#table-body").html("<tr><td class='text-center' colspan='6'>Không có dữ liệu</td></tr>");
//                return;
//            }

//            for (var i = 0; i < data.length; i++) {
//                $("#table-body").append("<tr>"
//                    + "<td class='text-center'>"
//                    + "<input type='checkbox' onclick value='" + data[i].NewsId + "' class='multiSelect'>"
//                    + "</td>"
//                    + "<td>"
//                    + data[i].Username
//                    + "</td>"
//                    + "<td class='text-center'>"
//                    + data[i].FullName
//                    + "</td>"
//                    + "<td class='text-center'>"
//                    + data[i].ShortName
//                    + "</td>"
//                    + "<td class='text-center'>"
//                    + data[i].RoleName
//                    + "</td>"                   
//                    + "<td class='text-center'>"
//                    + "<button type='button' value='" + data[i].NewsId + "' style='background-color:deepskyblue;width:28px;height:28px;padding:4px;margin:5px' class='btn'><i style='font-size:20px;color:white' class='fa fa-edit'></i></button>"
//                    + "<button type='button' onclick='PrepareDelete(this)' data-toggle='modal' data-target='#myModal' value='" + data[i].NewsId + "' style='background-color:red;width:28px;height:28px;padding:4px;' class='btn'><i style='font-size:20px;color:white' class='fa fa-key'></i></button>"
//                    + "</td>"
//                    + "</tr>"
//                );
//            }
//            //console.log(data);
//            //alert("Thêm mới tin bài thành công!");
//            //$("#BtnReset").click();
//        },
//        error: function () {
//            alert("Kết nối thất bại. Xin hãy kiểm tra lại kết nôi.");
//        }
//    });
//};

$("#MainContent_ListRolesOutter").change(function () {
    GetFilter();
});
$("#FilterText").keyup(function () {
    GetFilter();
});

$("#BtnReset2").click(function () {
    $('#exampleModal2').modal('hide');
    $('#MainContent_ListRoles2').get(0).selectedIndex = 0;
    $("#username2").val("");
    $("#fullname2").val("");
    $("#shortname2").val("");
});
function GetDetail(btn) {
    var id = btn.value;
    $.ajax({
        url: "/api/v1/user/single/" + id,
        method: "GET",
        contentType: "json",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            $("#MainContent_ListRoles2").val(data.RoleId);
            $("#username2").val(data.Username);
            $("#fullname2").val(data.FullName);
            $("#shortname2").val(data.ShortName);
        }
    });
}

function GetFilter() {
    var filter = {};
    filter.FilterText = $("#FilterText").val();
    filter.RoleId = $("#MainContent_ListRolesOutter").val();
    $.ajax({
        url: "/api/v1/user/filter?filterString=" + JSON.stringify(filter),
        method: "GET",
        contentType: "json",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            $("#table-body").html("");
            if (data.length == 0) {
                $("#table-body").html("<tr><td class='text-center' colspan='6'>Không có dữ liệu</td></tr>");
                return;
            }

            for (var i = 0; i < data.length; i++) {
                var color = "red";
                var title = "Mở khóa tài khoản";
                var modal = "#myModal1";
                if (data[i].IsActive) {
                    color = "green";
                    title = "Khóa tài khoản";
                    modal = "#myModal2";
                }
                if (data[i].Username == "admin") {
                    $("#table-body").append("<tr>"
                        + "<td class='text-center'>"
                        + "<input type='checkbox' onclick value='" + data[i].UserId + "' class='multiSelect'>"
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].Username
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].FullName
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].Email
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].Phone
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].ShortName
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].RoleName
                        + "</td>"
                        + "<td class='text-center'>"
                        //+ "<button type='button' value='" + data[i].UserId + "' style='background-color:deepskyblue;width:28px;height:28px;padding:4px;margin:5px' class='btn'><i style='font-size:20px;color:white' class='fa fa-edit'></i></button>"
                        + "</td>"
                        + "</tr>"
                    );
                }
                else {
                    $("#table-body").append("<tr>"
                        + "<td class='text-center'>"
                        + "<input type='checkbox' onclick value='" + data[i].UserId + "' class='multiSelect'>"
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].Username
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].FullName
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].Email
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].Phone
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].ShortName
                        + "</td>"
                        + "<td class='text-center'>"
                        + data[i].RoleName
                        + "</td>"
                        + "<td class='text-center'>"
                        + "<button type='button' value='" + data[i].UserId + "' onclick='GetDetail(this)' data-toggle='modal' data-target='#exampleModal2' style='background-color:deepskyblue;width:28px;height:28px;padding:4px;margin:5px' class='btn'><i style='font-size:20px;color:white' class='fa fa-edit'></i></button>"
                        + "<button type='button' onclick='PrepareLock(this)' data-toggle='modal' data-target='" + modal + "' value='" + data[i].UserId + "' style='background-color:" + color + ";width:28px;height:28px;padding:4px;' class='btn' title='" + title + "'><i style='font-size:20px;color:white' class='fa fa-key'></i></button>"
                        + "</td>"
                        + "</tr>"
                    );
                }
            }
        }
    });
}

var LockId = null;
function PrepareLock(btn) {
    LockId = btn.value;
}

function ToggleLock() {
    $.ajax({
        url: "/api/v1/user/togglelock/" + LockId,
        method: "PUT",
        contentType: "json",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            GetFilter();
            if (data.IsActive) {
                alert("Mở khóa người dùng thành công.");
            }
            else {
                alert("Khóa người dùng thành công.");
            }
            console.log("SUCCESS");
        },
        error: function () {
            alert("Mở/khóa người dùng thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    })
}