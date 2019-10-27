$(function () {
    $("#recommendDialog").dialog({
        autoOpen: false,
        height: 260,
        width: 260,
        modal: true,
        buttons: {
            "Submit": function () {
                var data = {};
                data.businessProfileId = $("#recommendDialog #BusinessProfileId").val();
                data.comment = $("#recommendDialog #Comment").val();
                $.getJSON(
                    '/Recommendation/Recommend', data, function (result, textStatus, jqXHR) {
                        //$("#Recommendations").html(result);
                        //$("#recommendDialog #Comment").val("");
                        window.location.reload();
                    });
                $("#recommendDialog").dialog("close");
            },
            Cancel: function () {
                $("#recommendDialog").dialog("close");
            }
        },
        close: function () {
            $("#recommendDialog").dialog("close");
        }
    });
});

function Recommend() {
    $("#recommendDialog").dialog("open");
}



