$(document).ready(function () {
    $("#detailType").on('change', function (event) {


        switch ($(this).children("option:selected").val()) {
            case "accommodation":
                $("#detailsForm").attr("hidden", false);
                $("#accommodationInput").attr("hidden", false);
                $("#tripInput").attr("hidden", true);
                $("#activityInput").attr("hidden", true);
                break;
            case "trip":
                $("#detailsForm").attr("hidden", false);
                $("#accommodationInput").attr("hidden", true);
                $("#tripInput").attr("hidden", false);
                $("#activityInput").attr("hidden", true);
                break;
            case "activity":
                $("#detailsForm").attr("hidden", false);
                $("#accommodationInput").attr("hidden", true);
                $("#tripInput").attr("hidden", true);
                $("#activityInput").attr("hidden", false);
                break;
            default:
                $("#detailsForm").attr("hidden", true);
                break;
        }
    });
});

