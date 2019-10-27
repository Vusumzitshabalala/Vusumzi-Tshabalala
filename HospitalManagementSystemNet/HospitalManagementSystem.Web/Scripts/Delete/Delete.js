function prepareDelete(businessProfileId, categoryId) {
    $("#deleteBusinessProfileDialog #BusinessProfileId").val(businessProfileId);
    $("#deleteBusinessProfileDialog #CategoryId").val(categoryId);
}

function deleteBusinessProfile() {
    data = {};
    data.businessProfileId = $("#deleteBusinessProfileDialog #BusinessProfileId").val();
    var categoryId = $("#deleteBusinessProfileDialog #CategoryId").val();
    $.ajax({
        method: "POST",
        url: "/BusinessProfile/Delete",
        data: data
    })
      .done(function (msg) {
          var url = window.location.pathname;

          if (msg.toString().toLowerCase() == "true") {
              $("#BusinessProfileId" + data.businessProfileId).remove();

              var businessProfiles = $('[data-business-profile="true"]');
              var resultsFound = businessProfiles.length;

              $("#resultFound").html(resultsFound.toString() + " business profile(s) found.");

              var categoryIds = $('[data-business-profile-category="' + categoryId + '"]');

              if (categoryIds == undefined || categoryIds == null || categoryIds.length < 1) {
                  var categoryIdControl = $("#CategoryId" + categoryId);
                  var containerCategoryIdControl = $("#divCategoryId" + categoryId);

                  if (categoryIdControl != undefined && categoryIdControl != null && categoryIdControl.length > 0) {
                      categoryIdControl.remove();
                  }

                  if (containerCategoryIdControl != undefined && containerCategoryIdControl != null && containerCategoryIdControl.length > 0) {
                      containerCategoryIdControl.remove();
                  }
              }
              else {
                  $("#categoryResultsCount" + categoryId).html(categoryIds.length);
              }

              if (businessProfiles == undefined || businessProfiles == null || businessProfiles.length < 1) {
                  window.location = url;
              }
          }

          $('#deleteBusinessProfileDialog').modal('hide');
      });
}



