var NewsId = null, FilterText = "", NewsCategoryId = null, PageNumber = null, PageSize = null, FromDate = null, ToDate = null;

var SeletedNewsId = [];

$('input[type="checkbox"]').click(function () {
    if (this.checked) {
        //alert("FUCK");
    }
});

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

    $('#exampleModal').modal('hide');
    $('#MainContent_ListCategory').get(0).selectedIndex = 0;
    $('#ListCategory').val('');
    $("#name").val("");
    $("#location").val("");
    $("#introduction").val("");
    $("#body").val("");
    CKEDITOR.instances.body.setData('');

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

$("#BtnSave").click(function () {
    var postData = {};
    postData.Name = $("#name").val();
    postData.NewsCategoryId = $("#MainContent_ListCategory").val();
    postData.FinishedDate = null;
    postData.Location = $("#location").val();;
    postData.Introduction = $("#introduction").val();;
    //postData.Body = CKEDITOR.instances['body'].getData();
    postData.CreatedByUserId = $("#UserId").val();

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

function GetData() {
    var postData = {};
    postData.FilterText = FilterText;
    postData.NewsCategoryId = NewsCategoryId;
    postData.PageNumber = PageNumber;
    postData.PageSize = PageSize;
    postData.UserId = $("#UserId").val();
    postData.FromDate = FromDate;
    postData.ToDate = ToDate;

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
                $("#table-body").html("<tr><td class='text-center' colspan='6'>Không có dữ liệu</td></tr>");
                return;
            }

            for (var i = 0; i < data.length; i++) {
                $("#table-body").append("<tr>"
                    + "<td class='text-center'>"
                    + "<input type='checkbox' onclick value='"+data[i].UserId+"' class='multiSelect'>"
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
                    + "<button type='button' value='" + data[i].UserId + "' style='background-color:deepskyblue;width:28px;height:28px;padding:4px;margin:5px' class='btn'><i style='font-size:20px;color:white' class='fa fa-edit'></i></button>"
                    + "<button type='button' onclick='PrepareDelete(this)' data-toggle='modal' data-target='#myModal' value='" + data[i].UserId + "' style='background-color:red;width:28px;height:28px;padding:4px;' class='btn'><i style='font-size:20px;color:white' class='fa fa-trash'></i></button>"
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
        M = '0' + time.getMonth();
    }
    else {
        M = time.getMonth();
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