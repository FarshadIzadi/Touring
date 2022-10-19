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
        console.log(data.data);
        jsonString = data;

        $.each(data.data, function (index, element) {
            var $row = $('<tr/>');
            var $item = $('<td/>', {
                html: element.users.fullName
            });
            $row.append($item);

            var rolesStr = "";
            $.each(element.userRoles, function (index, e) {
                rolesStr += e + "</br>";
            });
            var $item = $('<td/>', {
                html: rolesStr
            });
            $row.append($item);

            var $item = $('<td/>', {
                html: element.users.email
            });
            $row.append($item);

            $item = $('<td/>', {
                html: function () {
                    if (element.users.phoneNumber == null) { return "not registered"; } else { return element.users.phoneNumber; }
                }
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


