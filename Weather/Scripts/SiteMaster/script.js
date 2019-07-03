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
            return 'Thứ Hai';
        case 1:
            return 'Thứ Ba';
        case 2:
            return 'Thứ Tư';
        case 3:
            return 'Thứ Năm';
        case 4:
            return 'Thứ Sáu';
        case 5:
            return 'Thứ Bảy';
        case 6:
            return 'Chủ Nhật';
    }
}