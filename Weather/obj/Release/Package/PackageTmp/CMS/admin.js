$("#BtnReset").click(function () {
    $('#exampleModal').modal('hide');
    $('#MainContent_ListRoles').get(0).selectedIndex = 0;
    $("#username").val("");
    $("#password").val("");
});

$("#BtnSave").click(function () {
    var postData = {};
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
});

$(document).ready(function () {
    GetData();
});

var Delete = function () {

};

var GetData = function () {
    $.ajax({
        url: "/api/v1/user",
        method: "GET",
        contentType: "json",
        //data: JSON.stringify(postData),
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
                $("#table-body").append("<tr>"
                    + "<td class='text-center'>"
                    + "<input type='checkbox' onclick value='" + data[i].NewsId + "' class='multiSelect'>"
                    + "</td>"
                    + "<td>"
                    + data[i].Username
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].FullName
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].ShortName
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].RoleName
                    + "</td>"                   
                    + "<td class='text-center'>"
                    + "<button type='button' value='" + data[i].NewsId + "' style='background-color:deepskyblue;width:28px;height:28px;padding:4px;margin:5px' class='btn'><i style='font-size:20px;color:white' class='fa fa-edit'></i></button>"
                    + "<button type='button' onclick='PrepareDelete(this)' data-toggle='modal' data-target='#myModal' value='" + data[i].NewsId + "' style='background-color:red;width:28px;height:28px;padding:4px;' class='btn'><i style='font-size:20px;color:white' class='fa fa-trash'></i></button>"
                    + "</td>"
                    + "</tr>"
                );
            }
            //console.log(data);
            //alert("Thêm mới tin bài thành công!");
            //$("#BtnReset").click();
        },
        error: function () {
            alert("Kết nối thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
};