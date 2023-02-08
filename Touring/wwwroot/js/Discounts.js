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

    $.getJSON('/api/Discounts', function (data) {
        console.log(data.data[0]);
        jsonString = data;

        $.each(data.data, function (index, element) {
            var $row = $('<tr/>');
            var $item = $('<td/>', {
                html: element.discount.discountTitle
            });
            $row.append($item);

            $item = $('<td/>', {
                html: "$" + element.discount.discountAmount
            });
            $row.append($item);

            $item = $('<td/>', {
                html: "%" + element.discount.discountPercentage
            });
            $row.append($item);

            var startDate = new Date(element.discount.validFrom);
            var d = startDate.getDate();
            var m = startDate.getMonth() + 1;
            var y = startDate.getFullYear();
            startDate = d + "/" + m + "/" + y;
            $item = $('<td/>', {
                html: startDate
            });
            $row.append($item);


            var endDate = new Date(element.discount.validUntill);
            var d = endDate.getDate();
            var m = endDate.getMonth() + 1;
            var y = endDate.getFullYear();
            endDate = d + "/" + m + "/" + y;
            $item = $('<td/>', {
                html: endDate
            });
            $row.append($item);

            $item = $('<td/>', {
                html: element.users.length
            });
            $row.append($item);

            $item = $('<td/>', {
                html: "<div class='btn-group' style='border-radius:5px'><a class='btn btn-warning' href='/Admin/ManageDiscounts/Create?discountId=" + element.discount.id + "'>edit</a><a class='btn btn-danger' href='/Admin/ManageDiscounts/Delete?id=" + element.discount.id + "'>Delete</a></div>"
            }); 
            $row.append($item);

            $(tableId + " tbody").append($row);
        });
    });

}


