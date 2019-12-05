//COMMON
var PageSize = 10, PageNumber = 1, TotalPage = null, TotalQuantity = null;

$(document).ready(function () {
    GetNewsCategory();
});

type = [];
type["CM"] = "Chuyên mục";
type["TT"] = "Tin tức";

var isCreated = true;
var globalId = null;

var NewsCategory_GetQuantity = function () {
    $.ajax({
        url: "/api/v1/newscategory/quantity",
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
            $("#NewsCategory_TotalPage").html(TotalPage);
            $("#NewsCategory_PageNumber").val(PageNumber);
            NewsCategory_Pagination();
        },
        error: function (response) {
            console.log(response);
        }
    });
};
//PAGINATION
var NewsCategory_NextPage = function () {
    previousPage = PageNumber;
    PageNumber++;
    NewsCategory_GoToPage(PageNumber);
    //GetData();

};

var NewsCategory_PreviousPage = function () {
    if (PageNumber > 1) {
        previousPage = PageNumber;
        PageNumber--;
        NewsCategory_GoToPage(PageNumber);
        //GetData();
        //window.scrollTo(0, 0); 
    }
};

$("#NewsCategory_NextPage").click(function () {
    NewsCategory_NextPage();
});

$("#NewsCategory_PreviousPage").click(function () {
    NewsCategory_PreviousPage();
});
var NewsCategory_Pagination = function () {
    $("#NewsCategory_Pages").html("");
    var show = 5;
    //var totalPages = Math.floor(TotalQuantity / Filter.PageSize < 5);
    //if (TotalQuantity / Filter.PageSize < 5) {
    //    show = Math.floor(TotalQuantity / 10 + 1);
    //}
    if ((Math.floor(TotalQuantity / PageSize + 1)) < show) {
        if (TotalQuantity % PageSize == 0) {
            show = TotalQuantity / PageSize;
        }
        else {
            show = Math.floor(TotalQuantity / PageSize + 1);
        }
    }
    if (PageNumber < 3) {
        for (var i = 1; i <= show; i++) {
            if (i == PageNumber) {
                $("#NewsCategory_Pages").append("<button class='btn-primary' onclick='NewsCategory_GoToPage(" + i + ")' type='button'>" + i + "</button>");
            }
            else {
                $("#NewsCategory_Pages").append("<button onclick='NewsCategory_GoToPage(" + i + ")' type='button'>" + i + "</button>");
            }
        }
    }
    else {
        for (var i = -2; i < show - 2; i++) {
            if (i == 0) {
                $("#NewsCategory_Pages").append("<button class='btn-primary' onclick='NewsCategory_GoToPage(" + (parseInt(PageNumber) + i) + ")' type='button'>" + (PageNumber + i) + "</button>");
            }
            else {
                $("#NewsCategory_Pages").append("<button onclick='NewsCategory_GoToPage(" + (parseInt(PageNumber) + i) + ")' type='button'>" + (PageNumber + i) + "</button>");
            }
        }
    }
};

var NewsCategory_GoToPage = function (pageNumber) {
    if (pageNumber <= TotalPage) {
        previousPage = PageNumber;
        PageNumber = pageNumber;
        GetNewsCategory();
        NewsCategory_Pagination();
    }
    else {
        alert("Không còn bản ghi cũ hơn. Trang cuối là trang " + TotalPage);
        PageNumber = TotalPage;
        $("#NewsCategory_PageNumber").val(PageNumber);
    }
};

$("#NewsCategory_PageNumber").keyup(function (e) {
    PageNumber = parseInt($("#NewsCategory_PageNumber").val());
    if (e.keyCode == 13) {
        NewsCategory_GoToPage(PageNumber);
    }
});

//JS for NewsCategory
$("#NewsCategorySelectAll").click(function () {
    if ($("#NewsCategorySelectAll").is(":checked")) {
        $(".newsCategoryMultiSelect").prop("checked", true);
    }
    else {
        $(".newsCategoryMultiSelect").prop("checked", false);
    }
});
$("#NewsCategory_BtnReset").click(function () {
    $('#NewsCategoryModal').modal('hide');
    $("#NewsCategory_Name").val('');
    $("#NewsCategory_Description").val('');
    $("#NewsCategory_Order").val('')
});
$("#NewsCategory_BtnSave").click(function () {
    if (isCreated) {
        CreateNewsCategory();
    }
    else {
        UpdateNewsCategory();
    }
});
$("#NewsCategory_Type").change(function () {
    var type = $("#NewsCategory_Type").val();
    if (type == "CM") {
        $("#NewsCategory_Order_Group").hide();
    }
    else {
        $("#NewsCategory_Order_Group").show();
    }
})
$("#NewsCategoryCreate").click(function () {
    isCreated = true;
});

