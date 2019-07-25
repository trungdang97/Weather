var RegisterServices = [];

var userid = $("#UserId").val();
var GetTransaction = function () {
    $.ajax({
        url: '/api/v1/API/transaction?userid=' + userid,
        method: "GET",
        dataType: "json",
        success: function (data) {
            //console.log(data);
            $("#Transaction").html("");
            for (var i = 0; i < data.length; i++) {
                $("#Transaction").append("<tr>"
                    + "<td class='text-center'>" + data[i].BillId.toUpperCase() + "</td>"
                    + "<td class='text-center'>" + FormatDateTime(data[i].CreatedOnDate) + "</td>"
                    + "<td class='text-center'>" + data[i].TotalPrice + "&ensp;VND</td>"
                    + "</tr>")
            }
        },
        error: function(){
            alert("Xảy ra lỗi khi lấy lịch sử giao dịch");
        }
    });
};

var GetData = async function () {
    var filter = {};
    filter.UserId = userid;
    filter.PageSize = 10;
    filter.PageNumber = $("#PageNumber").val();
    $.ajax({
        url: "/api/v1/API/list?filterString=" + JSON.stringify(filter),
        method: "GET",
        dataType: "json",
        success: await function (data) {
            console.log(data);
            $("#UsingService").html("");
            for (var i = 0; i < data.length; i++) {
                var status = "";
                var func = null;
                var func1 = "Subscribe(this)";
                var func2 = "Unsubscribe(this)";
                var text = null;
                var text1 = "Gia hạn";
                var text2 = "Hủy dịch vụ";
                var icon = null;
                var icon1 = "<i class='fa fa-plus'></i>";
                var icon2 = "<i class='fa fa-remove'></i>";
                var color = null;
                //var color1 = "green";
                //var color2 = "red";
                var _class = null;
                var class1 = "btn btn-success";
                var class2 = "btn btn-danger";
                if (data[i].IsActive) {
                    status = "Đã đăng ký";
                    func = func2;
                    text = text2;
                    icon = icon2;
                    //color = color2;
                    _class = class2;
                }
                else {
                    status = "Hết hạn";
                    func = func1;
                    text = text1;
                    icon = icon1;
                    //color = color1;
                    _class = class1;
                }
                $("#UsingService").append("<tr>"
                    + "<td class='text-center'>" + data[i].Name + "</td>"
                    + "<td class='text-center'>" + FormatDateTime(data[i].FromDate) + " - " + FormatDateTime(data[i].ToDate) + "</td>"
                    + "<td class='text-center'>" + status + "</td>"
                    + "<td class='text-center'>" + "<button type='button' class='" + _class + "' value='" + data[i].APIId + "' onclick='" + func + "' style='background-color:" + color + "'>" + icon + text + "</button>" + "</td>"
                    + "</tr>");
            }
        },
        error: function () {
            alert("Xảy ra lỗi. Xin hãy thử lại trong ít phút.");
        }
    });
}

var Subscribe = function(btn) {
    var APIId = btn.value;
    var postData = {};
    postData.UserId = $("#UserId").val();
    postData.LstAPI = [];
    postData.LstAPI.push(APIId);

    $.ajax({
        url: "/api/v1/APISubscription/register",
        method: "POST",
        dataType: "json",
        data: postData,
        success: async function (data) {
            await GetData();
            await GetTransaction();
            alert(data);
            
        },
        error: function () {
            alert("Đã xảy ra lỗi khi gian hạn dịch vụ.");
        }
    });
}

var Unsubscribe = function(btn) {
    var APIId = btn.value;
    var postData = {};
    postData.UserId = $("#UserId").val();
    postData.LstAPI = [];
    postData.LstAPI.push(APIId);

    $.ajax({
        url: "/api/v1/APISubscription/unsubscribe",
        method: "POST",
        dataType: "json",
        data: postData,
        success: async function (data) {
            await GetData();
            alert(data);
            
        },
        error: function () {
            alert("Đã xảy ra lỗi khi hủy dịch vụ.");
        }
    });
}

