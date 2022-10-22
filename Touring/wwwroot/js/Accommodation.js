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

    $.getJSON('/api/Accommodation', function (data) {
        console.log(data.data[0]);
        jsonString = data;

        $.each(data.data, function (index, element) {
            var $row = $('<tr/>');
            var $item = $('<td/>', {
                html: element.name
            });
            $row.append($item);

            $item = $('<td/>', {
                html: element.city + " (" + element.country + ")"
            });
            $row.append($item);

            $item = $('<td/>', {
                html: "$" + element.contactName
            });
            $row.append($item);

            $item = $('<td/>', {
                html: "$" + element.phoneNumber
            });
            $row.append($item);


            $item = $('<td/>', {
                html: "$" + element.price
            });
            $row.append($item);

            $item = $('<td/>', {
                html: "<div class='btn-group' style='border-radius:5px'><a class='btn btn-warning' href='/Admin/Accommodation/Edit?id=" + element.id + "'>edit</a><a class='btn btn-danger' href='/Admin/Accommodation/Delete?id=" + element.id + "'>Delete</a></div>"
            }); 
            $row.append($item);

            $(tableId + " tbody").append($row);
        });
    });

}