var GetNewsCategory = function () {
    $.ajax({
        url: "/api/v1/newscategory",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $("#newscatergory-table-body").html("");
            if (data.length == 0) {
                $("#table-body").html("<tr><td class='text-center' colspan='20'>Không có dữ liệu</td></tr>");
                return;
            }
            var start = (PageNumber - 1) * PageSize;
            for (var i = start; i < start + PageSize; i++) {
                $("#newscatergory-table-body").append("<tr>"
                    + "<td class='text-center'>"
                    + "<input type='checkbox' onclick value='" + data[i].NewsCategoryId + "' class='newsCategoryMultiSelect'>"
                    + "</td>"
                    + "<td>"
                    + data[i].Name
                    + "</td>"
                    + "<td class='text-center'>"
                    + type[data[i].Type]
                    + "</td>"
                    + "<td class='text-center'>"
                    + ((data[i].Order == null) ? "Không" : data[i].Order)
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].Description
                    + "</td>"
                    //+ "<td class='text-center'>"
                    //+ data[i].Writer
                    //+ "</td>"
                    + "<td class='text-center'>"
                    + "<button type='button' onclick='EditNewsCategory(this)' value='" + data[i].NewsCategoryId + "' data-toggle='modal' data-target='#NewsCategoryModal' style='background-color:deepskyblue;width:28px;height:28px;padding:4px;margin:5px' class='btn'><i style='font-size:20px;color:white' class='fa fa-edit'></i></button>"
                    + "<button type='button' onclick='PrepareDeleteNewsCategory(this)' data-toggle='modal' data-target='#myModal' value='" + data[i].NewsCategoryId + "' style='background-color:red;width:28px;height:28px;padding:4px;' class='btn'><i style='font-size:20px;color:white' class='fa fa-trash'></i></button>"
                    + "</td>"
                    + "</tr>"
                );
            }
            NewsCategory_GetQuantity();
        },
        error: function () {

        }
    });
};

var CreateNewsCategory = function () {
    var model = {};
    model.NewsCategoryId = null;
    model.Name = $("#NewsCategory_Name").val();
    if (model.Name.replace(' ', '') == "") {
        alert("Cần nhập tên");
        return;
    }
    model.Type = $("#NewsCategory_Type").val();

    model.Description = $("#NewsCategory_Description").val();
    if (model.Description.replace(' ', '') == "") {
        alert("Cần nhập đường dẫn");
        return;
    }
    if (model.Description.includes(' ')) {
        alert("Đường dẫn không được chứa kí tự trắng");
        return;
    }
    model.Order = parseInt($("#NewsCategory_Order").val());
    if (isNaN(model.Order) && model.Type == "CM") {
        model.Order = null;
    }
    else if (isNaN(model.Order)) {
        alert("Thứ tự không thể là chữ cái")
    }

    $.ajax({
        url: "/api/v1/newscategory/create",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(model),
        success: function (data) {
            alert("Thêm mới loại tin thành công!");
            $("#NewsCategory_BtnReset").click();
            GetNewsCategory();
        },
        error: function (data) {
            alert("Thêm mới loại tin thất bại! Không thể mở kết nối đến máy chủ");
        }
    })


};

var EditNewsCategory = function (btn) {
    globalId = btn.value;
    isCreated = false;
    var model = {};
    $.ajax({
        url: '/api/v1/newscategory/filter?filterString=' + '{NewsCategoryId:"' + globalId + '"}',
        method: "GET",
        dataType: "json",
        success: function (data) {
            model = data[0];
            $('#NewsCategoryModal').modal('show');
            $("#NewsCategory_Name").val(model.Name);
            $("#NewsCategory_Type").val(model.Type);
            $("#NewsCategory_Type").change();
            $("#NewsCategory_Description").val(model.Description);
            $("#NewsCategory_Order").val(model.Order);
        },
        error: function (data) {
            alert("Có lỗi xảy ra khi lấy dữ liệu từ máy chủ");
        }
    });
}
var UpdateNewsCategory = function () {
    var model = {};
    model.NewsCategoryId = globalId;
    model.Name = $("#NewsCategory_Name").val();
    if (model.Name.replace(' ', '') == "") {
        alert("Cần nhập tên");
        return;
    }
    model.Type = $("#NewsCategory_Type").val();

    model.Description = $("#NewsCategory_Description").val();
    if (model.Description.replace(' ', '') == "") {
        alert("Cần nhập đường dẫn");
        return;
    }
    if (model.Description.includes(' ')) {
        alert("Đường dẫn không được chứa kí tự trắng");
        return;
    }
    model.Order = parseInt($("#NewsCategory_Order").val());
    if (isNaN(model.Order) && model.Type == "CM") {
        model.Order = null;
    }
    else if (isNaN(model.Order)) {
        alert("Thứ tự không thể là chữ cái")
    }

    $.ajax({
        url: "/api/v1/newscategory/update",
        method: "PUT",
        contentType: "application/json",
        data: JSON.stringify(model),
        success: function (data) {
            alert("Chỉnh sửa loại tin thành công!");
            $("#NewsCategory_BtnReset").click();
            GetNewsCategory();
            globalId = null;
        },
        error: function (data) {
            alert("Chỉnh sửa loại tin thất bại! Không thể mở kết nối đến máy chủ");
        }
    })

    
};

var PrepareDeleteNewsCategory = function (btn) {
    var id = btn.value;
    if (confirm("Xác nhận xóa thể loại tin?")) {
        DeleteNewsCategory(id);

    }
}

var DeleteNewsCategory = function (id) {
    $.ajax({
        url: "/api/v1/newscategory/delete?id=" + id,
        method: "DELETE",
        success: function (data) {
            alert("Xóa loại tin thành công!");
            GetNewsCategory();
        },
        error: function (data) {
            alert("Xóa loại tin thất bại");
        }
    })
};

//JS for APIType