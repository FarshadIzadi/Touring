$(document).ready(function () {



    loadTable("#dataTable");

    $("#dataTable").on('mouseenter mouseleave', 'td', function (event) {
        var mouseentered = event.type == 'mouseenter';
        $(this).toggleClass('bg-black text-white', mouseentered);
    });

});

function loadTable(tableId) {

    $(tableId + " tbody").empty();
    $(tableId).attr('border-radius', '5px');

    $.getJSON('/api/Tour', function (data) {
        jsonString = data;

        $.each(data.data, function (index, element) {
            console.log(element);
            var $row = $('<tr/>');
            var $item = $('<td/>', {
                html: element.tourTitle
            });
            $row.append($item);

            $item = $('<td/>', {
                html: element.originCity + " (" + element.originCountry + ")"
            });
            $row.append($item);

            $item = $('<td/>', {
                html: element.destinationCountries + " (" + element.destinationCountries + ")"
            });
            $row.append($item);


            $item = $('<td/>', {
                html: element.bookingStatus
            });
            $row.append($item);

            $item = $('<td/>', {
                html: "<div class='btn-group' style='border-radius:5px'><a class='btn btn-warning' href='/Admin/Tours/Edit?tourId=" + element.id + "'>Edit</a><a class='btn btn-success' href='/Admin/Tours/CreateTourDetails?tourId=" + element.id + "'>Add Details</a><a class='btn btn-danger' href='/Admin/Tours/Delete?id=" + element.id + "'>Delete</a></div>"
            }); 
            $row.append($item);

            $(tableId + " tbody").append($row);
        });
    });






}


