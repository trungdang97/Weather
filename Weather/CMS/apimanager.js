CKEDITOR.replace('Body', {
    customConfig: 'code_config.js'
});
CKEDITOR.replace('Documentation');

$(document).ready(function () {
    GetFilter();
});

$("#FilterText").keyup(function () {
    GetFilter();
});
$('#MainContent_ListAPITypeOutter').change(function () {
    GetFilter();
});

$("#BtnReset").click(function () {
    $('#exampleModal').modal('hide');
    $('#MainContent_ListAPIType').get(0).selectedIndex = 0;
    $("#APICode").val("");
    $("#Name").val("");
    $("#Price").val("");
    $("#Duration").val("");
    CKEDITOR.instances.Body.setData("");
    CKEDITOR.instances.Documentation.setData("");
    $("#DocumentationLink").val("");
});

$("#BtnSave").click(function () {
    var postData = {};
    postData.APITypeId = $("#MainContent_ListAPIType").val();
    postData.APICode = $("#APICode").val();
    postData.Name = $("#Name").val();
    postData.Price = $("#Price").val();
    postData.Duration = $("#Duration").val();
    postData.Body = CKEDITOR.instances['Body'].getData();
    postData.Documentation = CKEDITOR.instances['Documentation'].getData();
    postData.DocumentationLink = $("#DocumentationLink").val();

    $.ajax({
        url: "/api/v1/API/create",
        method: "POST",
        contentType: "json",
        data: JSON.stringify(postData),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function () {
            alert("Thêm mới API thành công!");
            GetFilter();
            $("#BtnReset").click();
            //GetData();
        },
        error: function () {
            alert("Thêm mới tin bài thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
});

function GetFilter() {
    var filter = {};
    filter.FilterText = $("#FilterText").val();
    filter.APITypeId = $("#MainContent_ListAPITypeOutter").val();
    filter.PageNumber = 1;
    filter.PageSize = 10;

    $.ajax({
        url: "/api/v1/API/filter?filterString=" + JSON.stringify(filter),
        method: "GET",
        contentType: "json",
        //headers: {
        //    'Accept': 'application/json',
        //    'Content-Type': 'application/json'
        //},
        success: function (data) {
            $("#table-body").html("");
            if (data.length == 0) {
                $("#table-body").html("<tr><td class='text-center' colspan='6'>Không có dữ liệu</td></tr>");
                return;
            }

            for (var i = 0; i < data.length; i++) {
                var color = "red";
                var title = "Mở khóa API";
                var modal = "#myModal1";
                if (data[i].IsActive) {
                    color = "green";
                    title = "Khóa API";
                    var modal = "#myModal2";
                }

                $("#table-body").append("<tr>"
                    + "<td class='text-center'>"
                    + "<input type='checkbox' onclick value='" + data[i].APIId + "' class='multiSelect'>"
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].APITypeName
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].APICode
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].Name
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].Price
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].DurationText
                    + "</td>"
                    + "<td class='text-center'>"
                    + "<button type='button' onclick='Edit(this)' value='" + data[i].NewsId + "' data-toggle='modal' data-target='#exampleModal2' style='background-color:deepskyblue;width:28px;height:28px;padding:4px;margin:5px' class='btn'><i style='font-size:20px;color:white' class='fa fa-edit'></i></button>"
                    + "<button type='button' onclick='PrepareLock(this)' data-toggle='modal' data-target='" + modal + "' value='" + data[i].NewsId + "' style='background-color:" + color + ";width:28px;height:28px;padding:4px;' class='btn' title='" + title + "'><i style='font-size:20px;color:white' class='fa fa-key'></i></button>"
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
}

var LockId = null;
function PrepareLock(btn) {
    LockId = btn.value;
}

function ToggleLock() {
    $.ajax({
        url: "/api/v1/API/togglelock/" + LockId,
        method: "PUT",
        contentType: "json",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            if (data.IsActive) {
                alert("Mở khóa API thành công.");
            }
            else {
                alert("Khóa API thành công.");
            }
            console.log("SUCCESS");
        },
        error: function () {
            alert("Mở/Khóa API thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
}