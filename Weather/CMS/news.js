CKEDITOR.replace('body');
CKEDITOR.replace('body2');

var NewsId = null, FilterText = "", NewsCategoryId = null, TotalPage = null, PageNumber = 1, PageSize = 10, FromDate = null, ToDate = null;
var TotalQuantity = 0;
var SeletedNewsId = [];

$('#imgFile').hide();
$('#imgFile2').hide();
$('#checkImg').click(function () {
    if ($('#imgFile').css("display") == "none") {
        $('#imgFile').show();
        $('#previewImgFile').show();
    }
    else {
        $('#imgFile').hide();
        $('#previewImgFile').hide();
    }
});
$('#checkImg2').click(function () {
    if ($('#imgFile2').css("display") == "none") {
        $('#imgFile2').show();
        $('#previewImgFile2').show();
    }
    else {
        $('#imgFile2').hide();
        $('#previewImgFile2').hide();
    }
});

$('#imgFile').change(function () {
    readURL(this, "#previewImgFile");
    //$('#previewImgFile').attr("src", $('#imgFile').val());
    $('#previewImgFile').show();
});
$('#imgFile2').change(function () {
    readURL(this, "#previewImgFile2");
    //$('#previewImgFile').attr("src", $('#imgFile').val());
    $('#previewImgFile2').show();
});

function readURL(input, imgID) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(imgID).attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
    else if (input.files.length == 0) {
        $(imgID).attr('src', '');
    }
}

var News = {};
async function Edit(EditBtn) {   
    News = {};
    News = await GetNewsById(EditBtn.value);
    if (News.Thumbnail != null) {
        if (!$('#checkImg2').is(":checked")) {
            $('#checkImg2').click();
        }
        $('#previewImgFile2').attr("src", News.Thumbnail);
        //$('#previewImgFile2').show();
    }
    $("#singledatetimepicker2").data("daterangepicker").setStartDate(new Date(News.CreatedOnDate));
    $("#MainContent_ListCategory2").val(News.NewsCategoryId);
    $("#name2").val(News.Name);
    $("#location2").val(News.Location);
    $("#introduction2").val(News.Introduction);
    CKEDITOR.instances.body2.setData(News.Body);
}

