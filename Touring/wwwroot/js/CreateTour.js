$(document).ready(function () {
    $("#countryDropDown select").on('change', function () {
        var url = '/api/CreateTour?country=' + $(this).children('option:selected').val();
        $.getJSON(url, function (data) {
            var text = "";
            $.each(data.data, function (i, e) {
                text += '<option value="' + e + '">' + e + '</option>';
            });

            $("#originCity").empty();
            $("#originCity").append(text);
            console.log(text);
        });

    });


    var iskeydown = false;

    $("#countriesSelect").on('change keydown', function (event) {
        
        if (event.type == 'keydown') {
            if (event.which == 13) {
                event.preventDefault();
                AddCountry($(this));
                iskeydown = false;
            } else {
                iskeydown = true;
            }
        }

        if (event.type == 'change') {
            if (!iskeydown) {
                AddCountry($(this));
            } else {
                iskeydown = false;
            }

        }


    });

    $("#countriesDisplay").on('click', 'a', function (event) {
        event.preventDefault();
        var $par = $(this).parent('div');
        var cName = $par.children('span').text();


        var destCountries = $("#countriesMain").val();
        var finalString = "";
        $.each(destCountries.split(","), function (index, element) {
            if (element != cName) {

                if (finalString != "") {
                    finalString += ",";
                }

                finalString += element;
            }

        });
        $("#countriesMain").val(finalString);

        $("#countriesDisplay").empty();
        if (finalString != "") {

            $.each(finalString.split(","), function (index, element) {
                var $mainDiv = $('<div/>', {
                    html: '<span class="px-1">' + element + '</span><a class="removeButton mx-2 my-0 my-auto" style="color:red;text-decoration:none;cursor:pointer;">x</a>'
                });
                $mainDiv.css({
                    'display': 'inline-block',
                    'margin-right': '15px',
                    'border-radius': '5px',
                    'background-color': '#eeeee4'
                });
                $("#countriesDisplay").append($mainDiv);
            });
        }
        pickCities();


    });



    function AddCountry(item) {
        var destCountries = $("#countriesMain").val();
        if (!(destCountries == "" || destCountries == null)) {
            destCountries += ",";
        }

        if (destCountries.includes(item.children("option:selected").val())) {
            alert("Already added to the list");
        } else {

            destCountries += item.children('option:selected').val();
            $("#countriesMain").val(destCountries);
            $("#countriesDisplay").empty();
            $.each(destCountries.split(","), function (index, element) {
                var $mainDiv = $('<div/>', {
                    html: '<span class="px-1">' + element + '</span><a class="removeButton mx-2 my-0 my-auto" style="color:red;text-decoration:none;cursor:pointer;">x</a>'
                });
                $mainDiv.css({
                    'display': 'inline-block',
                    'margin-right': '15px',
                    'border-radius': '5px',
                    'background-color': '#eeeee4',
                    'margin-bottom': '5px'
                });
                $("#countriesDisplay").append($mainDiv);
            });

        }
        pickCities();
    }

    function pickCities() {
        $.ajax({
            type: 'POST',
            url: '/api/CreateTour',
            data: JSON.stringify($("#countriesMain").val()),
            contentType: 'application/Json',
            success: function (data) {

                var text = "";
                $.each(data.data, function (i, country) {
                    $.each(country.cities, function (j, city) {
                        text += '<option value="' + city + '">' + city + ' (' + country.country + ')</option>'
                    });
                });
                $("#citiesSelect").empty();
                $("#citiesSelect").append(text);
            }
        });
    }



    var iscitykeydown = false;
    $("#citiesSelect").on('change keydown', function (event) {
        if (event.type == 'keydown') {
            if (event.which == 13) {
                event.preventDefault();
                AddCity($(this));
                iscitykeydown = false;
            } else {
                iscitykeydown = true;
            }
        }

        if (event.type == 'change') {
            if (!iscitykeydown) {
                AddCity($(this));
            } else {
                iscitykeydown = false;
            }

        }

    });

    function AddCity(item) {
        var destCities = $("#citiesMain").val();
        if (!(destCities == "" || destCities == null)) {
            destCities += ",";
        }

        if (destCities.includes(item.children("option:selected").val())) {
            alert("Already added to the list");
        } else {

            destCities += item.children('option:selected').val();
            $("#citiesMain").val(destCities);
            $("#citiesDisplay").empty();
            $.each(destCities.split(","), function (index, element) {
                var $mainDiv = $('<div/>', {
                    html: '<span class="px-1">' + element + '</span><a class="removeButton mx-2 my-0 my-auto" style="color:red;text-decoration:none;cursor:pointer;">x</a>'
                });
                $mainDiv.css({
                    'display': 'inline-block',
                    'margin-right': '15px',
                    'border-radius': '5px',
                    'background-color': '#eeeee4',
                    'margin-bottom' : '5px'
                });
                $("#citiesDisplay").append($mainDiv);
            });

        }
    }

    $("#citiesDisplay").on('click', 'a', function (event) {
        event.preventDefault();
        var $par = $(this).parent('div');
        var cName = $par.children('span').text();


        var destCities = $("#citiesMain").val();
        var finalString = "";
        $.each(destCities.split(","), function (index, element) {
            if (element != cName) {

                if (finalString != "") {
                    finalString += ",";
                }

                finalString += element;
            }

        });
        $("#citiesMain").val(finalString);

        $("#citiesDisplay").empty();
        if (finalString != "") {

            $.each(finalString.split(","), function (index, element) {
                var $mainDiv = $('<div/>', {
                    html: '<span class="px-1">' + element + '</span><a class="removeButton mx-2 my-0 my-auto" style="color:red;text-decoration:none;cursor:pointer;">x</a>'
                });
                $mainDiv.css({
                    'display': 'inline-block',
                    'margin-right': '15px',
                    'border-radius': '5px',
                    'background-color': '#eeeee4'
                });
                $("#citiesDisplay").append($mainDiv);
            });
        }
        


    });



});