var dt = new Date().getDate();
var cmonth = new Date().getMonth() + 1;
var cyear = new Date().getFullYear();
var dim = $("#dayinMonth").val();
var startDay = $("#startDay").val();
var currentMonth = $(".currentMonth").val();
var selectedDate = null;

$(document).ready(function () {

    $("#app-Timestart").timepicker({ timeFormat: 'H:mm' }).css("z-index", 20).val("12:00");
    $("#app-Timeend").timepicker({ timeFormat: 'H:mm' }).css("z-index", 20).val("12:00");

    var currentYear = $("#currentYear").val();

    calendar();

    $("#addAppointment-wrapper").hide();
    $(".calendar-days").hover(function () {
        $(this).addClass("hover");
    },function () {
        $(this).removeClass("hover");
    });
    var divToShow = $("#addAppointment-wrapper");

    //Calendar popup
    $(".calendar-days").click(function () {
        selectedDate = currentYear + "/" + currentMonth + "/" + $(this).text();

        $("#post-date").val(selectedDate);
        $('posted-date').val(selectedDate);

        
        var destination = $(this).offset();
        var innerAppointmentText = $("#appointment-text").val();

        divToShow.css({
            color: "#454545",
            display: "block",
            position: "absolute",
            left: destination.left,
            top: destination.top - 190
        });
        var ListDiv = $("#message-list");
        $.ajax({
            url: "/Calendar/GetUserMessage",
            type: "post",
            data: { selectDate: selectedDate},
            success: function (response) {
                if (response != 0) {
                    //$("#create-appointment").hide();
                    $("#edit-appointment").show();

                    $.each(response, function (index, item) {
                        $("#AppointmentMessage").val(item.Message);
                    })
                }
                else {

                    $("#AppointmentMessage").val('');
                    $("#edit-appointment").hide();
                    //$("#create-appointment").show();
                }
            },
            error: function()
            {
                alert("fel" + status);
                
            }
        });
    });

    $("#close-appointment").click(function () {
        var ap = $("#app-Timeend").val();
        alert(ap);
        divToShow.css({
            display:"none"
        });
    });


});

//Create calendar

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