var Services = [];
var SelectedServices = [];
var TotalPrice = 0;

var SelectService = async function (checkbox) {
    if ($(checkbox).prop("checked") == true) {
        var id = checkbox.value;
        var service = {};
        var breaked = false;
        for (var i = 0; i < Services.length; i++) {
            for (var j = 0; j < Services[i].Available.length; j++) {
                if (Services[i].Available[j].APIId == id) {
                    service = Services[i].Available[j];
                    breaked = true;
                    break;
                }
            }
            if (breaked) {
                break;
            }
        }
        SelectedServices.push(service);
        TotalPrice += service.Price;
        //console.log(SelectedServices);
        $("#SelectedServiceList").html("");
        for (var i = 0; i < SelectedServices.length; i++) {
            $("#SelectedServiceList").append("<tr>");
            $("#SelectedServiceList").append("<td class='text-center'><input type='checkbox' checked='checked' onclick='SelectService(this)' class='multiSelect' value='" + SelectedServices[i].APIId + "'></td>");
            $("#SelectedServiceList").append("<td class='text-center'>" + SelectedServices[i].APITypeName + "</td>");
            $("#SelectedServiceList").append("<td>" + SelectedServices[i].Name + "</td>");
            $("#SelectedServiceList").append("<td class='text-center'>" + SelectedServices[i].DurationText + "</td>");
            $("#SelectedServiceList").append("<td class='text-center'>" + SelectedServices[i].Price + "</td>");
            $("#SelectedServiceList").append("</tr>");

        }
    }
    else {
        var id = checkbox.value;
        var service = {};
        var breaked = false;
        for (var i = 0; i < Services.length; i++) {
            for (var j = 0; j < Services[i].Available.length; j++) {
                if (Services[i].Available[j].APIId == id) {
                    service = Services[i].Available[j];
                    breaked = true;
                    break;
                }
            }
            if (breaked) {
                break;
            }
        }
        console.log(SelectedServices);
        SelectedServices = SelectedServices.filter(function (value, index, arr) {
            return value != service;
        });
        console.log(SelectedServices);
        TotalPrice -= service.Price;

        $("#SelectedServiceList").html("");
        for (var i = 0; i < SelectedServices.length; i++) {
            $("#SelectedServiceList").append("<tr>");
            $("#SelectedServiceList").append("<td class='text-center'><input type='checkbox' checked='checked' onclick='SelectService(this)' class='multiSelect' value='" + SelectedServices[i].APIId + "'></td>");
            $("#SelectedServiceList").append("<td class='text-center'>" + SelectedServices[i].APITypeName + "</td>");
            $("#SelectedServiceList").append("<td>" + SelectedServices[i].Name + "</td>");
            $("#SelectedServiceList").append("<td class='text-center'>" + SelectedServices[i].DurationText + "</td>");
            $("#SelectedServiceList").append("<td class='text-center'>" + SelectedServices[i].Price + "</td>");
            $("#SelectedServiceList").append("</tr>");
        }
    }

    $("#TotalPrice").html(TotalPrice);
};

