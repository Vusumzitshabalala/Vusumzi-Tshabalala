function like() {
    var data = {};
    data.businessProfileId = $("#recommendModal #BusinessProfileId").val();
    $.getJSON(
        '/Recommendation/Like', data, function (result, textStatus, jqXHR) {
            //$("#Recommendations").html(result);
            //$("#recommendDialog #Comment").val("");
            window.location.reload();
        });
}

function unlike() {
    var data = {};
    data.businessProfileId = $("#recommendModal #BusinessProfileId").val();
    $.getJSON(
        '/Recommendation/Unlike', data, function (result, textStatus, jqXHR) {
            //$("#Recommendations").html(result);
            //$("#recommendDialog #Comment").val("");
            window.location.reload();
        });
}