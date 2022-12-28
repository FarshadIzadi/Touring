$(document).ready(function () {

    if ($("#fromCountry").val() != null && $("#fromCountry").val() != "") {
        var path = '/api/SearchTours?country=' + $("#fromCountry").val();
        $.ajax({
            type: 'GET',
            url: path,
            success: function (data) {
                console.log(data.data);
                var text = '<option value>Choose a City</option>';
                $.each(data.data, function (i, country) {
                    if (country == $("#selectedFromCity").val()) {
                        text += '<option selected value="' + country + '">' + country + '</option>'
                    } else {
                        text += '<option value="' + country + '">' + country + '</option>'
                    }
                });
                $("#fromCities").empty();
                $("#fromCities").append(text);
            }

        });
    } else {
        $("#fromCities").empty();
        $("#fromCities").append('<option value>Choose a City</option>');
    }

    if ($("#toCountry").val() != null && $("#toCountry").val() != "") {
        var path = '/api/SearchTours?country=' + $("#toCountry").val();
        $.ajax({
            type: 'GET',
            url: path,
            success: function (data) {
                console.log(data.data);
                var text = '<option value>Choose a City</option>';
                $.each(data.data, function (i, country) {
                    if (country == $("#selectedToCity").val()) {
                        text += '<option selected value="' + country + '">' + country + '</option>'
                    } else {
                        text += '<option value="' + country + '">' + country + '</option>'
                    }
                });
                $("#toCities").empty();
                $("#toCities").append(text);
            }

        });
    } else {
        $("#toCities").empty();
        $("#toCities").append('<option value>Choose a City</option>');
    }


    $("#fromCountry").on('change', function () {
        if ($(this).val() != null && $(this).val() != "") {
            var path = '/api/SearchTours?country=' + $(this).val();
            $.ajax({
                type: 'GET',
                url: path,
                success: function (data) {
                    console.log(data.data);
                    var text = '<option value>Choose a City</option>';
                    $.each(data.data, function (i, country) {
                        text += '<option value="' + country + '">' + country + '</option>'
                    });
                    $("#fromCities").empty();
                    $("#fromCities").append(text);
                }

            });
        } else {
            $("#fromCities").empty();
            $("#fromCities").append('<option >Choose a City</option>');
        }
    });

    $("#toCountry").on('change', function () {
        if ($(this).val() != null && $(this).val() != "") {
            var path = '/api/SearchTours?country=' + $(this).val();
            $.ajax({
                type: 'GET',
                url: path,
                success: function (data) {
                    console.log(data.data);
                    var text = '<option value>Choose a City</option>';
                    $.each(data.data, function (i, country) {
                        text += '<option value="' + country + '">' + country + '</option>'
                    });
                    $("#toCities").empty();
                    $("#toCities").append(text);
                }

            });
        } else {
            $("#toCities").empty();
            $("#toCities").append('<option value>Choose a City</option>');
        }
    });

   

});