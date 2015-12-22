var dt = new Date().getDate();
var cmonth = new Date().getMonth() + 1;
var cyear = new Date().getFullYear();
var dim = $("#dayinMonth").val();
var startDay = $("#startDay").val();
var currentMonth = $(".currentMonth").val();
var selectedDate = null;

$(document).ready(function () {
    var currentYear = $("#currentYear").val();

    calendar();
    $("#addAppointment-wrapper").hide();
    $(".calendar-days").hover(function () {
        $(this).addClass("hover");
    },function () {
        $(this).removeClass("hover");
    });

    $(".calendar-days").click(function () {
        selectedDate = currentYear + "/" + currentMonth + "/" + $(this).text();
        $("#post-date").val(selectedDate);
        //$(this).css("background-color", "#006666")
        //$(this).css("color", "#FFFFFF")
        var destination = $(this).offset();
        var divToShow = $("#addAppointment-wrapper");
        divToShow.css({
            color: "#454545",
            display: "block",
            position: "absolute",
            left: destination.left,
            top: destination.top - 140
        });
    });

    //$("#addAppointment").click(function () {

    //    var message = $("#appointment-text").val();

    //    $.ajax({
    //        type: "Post",
    //        url: "Calendar/Appointment",
    //        contentType: "application/json; charset=utf-8",
    //        data: {
    //            Message: message,
    //            Date: selectedDate
    //        },
    //        dataType: "json",
    //        success: function (result) {
    //            alert(result + "send!");
    //        },
    //        error: function (result) {
    //            alert("ett fel" + result);
    //        }

    //    });
    //});

});


function calendar() {

    for (var i = 1; i <= dim; i++) {
        if (startDay > 1) {
            $("#calendar-content").append('<div class="calendar-days-empty"></div>');
            startDay--;
            i--;
        }
        else {

            if (i == dt && cmonth == currentMonth) {
                $("#calendar-content").append('<div class="calendar-days active-day">' + i + ' </div>');
            }

            else {
                $("#calendar-content").append('<div class="calendar-days">' + i + ' </div>');
            }
        }
    }
}

