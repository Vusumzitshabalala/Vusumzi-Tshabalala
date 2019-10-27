var cityCircle;

function initialize() {
    setCurrentPosition();	
}

function setCurrentPosition() {

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
           var pos = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
           setMap("xsmall-map-canvas", pos);
           setMap("map-canvas", pos);
        }, function () {
            var pos = new google.maps.LatLng(-26.2438955, 27.8382714);
            setMap("xsmall-map-canvas", pos);
            setMap("map-canvas", pos);
            handleNoGeolocation(true);
        });
    } else {
        // Browser doesn't support Geolocation
        handleNoGeolocation(false);
    }
}

function setMap(mapId,pos) {
    // Create the map.
    var mapOptions = {
        zoom: 14,
        center: pos,
        mapTypeId: google.maps.MapTypeId.TERRAIN
    };

    var map = new google.maps.Map(document.getElementById(mapId),
		mapOptions);

    // Construct the circle for each value in citymap.
    // Note: We scale the area of the circle based on the population.

    var populationOptions = {
        strokeColor: '#1ab394',
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: '#1ab394',
        fillOpacity: 0.35,
        map: map,
        center: pos,
        radius: 1000
    };
    // Add the circle for this city to the map.
    cityCircle = new google.maps.Circle(populationOptions);
    var marker = new google.maps.Marker({
        position: pos,
        map: map,
        title: 'Your Location'
    });

    var businessProfiles = $('[data-business-profile="true"]');

    if (businessProfiles != undefined && businessProfiles != null && businessProfiles.length > 0) {
        var resultsFound = businessProfiles.length;
        businessProfiles.each(function (index, item)
        {
            var latitude = $(item).attr("data-x");
            var longitude = $(item).attr("data-y");
            var aPos = new google.maps.LatLng(latitude, longitude);

            var distance = google.maps.geometry.spherical.computeDistanceBetween(aPos, pos);
            if (distance <= 1000) {
                var title = $(item).attr("data-business-profile-name")
                var infowindow = new google.maps.InfoWindow({
                    content: title
                });
                var marker1 = new google.maps.Marker({
                    position: aPos,
                    map: map,
                    title: title
                });

                google.maps.event.addListener(marker1, 'hover', function () {
                    infowindow.open(map, marker1);
                });
            }
            else {
                var categoryId = $(item).attr("data-business-profile-category");              
                
                $(item).remove();
                resultsFound--;

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
            }
        });

        $("#resultFound").html(resultsFound.toString() + " business profile(s) found.");
    }

}

google.maps.event.addDomListener(window, 'load', initialize);