$(document).ready(function () {
    //var divide = 100/7+'%';
    //$(".day-segment").css('background-color','red');

    CreateDate();
    AppendDate();
    GetTime();
    GetCurrentTime();
    $('#progressBar').attr('max', Times);

    $('#progressBar').click(function (e) {
        var x = e.pageX - this.offsetLeft
        clickedValue = x / this.offsetWidth;
        ConvertTimesToDateTime();
        GetTime();
        $("#progressBar").val(PickedTime);
    });

    $('#progressBar').mousemove(function (e) {
        var x = e.pageX - this.offsetLeft, tooltipValue = x / this.offsetWidth;
        if (tooltipValue > 0) {

        }
    });

    $('[data-toggle="tooltip"]').tooltip();
});

var Times = 168;
var clickedValue = 0;
var CurrentTime;
var PickedTime;

var Days = [];
var Dates = [];

var ConvertTimesToDateTime = function () {
    var date = Math.floor(clickedValue * 7);
    $("#date").html(Dates[date] + '/' + (new Date().getMonth() + 1) + '/' + new Date().getFullYear());
};

var CreateDate = function () {
    currentDate = new Date();
    for (var i = 0; i < 7; i++) {
        var name = "";
        var date = currentDate.addDays(i).getDate();
        var day = currentDate.getDay() + i;
        Dates.push(date);
        if (day >= 7) day -= 7;
        switch (day) {
            case 0:
                name = "Chủ Nhật " + date;
                break;
            case 1:
                name = "Thứ Hai " + date;
                break;
            case 2:
                name = "Thứ Ba " + date;
                break;
            case 3:
                name = "Thứ Tư " + date;
                break;
            case 4:
                name = "Thứ Năm " + date;
                break;
            case 5:
                name = "Thứ Sáu " + date;
                break;
            case 6:
                name = "Thứ Bảy " + date;
                break;
        }
        Days.push(name);
    }
};

var AppendDate = function () {
    for (var i = 0; i < 7; i++) {
        $("#DateBar").append('<div class="day-segment text-center">' + Days[i] + '</div>');
    }

};

var GetTime = function () {
    var time = Math.floor(clickedValue * 7 * 24);
    var hour = time % 24;
    PickedTime = Math.floor(clickedValue * 7 * 24);
    var string = hour + ':00';
    if(hour < 10){
        string = '0'+string;
    }
    $("#time").html(string);
};

var GetCurrentTime = function(){
    var time = new Date();
    CurrentTime = time.getHours();
    $("#progressBar").val(CurrentTime);
    $("#date").html(time.getDate() + '/' + (time.getMonth()+1) + '/' + time.getFullYear());
    var string = CurrentTime + ':00';
    if(CurrentTime < 10){
        string = '0'+string;
    }
    $("#time").html(string);
};

Date.prototype.addDays = function (days) {
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
}