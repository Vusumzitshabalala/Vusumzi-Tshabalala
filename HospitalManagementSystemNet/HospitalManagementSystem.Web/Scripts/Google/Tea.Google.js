var map;
var mediumMap;
var smallMap;
var xsmallMap;
var markersArray = [];

function initialize() {
    
    var latitude = $("#Latitude").val();
    var longitude = $("#Longitude").val();
    var pos;
    var mapOptions = {
        zoom: 15,
        draggableCursor: 'crosshair'
    };
    map = new google.maps.Map(document.getElementById('map-canvas'),mapOptions);
    mediumMap = new google.maps.Map(document.getElementById('medium-map-canvas'),mapOptions);
    smallMap = new google.maps.Map(document.getElementById('small-map-canvas'),mapOptions);
    xsmallMap = new google.maps.Map(document.getElementById('xsmall-map-canvas'),mapOptions);

    // Try HTML5 geolocation
    if (latitude != undefined && latitude != null && latitude != '' && longitude != undefined && longitude != null && longitude != '') {
        pos = new google.maps.LatLng(latitude, longitude);
        updateMap(map, pos);
        updateMap(mediumMap, pos);
        updateMap(smallMap, pos);
        updateMap(xsmallMap, pos);

        addSearchBox(map, "large-pac-input");
        addSearchBox(mediumMap, "medium-pac-input");
        addSearchBox(smallMap, "small-pac-input");
        addSearchBox(xsmallMap, "xsmall-pac-input");

        addDoubleClickListener(map);
        addDoubleClickListener(mediumMap);
        addDoubleClickListener(smallMap);
        addDoubleClickListener(xsmallMap);
    }
    else {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                pos = new google.maps.LatLng(position.coords.latitude,
                                                 position.coords.longitude);

                /*var infowindow = new google.maps.InfoWindow({
                    map: map,
                    position: pos,
                    content: 'You are are here'
                });*/

                $("#Latitude").val(position.coords.latitude);
                $("#Longitude").val(position.coords.longitude);

                updateMap(map, pos);
                updateMap(mediumMap, pos);
                updateMap(smallMap, pos);
                updateMap(xsmallMap, pos);

                addSearchBox(map, "large-pac-input");
                addSearchBox(mediumMap, "medium-pac-input");
                addSearchBox(smallMap, "small-pac-input");
                addSearchBox(xsmallMap, "xsmall-pac-input");

                addDoubleClickListener(map);
                addDoubleClickListener(mediumMap);
                addDoubleClickListener(smallMap);
                addDoubleClickListener(xsmallMap);

            }, function () {
                handleNoGeolocation(true);
            });
        } else
        {
            // Browser doesn't support Geolocation
            handleNoGeolocation(false);
        }
    }

}

function handleNoGeolocation(errorFlag) {
    if (errorFlag) {
        var content = 'Error: The Geolocation service failed.';
    } else {
        var content = 'Error: Your browser doesn\'t support geolocation.';
    }

    var pos = new google.maps.LatLng(-26.2438955, 27.8382714);

    updateMap(map, pos);
    updateMap(mediumMap, pos);
    updateMap(smallMap, pos);
    updateMap(xsmallMap, pos);

    addSearchBox(map, "large-pac-input");
    addSearchBox(mediumMap, "medium-pac-input");
    addSearchBox(smallMap, "small-pac-input");
    addSearchBox(xsmallMap, "xsmall-pac-input");

    addDoubleClickListener(map);
    addDoubleClickListener(mediumMap);
    addDoubleClickListener(smallMap);
    addDoubleClickListener(xsmallMap);
}

function updateMap(aMap, pos) {
    var location = $("#ResidentialAddress").val();

    if (location == undefined || location == null || location == '') {
        location = 'Default location';
    }

    var marker = new google.maps.Marker({
        position: pos,
        map: aMap,
        title: location
    });

    markersArray.push(marker);
    aMap.setCenter(pos);
    aMap.setZoom(15);
}

function addDoubleClickListener(aMap) {
    viewType = $("#viewType").val();

    if (viewType != undefined && viewType != null && viewType == "Edit") {
        google.maps.event.addListener(aMap, 'dblclick', function (event) {

            for (var i = 0; i < markersArray.length; i++) {
                markersArray[i].setMap(null);
            }

            markersArray = [];

            pos = new google.maps.LatLng(event.latLng.lat(),
                                             event.latLng.lng());

            $("#Latitude").val(event.latLng.lat());
            $("#Longitude").val(event.latLng.lng());
            aMap.setZoom(15);
            updateMap(aMap, pos)
        });
    }
}

function addSearchBox(aMap, textbox) {
    var markers = [];
    var input = /** @type {HTMLInputElement} */(
      document.getElementById(textbox));
    aMap.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    var searchBox = new google.maps.places.SearchBox(
      /** @type {HTMLInputElement} */(input));

    // Listen for the event fired when the user selects an item from the
    // pick list. Retrieve the matching places for that item.
    google.maps.event.addListener(searchBox, 'places_changed', function () {
        var places = searchBox.getPlaces();

        if (places.length == 0) {
            return;
        }
        for (var i = 0, marker; marker = markers[i]; i++) {
            marker.setMap(null);
        }

        // For each place, get the icon, place name, and location.
        markers = [];
        var bounds = new google.maps.LatLngBounds();
        for (var i = 0, place; place = places[i]; i++) {
            var image = {
                url: place.icon,
                size: new google.maps.Size(71, 71),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(17, 34),
                scaledSize: new google.maps.Size(25, 25)
            };

            // Create a marker for each place.
            var marker = new google.maps.Marker({
                map: aMap,
                icon: image,
                title: place.name,
                position: place.geometry.location
            });

            markers.push(marker);

            bounds.extend(place.geometry.location);
        }

        aMap.fitBounds(bounds);
        aMap.setZoom(15);
    });

    // Bias the SearchBox results towards places that are within the bounds of the
    // current map's viewport.
    google.maps.event.addListener(aMap, 'bounds_changed', function () {
        var bounds = aMap.getBounds();
        searchBox.setBounds(bounds);
    });

}

google.maps.event.addDomListener(window, 'load', initialize);