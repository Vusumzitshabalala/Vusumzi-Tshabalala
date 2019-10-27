/*function conversate(businessProfileRecommendationId) {
    var selector = "#conversateDialog" + businessProfileRecommendationId;
    initialiseDialog(selector);
    $(selector).dialog("open");
}*/

/*function initialiseDialog(selector) {
    $(selector).dialog({
        autoOpen: false,
        height: 260,
        width: 260,
        modal: true,
        buttons: {
            "Submit": function () {
                var data = {};
                data.businessProfileRecommendationId = $(selector + " #BusinessProfileRecommendationId").val();
                data.comment = $(selector + " #Comment").val();
                $.getJSON(
                    '/Recommendation/Conversate', data, function (result, textStatus, jqXHR) {
                        window.location.reload();
                    });
                $(selector).dialog("close");
            },
            Cancel: function () {
                $(selector).dialog("close");
            }
        },
        close: function () {
            $(selector).dialog("close");
        }
    });
}*/

function postComment(selector) {
    var data = {};
    data.businessProfileRecommendationId = $(selector + " #BusinessProfileRecommendationId").val();
    data.comment = $(selector + " #Comment").val();
  
    $.getJSON(
        '/Recommendation/Conversate', data, function (result, textStatus, jqXHR) {
            window.location.reload();
        });
}