//////////////////////////////////////////////////          CORE        ////////////////////////////////
$(document).ready(async function () {
    await GetServices();
    GetData();
    GetTransaction();
    $("#ServiceList").append("<tr><td colspan='10'>Hãy chọn dịch vụ muốn đăng ký sử dụng  </td></tr>");

    $("#MainContent_ListAPIType").change(function () {
        var id = $("#MainContent_ListAPIType").val();
        $("#ServiceList").html("");
        if (id == null || id == "" || id == undefined) {
            //for (var k = 0; k < Services.length; k++) {
            //    var service = Services[k];
            //    for (var i = 0; i < service.Available.length; i++) {
            //        $("#ServiceList").append("<tr style='padding: 10px 0'>");
            //        $("#ServiceList").append("<td class='text-center'><input type='checkbox' class='multiSelect' value='" + service.Available[i].APIId + "'></td>");
            //        $("#ServiceList").append("<td>" + service.Available[i].Name + "</td>");
            //        $("#ServiceList").append("<td class='text-center'>" + service.Available[i].DurationText + "</td>");
            //        $("#ServiceList").append("<td class='text-center'>" + service.Available[i].Price + "</td>");
            //        $("#ServiceList").append("</tr>");
            //    }
            //}
            $("#ServiceList").append("<tr><td colspan='10'>Hãy chọn dịch vụ muốn đăng ký sử dụng  </td></tr>");
        }
        else {
            var service = Services.find(function (s) {
                return s.Id == id;
            });
            if (service.Available.length == 0) {
                $("#ServiceList").append("<tr><td colspan='10'>Chưa có dữ liệu!</td></tr>")
                return;
            }
            for (var i = 0; i < service.Available.length; i++) {
                $("#ServiceList").append("<tr style='padding: 10px 0'>");

                var exist = (SelectedServices.indexOf(service.Available[i]) > -1);
                if (exist) {
                    $("#ServiceList").append("<td class='text-center'><input type='checkbox' checked='checked' onclick='SelectService(this)' class='multiSelect' value='" + service.Available[i].APIId + "'></td>");
                }
                else {
                    $("#ServiceList").append("<td class='text-center'><input type='checkbox' onclick='SelectService(this)' class='multiSelect' value='" + service.Available[i].APIId + "'></td>");
                }
                $("#ServiceList").append("<td class='text-center'>" + service.Available[i].APITypeName + "</td>");
                $("#ServiceList").append("<td>" + service.Available[i].Name + "</td>");
                $("#ServiceList").append("<td class='text-center'>" + service.Available[i].DurationText + "</td>");
                $("#ServiceList").append("<td class='text-center'>" + service.Available[i].Price + "</td>");
                $("#ServiceList").append("</tr>");
            }
        }
    });

    $("#BtnRegisterReset").click(function () {
        SelectedServices = [];
        TotalPrice = 0;
        $("#MainContent_ListAPIType").val("").change();
        $("#SelectedServiceList").html("");
        $("#TotalPrice").html(TotalPrice);
        $("#exampleModal").modal('hide');
    });

    $("#BtnRegister").click(function () {
        if (SelectedServices.length == 0) {
            alert("Hãy chọn ít nhất một dịch vụ!");
            return;
        }
        var postData = {};
        postData.UserId = $("#UserId").val();
        postData.LstAPI = [];
        for (var i = 0; i < SelectedServices.length; i++) {
            postData.LstAPI.push(SelectedServices[i].APIId);
        }
        $.ajax({
            url: "/api/v1/APISubscription/register",
            method: "POST",
            dataType: "json",
            data: postData,
            success: async function (data) {
                await GetData();
                await GetTransaction();
                alert(data);
            },
            error: function () {
                alert("Đã xảy ra lỗi khi đăng ký.");
            }
        });

        $("#BtnRegisterReset").click();
        GetData();
        GetTransaction();
    });
});

var GetServices = async function () {
    $.ajax({
        url: "/api/v1/APIType?filterText=",
        method: "GET",
        dataType: "json",
        success: await async function (data) {
            for (var i = 0; i < data.length; i++) {
                var service = {};
                service.Id = data[i].APITypeId;
                service.Name = data[i].Name;
                Services.push(service);
            }
            for (var i = 0; i < data.length; i++) {
                await GetFilter(i);
            }
            //console.log(Services);

        },
        error: function () {
            alert("Đã xảy ra lỗi khi lấy dữ liệu.");
        }
    });
};

async function GetFilter(index) {
    var filter = {};
    filter.FilterText = "";
    filter.APITypeId = Services[index].Id;
    //filter.PageSize = 3;
    //filter.PageNumber = $("#PageNumber").val();

    $.ajax({
        url: "/api/v1/API/filter?filterString=" + JSON.stringify(filter),
        method: "GET",
        contentType: "json",
        success: await function (data) {
            console.log("OK DETAIL", data);
            Services[index].Available = data;
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
        M = '0' + (time.getMonth()+1);
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
    var formattedString = d + "/" + M + "/" + time.getFullYear();
    return formattedString;
}

$("#PageNumber").change(function () {
    GetData();
});