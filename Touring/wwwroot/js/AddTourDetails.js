$(document).ready(function () {
    $("#detailType").on('change', function (event) {

        $("#finalizeBtn").hide();


        $("#title").val("");

        $("form select").val(null);

        switch ($(this).children("option:selected").val()) {
            case "accommodation":
                $("#detailsForm").attr("hidden", false);
                $("#accommodationInput").attr("hidden", false);
                $("#tripInput").attr("hidden", true);
                $("#activityInput").attr("hidden", true);
                $("#mealInput").attr("hidden", true);
                break;
            case "trip":
                $("#detailsForm").attr("hidden", false);
                $("#accommodationInput").attr("hidden", true);
                $("#tripInput").attr("hidden", false);
                $("#activityInput").attr("hidden", true);
                $("#mealInput").attr("hidden", true);
                break;
            case "activity":
                $("#detailsForm").attr("hidden", false);
                $("#accommodationInput").attr("hidden", true);
                $("#tripInput").attr("hidden", true);
                $("#activityInput").attr("hidden", false);
                $("#mealInput").attr("hidden", true);
                break;
            case "meal":
                $("#detailsForm").attr("hidden", false);
                $("#accommodationInput").attr("hidden", true);
                $("#tripInput").attr("hidden", true);
                $("#activityInput").attr("hidden", true);
                $("#mealInput").attr("hidden", false);
                break;
            default:
                $("#detailsForm").attr("hidden", true);
                break;
        }
    });//#detailType on change



    $("#tripSelect select").on('change', function () {
        $("#title").val($(this).children('option:selected').text());
        if ($(this).val() != null && $(this).val() > 0) {
            $.ajax({
                type: 'POST',
                url: '/api/TourDetailsValidation',
                contentType: 'application/Json',
                data: JSON.stringify("trip," + $(this).val()),
                dataType: 'json',
                success: function (data) {

                    var departureTime = new Date(data.data.departureTime);
                    var dm = departureTime.getMonth() + 1;
                    var depDate = departureTime.getFullYear() + "-" + dm + "-" + departureTime.getDate();
                    $("#startDate").val(depDate);
                    var depTime = (departureTime.getHours() < 10 ? "0" + departureTime.getHours() : departureTime.getHours()) + ":" + (departureTime.getMinutes() < 10 ? "0" + departureTime.getMinutes() : departureTime.getMinutes());
                    $("#startTime").val(depTime);

                    var arrivalTime = new Date(data.data.arrivalTime);
                    var am = arrivalTime.getMonth() + 1;
                    var arrDate = arrivalTime.getFullYear() + "-" + am + "-" + arrivalTime.getDate();
                    $("#endDate").val(arrDate);
                    var arrTime = (arrivalTime.getHours() < 10 ? "0" + arrivalTime.getHours() : arrivalTime.getHours()) + ":" + (arrivalTime.getMinutes() < 10 ? "0" + arrivalTime.getMinutes() : arrivalTime.getMinutes());
                    $("#endTime").val(arrTime);

                    $("#eventPrice").val(data.data.price);
                    $("#recommendations").val(data.data.recommendations);
                    console.log(data);
                }
            });
        }
    });

    $("#accommodationSelect select").on('change', function () {
        $("#title").val("Check-in/Check-out " + $(this).children('option:selected').text());
        if ($(this).val() != null && $(this).val() > 0) {
            $.ajax({
                type: 'POST',
                url: '/api/TourDetailsValidation',
                contentType: 'application/Json',
                data: JSON.stringify("accommodation," + $(this).val()),
                dataType: 'json',
                success: function (data) {
                    console.log(data.data);
                    $("#startDate").val("0000-00-00");
                    $("#startTime").val("00:00");

                    $("#endDate").val("0000-00-00");
                    $("#endTime").val("00:00");

                    $("#eventPrice").val(data.data.price);
                    $("#recommendations").val(data.data.recommendations);
                }
            });
        }
    });

    $("#mealSelect select").on('change', function () {
        $("#title").val($(this).children('option:selected').text());
        $("#title").val("Check-in/Check-out " + $(this).children('option:selected').text());
        if ($(this).val() != null && $(this).val() > 0) {
            $.ajax({
                type: 'POST',
                url: '/api/TourDetailsValidation',
                contentType: 'application/Json',
                data: JSON.stringify("meal," + $(this).val()),
                dataType: 'json',
                success: function (data) {
                    console.log(data.data);
                    $("#startDate").val("0000-00-00");
                    $("#startTime").val("00:00");

                    $("#endDate").val("0000-00-00");
                    $("#endTime").val("00:00");

                }
            });
        }
    });

    $("#activitySelect select").on('change', function () {
        $("#title").val($(this).children('option:selected').text());
        if ($(this).val() != null && $(this).val() > 0) {
            $.ajax({
                type: 'POST',
                url: '/api/TourDetailsValidation',
                contentType: 'application/Json',
                data: JSON.stringify("activity," + $(this).val()),
                dataType: 'json',
                success: function (data) {
                    console.log(data.data);
                    $("#startDate").val("0000-00-00");
                    $("#startTime").val("00:00");

                    $("#endDate").val("0000-00-00");
                    $("#endTime").val("00:00");

                    $("#eventPrice").val(data.data.price);
                    $("#recommendations").val(data.data.recommendations);
                }
            });
        }
    });



});

