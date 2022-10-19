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

    $.getJSON('/api/Activity', function (data) {
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
                html: "$" + element.price
            });
            $row.append($item);

            $item = $('<td/>', {
                html: "<div class='btn-group' style='border-radius:5px'><a class='btn btn-warning' href='/Admin/Activity/EditActivity?id=" + element.id + "'>edit</a><a class='btn btn-danger' >Delete</a></div>"
            }); 
            $row.append($item);

            $(tableId + " tbody").append($row);
        });
    });
    //var TableBody = $('<tbody/>', {
    //    'class': 'border',
    //    html: '<tr><td>shoomiz</td><td>shoomiz</td><td>shoomiz</td><td>shoomiz</td></tr>',
    //    click: function () {
    //        alert("clicked the tbody for good!");
    //    }
    //});
    //var tableRow = $('<tr/>');
    //var jsondata = JSON.parse(data);
    //$.each(jsondata.data, function (index, element) {
    //    alert(element.name);
    //});





}


