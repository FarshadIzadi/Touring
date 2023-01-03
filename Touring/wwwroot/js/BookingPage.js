$(document).ready(function () {

    $("#PassengerNum").on('change', function () {
        $("#passengers").empty();
        for (var i = 1; i <= $(this).val(); i++) {
            $("#passengers").append(
                `<div class="row col-12 pt-0">
                <h5 class= "mx-5 fw-bold col-12" >Passenger ${i}</h5 >
            <div class="col-12 row d-flex justify-content-between d-block m-3 mt-0 py-1 round-corners">
                <div class="col-12 col-lg-6">
                    <div class="my-1 mx-1 px-2 bg-white round-corners formFieldShadow">
                        <label class="d-block">First Name</label>
                        <input name="firstName" placeholder="First Name" class="form-control text-center fw-bold"></input>
                    </div>
                </div>
                <div class="col-12 col-lg-6">
                    <div class="my-1 mx-1 px-2 bg-white round-corners formFieldShadow">
                        <label class="d-block">Last Name</label>
                        <input name="lastName" placeholder="Last Name" class="form-control text-center fw-bold"></input>
                    </div>
                </div>

                <div class="col-12 col-lg-6">
                    <div class="my-1 mx-1 px-2 bg-white round-corners formFieldShadow">
                        <label class="d-block">Gender</label>
                        <select name="gender" class="form-select form-control text-center fw-bold"><option value="">Choose Sex</option><option value="female">Female</option><option value="male">Male</option></select>
                    </div>
                </div>
                <div class="col-12 col-lg-6">
                    <div class="my-1 mx-1 px-2 bg-white round-corners formFieldShadow">
                        <label class="d-block">Age</label>
                        <input name="age" placeholder="Enter Age Here" class="form-control text-center fw-bold"></input>
                    </div>
                </div>
                <div class="col-12 col-lg-6">
                    <div class="my-1 mx-1 px-2 bg-white round-corners formFieldShadow">
                        <label class="d-block">Passport Expiration Date</label>
                        <input type="date" name="passExpDate" class="form-control text-center fw-bold"></input>
                    </div>
                </div>
                <div class="col-12 col-lg-6">
                    <div class="my-1 mx-1 px-2 bg-white round-corners formFieldShadow">
                        <label class="d-block">vaccination status</label>
                        <select name="vaccine" class="form-select form-control text-center fw-bold"><option value="">Not Vaccined</option><option value="1">First dose less than two month ago</option><option value="2">Second dose less than two month ago</option><option value="3">Third dose less than two month ago</option></select>
                    </div>
                </div>
            </div>
        </div >`);
        }




    });



    //if ($("#fromCountry").val() != null && $("#fromCountry").val() != "") {
    //    var path = '/api/SearchTours?country=' + $("#fromCountry").val();
    //    $.ajax({
    //        type: 'GET',
    //        url: path,
    //        success: function (data) {
    //            console.log(data.data);
    //            var text = '<option value>Choose a City</option>';
    //            $.each(data.data, function (i, country) {
    //                if (country == $("#selectedFromCity").val()) {
    //                    text += '<option selected value="' + country + '">' + country + '</option>'
    //                } else {
    //                    text += '<option value="' + country + '">' + country + '</option>'
    //                }
    //            });
    //            $("#fromCities").empty();
    //            $("#fromCities").append(text);
    //        }

    //    });
    //} else {
    //    $("#fromCities").empty();
    //    $("#fromCities").append('<option value>Choose a City</option>');
    //}

    //if ($("#toCountry").val() != null && $("#toCountry").val() != "") {
    //    var path = '/api/SearchTours?country=' + $("#toCountry").val();
    //    $.ajax({
    //        type: 'GET',
    //        url: path,
    //        success: function (data) {
    //            console.log(data.data);
    //            var text = '<option value>Choose a City</option>';
    //            $.each(data.data, function (i, country) {
    //                if (country == $("#selectedToCity").val()) {
    //                    text += '<option selected value="' + country + '">' + country + '</option>'
    //                } else {
    //                    text += '<option value="' + country + '">' + country + '</option>'
    //                }
    //            });
    //            $("#toCities").empty();
    //            $("#toCities").append(text);
    //        }

    //    });
    //} else {
    //    $("#toCities").empty();
    //    $("#toCities").append('<option value>Choose a City</option>');
    //}


    //$("#fromCountry").on('change', function () {
    //    if ($(this).val() != null && $(this).val() != "") {
    //        var path = '/api/SearchTours?country=' + $(this).val();
    //        $.ajax({
    //            type: 'GET',
    //            url: path,
    //            success: function (data) {
    //                console.log(data.data);
    //                var text = '<option value>Choose a City</option>';
    //                $.each(data.data, function (i, country) {
    //                    text += '<option value="' + country + '">' + country + '</option>'
    //                });
    //                $("#fromCities").empty();
    //                $("#fromCities").append(text);
    //            }

    //        });
    //    } else {
    //        $("#fromCities").empty();
    //        $("#fromCities").append('<option >Choose a City</option>');
    //    }
    //});

    //$("#toCountry").on('change', function () {
    //    if ($(this).val() != null && $(this).val() != "") {
    //        var path = '/api/SearchTours?country=' + $(this).val();
    //        $.ajax({
    //            type: 'GET',
    //            url: path,
    //            success: function (data) {
    //                console.log(data.data);
    //                var text = '<option value>Choose a City</option>';
    //                $.each(data.data, function (i, country) {
    //                    text += '<option value="' + country + '">' + country + '</option>'
    //                });
    //                $("#toCities").empty();
    //                $("#toCities").append(text);
    //            }

    //        });
    //    } else {
    //        $("#toCities").empty();
    //        $("#toCities").append('<option value>Choose a City</option>');
    //    }
    //});



});