function DeleteMultiple() {
    var postData = {};
    postData.SeletedNewsId = SeletedNewsId;
    $.ajax({
        url: "/api/v1/news/add",
        method: "POST",
        contentType: "json",
        data: JSON.stringify(postData),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function () {
            alert("Thêm mới tin bài thành công!");
            $("#BtnReset").click();
            GetData();
        },
        error: function () {
            alert("Thêm mới tin bài thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
    SeletedNewsId = [];
    return;
}

$("#BtnReset").click(function () {
    $('#imgFile').val("");
    $('#previewImgFile').attr("src", "");
    $('#exampleModal').modal('hide');
    $('#MainContent_ListCategory').get(0).selectedIndex = 0;
    $("#name").val("");
    $("#location").val("");
    $("#introduction").val("");
    CKEDITOR.instances.body.setData('');

    GetData();
});

$("#BtnReset2").click(function () {

    $('#exampleModal2').modal('hide');
    $('#MainContent_ListCategory2').get(0).selectedIndex = 0;
    $("#name2").val("");
    $("#location2").val("");
    $("#introduction2").val("");
    CKEDITOR.instances.body2.setData('');

    GetData();
});

$("#FilterText").keyup(function () {
    FilterText = $("#FilterText").val();
    GetData();
});

$("#MainContent_OuterListCategory").change(function () {
    NewsCategoryId = $("#MainContent_OuterListCategory").find(":selected").val();
    GetData();
});

var isValidate = function () {
    if ($("#name").val().replace(' ','') == "") {
        alert("Tên tin bài không được để trống");
        return false;
    }
    if ($("#MainContent_ListCategory").val() == "") {
        alert("Cần chọn loại tin");
        return false;
    }
    if ($("#introduction").val().replace(' ', '') == "") {
        alert("Trích tin không được để trống");
        return false;
    }
    if (CKEDITOR.instances['body'].getData() == "") {
        alert("Nội dung không được để trống");
        return false;
    }
    return true;
};
var isValidate2 = function () {
    if ($("#name2").val().replace(' ', '') == "") {
        alert("Tên tin bài không được để trống");
        return false;
    }
    if ($("#MainContent_ListCategory2").val() == "") {
        alert("Cần chọn loại tin");
        return false;
    }
    if ($("#introduction2").val().replace(' ', '') == "") {
        alert("Trích tin không được để trống");
        return false;
    }
    if (CKEDITOR.instances['body2'].getData() == "") {
        alert("Nội dung không được để trống");
        return false;
    }
    return true;
};

$("#BtnSave").click(function () {
    var postData = {};
    postData.Thumbnail = "";
    if ($('#checkImg').is(":checked")) {
        postData.Thumbnail = $("#previewImgFile").attr("src");
    }
    postData.Name = $("#name").val();
    postData.NewsCategoryId = $("#MainContent_ListCategory").val();
    postData.FinishedDate = null;
    postData.Location = $("#location").val();;
    postData.Introduction = $("#introduction").val();;
    postData.Body = CKEDITOR.instances['body'].getData();
    postData.CreatedByUserId = $("#UserId").val();
    postData.CreatedOnDate = new Date($("#singledatetimepicker").data("daterangepicker").startDate);
    if (isValidate()) {
        $.ajax({
            url: "/api/v1/news/add",
            method: "POST",
            contentType: "json",
            data: JSON.stringify(postData),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            success: function () {
                alert("Thêm mới tin bài thành công!");
                $("#BtnReset").click();
                GetData();
            },
            error: function () {
                alert("Thêm mới tin bài thất bại. Xin hãy kiểm tra lại kết nôi.");
            }
        });
    }
});

$("#BtnSave2").click(function () {
    var postData = {};
    postData = News;
    if ($('#checkImg2').is(":checked")) {
        postData.Thumbnail = $("#previewImgFile2").attr("src");
    }
    else {
        postData.Thumbnail = null;
    }
    postData.Name = $("#name2").val();
    postData.NewsCategoryId = $("#MainContent_ListCategory2").val();
    postData.FinishedDate = null;
    postData.Location = $("#location2").val();;
    postData.Introduction = $("#introduction2").val();;
    postData.Body = CKEDITOR.instances['body2'].getData();
    postData.CreatedOnDate = new Date($("#singledatetimepicker2").data("daterangepicker").startDate);
    if (isValidate2()) {
        $.ajax({
            url: "/api/v1/news/update",
            method: "PUT",
            contentType: "json",
            data: JSON.stringify(postData),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            success: function () {
                alert("Cập nhật tin bài thành công!");
                $("#BtnReset2").click();
                GetData();
            },
            error: function () {
                alert("Cập nhật tin bài thất bại. Xin hãy kiểm tra lại kết nôi.");
            }
        });
    }
});

$(document).ready(function () {
    GetData();
    //FormatDateTime("2019-07-04T18:03:58.2484073");

});

$('input[name="datefilter"]').daterangepicker({
    autoUpdateInput: false,
    locale: {
        cancelLabel: 'Xóa',
        applyLabel: 'Chọn',
        "daysOfWeek": [
            "CN",
            "Hai",
            "Ba",
            "Tư",
            "Năm",
            "Sáu",
            "Bảy"
        ],
        "monthNames": [
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"
        ],
    }
});

$('input[name="datefilter"]').on('apply.daterangepicker', function (ev, picker) {
    FromDate = new Date(picker.startDate._d);
    ToDate = new Date(picker.endDate._d);
    GetData();
    $(this).val(picker.startDate.format('MM/DD/YYYY') + ' - ' + picker.endDate.format('MM/DD/YYYY'));
});

$('input[name="datefilter"]').on('cancel.daterangepicker', function (ev, picker) {
    $(this).val('');
    FromDate = null;
    ToDate = null;
    GetData();
});

function PrepareDelete(buttonClicked) {
    NewsId = buttonClicked.value;
}

function Delete() {
    $.ajax({
        url: "/api/v1/news/delete?NewsId=" + NewsId,
        method: "DELETE",
        contentType: "json",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function () {
            alert("Xóa tin bài thành công!");
            //$("#BtnReset").click();
            GetData();
        },
        error: function () {
            alert("Xóa tin bài thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
}

$("#PageNumber").change(function () {
    GetData();
});

function GetData() {
    var postData = {};
    postData.FilterText = FilterText;
    postData.NewsCategoryId = NewsCategoryId;
    postData.PageNumber = PageNumber;
    postData.PageSize = 10;
    postData.UserId = $("#UserId").val();
    postData.FromDate = FromDate;
    postData.ToDate = ToDate;
    postData.IsCMS = true;

    $.ajax({
        url: "/api/v1/news/filter",
        method: "POST",
        contentType: "json",
        data: JSON.stringify(postData),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            $("#table-body").html("");
            if (data.length == 0) {
                $("#table-body").html("<tr><td class='text-center' colspan='20'>Không có dữ liệu</td></tr>");
                return;
            }

            for (var i = 0; i < data.length; i++) {
                var ApproveStatus = "green";
                if (!data[i].ApproveStatus) {
                    ApproveStatus = "red";
                }
                $("#table-body").append("<tr>"
                    + "<td class='text-center'>"
                    + "<input type='checkbox' onclick value='" + data[i].NewsId + "' class='multiSelect'>"
                    + "</td>"
                    + "<td>"
                    + data[i].Name
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].NewsCategoryName
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].Location
                    + "</td>"
                    + "<td class='text-center'>"
                    + FormatDateTime(data[i].CreatedOnDate)
                    + "</td>"
                    + "<td class='text-center'>"
                    + data[i].Writer
                    + "</td>"
                    + "<td class='text-center'>"
                    + "<button type='button' onclick='ToggleVisible(this)' value='" + data[i].NewsId + "' style='background-color:"+ ApproveStatus +";width:28px;height:28px;padding:4px;margin:5px' class='btn'><i style='font-size:20px;color:white' class='fa fa-eye'></i></button>"
                    + "<button type='button' onclick='Edit(this)' value='" + data[i].NewsId + "' data-toggle='modal' data-target='#exampleModal2' style='background-color:deepskyblue;width:28px;height:28px;padding:4px;margin:5px' class='btn'><i style='font-size:20px;color:white' class='fa fa-edit'></i></button>"
                    + "<button type='button' onclick='PrepareDelete(this)' data-toggle='modal' data-target='#myModal' value='" + data[i].NewsId + "' style='background-color:red;width:28px;height:28px;padding:4px;' class='btn'><i style='font-size:20px;color:white' class='fa fa-trash'></i></button>"
                    + "</td>"
                    + "</tr>"
                );
            }
            //console.log(data);
            //alert("Thêm mới tin bài thành công!");
            //$("#BtnReset").click();
            GetNewsQuantity();
        },
        error: function () {
            alert("Kết nối thất bại. Xin hãy kiểm tra lại kết nôi.");
        }
    });
}

var ToggleVisible = async function (btn) {
    var id = btn.value;
    await $.ajax({
        url: '/api/v1/news/visible?NewsId=' + id,
        method: "PUT",
        contentType: "json",
        success: function (response) {
            alert("Thay đổi trạng thái hiển thị tin bài thành công!");
            GetData();
        }, error: function (response) {
            alert("Có lỗi xảy ra khi kết nối");
        }
    });
}

async function GetNewsById(NewsId) {
    var news = {};
    await $.ajax({
        url: '/api/v1/news?NewsId=' + NewsId,
        method: "GET",
        contentType: "json",
        success: function (data) {
            news = data;
        }, error: function () {
            alert("Có lỗi xảy ra khi kết nối");
        }
    });
    return news;
}

function FormatDateTime(datetime) {
    var time = new Date(datetime);
    var d, M, y, H, m, s;
    if (time.getDate() < 10) {
        d = '0' + time.getDate();
    }
    else {
        d = time.getDate();
    }
    if (time.getMonth() < 10) {
        M = '0' + (time.getMonth() + 1);
    }
    else {
        M = (time.getMonth() + 1);
    }
    if (time.getHours() < 10) {
        H = '0' + time.getHours();
    }
    else {
        H = time.getHours();
    }
    if (time.getMinutes() < 10) {
        m = '0' + time.getMinutes();
    }
    else {
        m = time.getMinutes();
    }
    if (time.getSeconds() < 10) {
        s = '0' + time.getSeconds();
    }
    else {
        s = time.getSeconds();
    }
    var formattedString = d + "/" + M + "/" + time.getFullYear() + "<br/>" + H + ":" + m + ":" + s;
    return formattedString;
}

var GetNewsQuantity = function () {
    $.ajax({
        url: "/api/v1/news/quantity/total?NewsCategoryId=" + NewsCategoryId,
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
    //GetData();

};

var PreviousPage = function () {
    if (PageNumber > 1) {
        previousPage = PageNumber;
        PageNumber--;
        GoToPage(PageNumber);
        //GetData();
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
        GetData();
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