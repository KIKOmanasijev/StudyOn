<template>
    <div id="map">
       <GmapMap
        :center="{lat:42.0012952, lng:21.4434693}"
        :zoom="13"
        v-bind:options="mapStyles"
        style="width: 100%; height: 100%"
        >
        <!-- <GmapMarker
            :key="index"
            v-for="(m, index) in markers"
            :position="m.position"
            :clickable="true"
            :draggable="true"
            @click="center=m.position"
        /> -->
        </GmapMap>
    </div>
</template>
    
<script>


export default {
    name: "MapContainer",
    data(){
        return {
            mapStyles: {
                
            styles: [
                {
                "elementType": "geometry.fill",
                "stylers": [
                    {
                    "color": "#deddee"
                    }
                ]
                },
                {
                "featureType": "administrative.land_parcel",
                "stylers": [
                    {
                    "visibility": "off"
                    }
                ]
                },
                {
                "featureType": "administrative.locality",
                "elementType": "labels.text",
                "stylers": [
                    {
                    "visibility": "simplified"
                    }
                ]
                },
                {
                "featureType": "administrative.neighborhood",
                "stylers": [
                    {
                    "visibility": "off"
                    }
                ]
                },
                {
                "featureType": "administrative.province",
                "elementType": "labels.text",
                "stylers": [
                    {
                    "visibility": "off"
                    }
                ]
                },
                {
                "featureType": "landscape.man_made",
                "elementType": "labels.text",
                "stylers": [
                    {
                    "visibility": "off"
                    }
                ]
                },
                {
                "featureType": "poi",
                "elementType": "labels.text",
                "stylers": [
                    {
                    "visibility": "off"
                    }
                ]
                },
                {
                "featureType": "road",
                "stylers": [
                    {
                    "color": "#ffffff"
                    }
                ]
                },
                {
                "featureType": "road.highway",
                "stylers": [
                    {
                    "visibility": "off"
                    }
                ]
                },
                {
                "featureType": "road.highway.controlled_access",
                "stylers": [
                    {
                    "visibility": "off"
                    }
                ]
                },
                {
                "featureType": "water",
                "elementType": "geometry",
                "stylers": [
                    {
                    "color": "#8880ff"
                    },
                    {
                    "weight": 2
                    }
                ]
                }
            ]
            }
        }
    } 
}
</script>
<style>
#map {
    flex: 1;
}
</style>