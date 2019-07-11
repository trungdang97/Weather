$(document).ready(function () {
    startTime();
});
function startTime() {
    var today = new Date();
    var H = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    var d = today.getDate();
    var M = today.getMonth();
    var y = today.getFullYear();

    var timezone = today.getTimezoneOffset() / 60 * (-1);
    if (timezone > 0) {
        timezone = '(GMT+' + timezone + ')';
    }
    $('#basicDateTime').html(getDayOfWeek() + ', ' + checkTime(d) + "/" + checkTime(M) + "/" + checkTime(y) + ', ' + checkTime(H) + ":" + checkTime(m) + ' ' + timezone);
    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) {
        return '0' + i;
    }
    return i;
}

function getDayOfWeek() {
    var d = new Date().getDay();
    switch (d) {
        case 0:
            return 'Chủ Nhật';
        case 1:
            return 'Thứ Hai';
        case 2:
            return 'Thứ Ba';
        case 3:
            return 'Thứ Tư';
        case 4:
            return 'Thứ Năm';
        case 5:
            return 'Thứ Sáu';
        case 6:
            return 'Thứ Bảy';
    }
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
    var formattedString = d + "/" + M + "/" + time.getFullYear() + " lúc " + H + ":" + m + ":" + s;
    return formattedString;
}