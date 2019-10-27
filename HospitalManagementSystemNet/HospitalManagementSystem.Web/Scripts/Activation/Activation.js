function Activation(businessProfileId, categoryId) {
    $.ajax({
        method: "POST",
        url: "/BusinessProfile/Activation",
        data: { businessProfileId: businessProfileId }
    })
  .done(function (msg) {
      var url = window.location.pathname;
      $("#Activation" + businessProfileId).html(msg);

      if (url == "/Browse/Index" && msg == "Activate") {
          $("#BusinessProfileId" + businessProfileId).remove();
          var businessProfiles = $('[data-business-profile="true"]');
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

          if (businessProfiles == undefined || businessProfiles == null || businessProfiles.length < 1)
          {
              window.location = url;
          }
      }
  });
}



