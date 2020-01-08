var PageNumber = 1, PageSize = 10, TotalPage = null, TotalQuantity = null;

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
    postData.PageSize = PageSize;
    postData.PageNumber = PageNumber;

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
            //GetFilter();
        },
        error: function () {
            alert("Thêm mới tin bài thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
});

$("#PageNumber").change(function () {
    GetFilter();
});

function GetFilter() {
    var filter = {};
    filter.FilterText = $("#FilterText").val();
    filter.APITypeId = $("#MainContent_ListAPITypeOutter").val();
    filter.PageNumber = PageNumber;
    filter.PageSize = PageSize;

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
                    //+ "<input type='checkbox' onclick value='" + data[i].APIId + "' class='multiSelect'>"
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
            GetAPIQuantity();
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

var GetAPIQuantity = function () {
    $.ajax({
        url: "/api/v1/API/quantity",
        dataType: "json",
        method: "GET",
        success: function (data) {
            TotalQuantity = data;
            if (data % PageSize == 0) {
                TotalPage = data / PageSize;
            }
            else {
                TotalPage = Math.floor(data / PageSize + 1);
            }
            $("#TotalPage").html(TotalPage);
            $("#PageNumber").val(PageNumber);
            Pagination();
        },
        error: function (response) {
            console.log(response);
        }
    });
};
//PAGINATION
var NextPage = function () {
    previousPage = PageNumber;
    PageNumber++;
    GoToPage(PageNumber);
    //GetFilter();

};

var PreviousPage = function () {
    if (PageNumber > 1) {
        previousPage = PageNumber;
        PageNumber--;
        GoToPage(PageNumber);
        //GetFilter();
        //window.scrollTo(0, 0); 
    }
};

$("#NextPage").click(function () {
    NextPage();
});

$("#PreviousPage").click(function () {
    PreviousPage();
});
var Pagination = function () {
    $("#Pages").html("");
    var show = 5;
    //var totalPages = Math.floor(TotalQuantity / Filter.PageSize < 5);
    //if (TotalQuantity / Filter.PageSize < 5) {
    //    show = Math.floor(TotalQuantity / 10 + 1);
    //}
    if ((Math.floor(TotalQuantity / PageSize + 1)) < show) {
        show = Math.floor(TotalQuantity / PageSize + 1);
    }
    if (PageNumber < 3) {
        for (var i = 1; i <= show; i++) {
            if (i == PageNumber) {
                $("#Pages").append("<button class='btn-primary' onclick='GoToPage(" + i + ")' type='button'>" + i + "</button>");
            }
            else {
                $("#Pages").append("<button onclick='GoToPage(" + i + ")' type='button'>" + i + "</button>");
            }
        }
    }
    else {
        for (var i = -2; i < show - 2; i++) {
            if (i == 0) {
                $("#Pages").append("<button class='btn-primary' onclick='GoToPage(" + (parseInt(PageNumber) + i) + ")' type='button'>" + (PageNumber + i) + "</button>");
            }
            else {
                $("#Pages").append("<button onclick='GoToPage(" + (parseInt(PageNumber) + i) + ")' type='button'>" + (PageNumber + i) + "</button>");
            }
        }
    }
};

var GoToPage = function (pageNumber) {
    if (pageNumber <= TotalPage) {
        previousPage = PageNumber;
        PageNumber = pageNumber;
        GetFilter();
    }
    else {
        alert("Không còn tin cũ hơn. Trang cuối là trang " + TotalPage);
        PageNumber = TotalPage;
        $("#PageNumber").val(PageNumber);
    }
};

$("#PageNumber").keyup(function (e) {
    PageNumber = parseInt($("#PageNumber").val());
    if (e.keyCode == 13) {
        GoToPage(PageNumber);
    }
});
