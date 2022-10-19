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

    $.getJSON('/api/User', function (data) {
        console.log(data.data[0]);
        jsonString = data;

        $.each(data.data, function (index, element) {
            var $row = $('<tr/>');
            var $item = $('<td/>', {
                html: element.fullName
            });
            $row.append($item);

            var $item = $('<td/>', {
                html: "roels here"
            });
            $row.append($item);

            var $item = $('<td/>', {
                html: element.email
            });
            $row.append($item);

            $item = $('<td/>', {
                html: function () {
                    if (element.phoneNumber == null) { return "not registered"; } else { return element.phoneNumber; }}
            });
            $row.append($item);

            $item = $('<td/>', {
                html: "<div class='btn-group' style='border-radius:5px'><a class='btn btn-warning' href='/Admin/Activity/EditActivity?id=" + element.id + "'>edit</a><a class='btn btn-danger' >Delete</a></div>"
            }); 
            $row.append($item);

            $(tableId + " tbody").append($row);
        });
    });

}


