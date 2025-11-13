
$(document).ready(function () {
    $("#testButton").on("click", function () {

        console.log("testButton was clicked.");

        const inputString = $("#inputData").val();

        //const integerData = parseInt($("#integerData").val());
        const integerData = 777;
        //alert("Input data: " + inputString);


        ////works fine
        //var jqxhr = $.get("Home/TestAction", function () {
        //    console.log("* success *");
        //})
        //    .done(function (resultData) {
        //        console.log("** second success **");

        //        varresultString = "Result: \n";
        //        varresultString += "DateTime: " + resultData.date + " " + resultData.time + ";\nData: " + resultData.Data + "\n";

        //        var outputArea = $("#outputArea");
        //        outputArea.val(outputArea.val() + varresultString);
        //})
        //    .fail(function () {
        //        console.error("- error -");
        //})
        //    .always(function () {
        //        console.info("_ finished _");
        //});

        //// Set another completion function for the request above
        //jqxhr.always(function () {
        //    console.info("__ second finished __");
        //});

        $.ajax({
            type: "GET",
            url: "Home/TestAction2/",
            contentType: 'application/json; charset=utf-8',
            data: { inputData: inputString },
            cashe: false,
            datatype: "text",
            success: function (data) {
                console.log('Submission was successful.');
                console.log(data);

                varresultString = "Result: \n";
                varresultString += "DateTime: " + data.date + " " + data.time + ";\nData: " + data.Data + "\n";

                var outputArea = $("#outputArea");
                outputArea.val(outputArea.val() + varresultString);
            },
            error: function (data) {
                console.log('An error occurred.');
                console.log(data);
            },
        });

        $.ajax({
            type: "GET",
            url: "Home/TestAction3/",
            contentType: 'application/json; charset=utf-8',
            data: { strData: inputString, intData: integerData },
            cashe: false,
            datatype: "text",
            success: function (data) {
                console.log('Submission was successful.');
                console.log(data);

                varresultString = "Result: \n";
                varresultString += "DateTime: " + data.Date + " " + data.Time + ";\nInput: " + data.Input.StringData + ", " + data.Input.IntData + "\n";

                var outputArea = $("#outputArea");
                outputArea.val(outputArea.val() + varresultString);
            },
            error: function (data) {
                console.log('An error occurred.');
                console.log(data);
            },
        });



    });



});

