<template>
  <div class="single-match">
    <Sidemenu/>
    <SingleFieldBox/>
    <MapContainer/>
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";
import MapContainer from "../components/MapContainer";
import SingleFieldBox from "../views/UI/SingleFieldBox";

export default {
  name: 'SingleField',
  components: {
    Sidemenu,
    MapContainer,
    SingleFieldBox
  }
}
</script>

<style scoped>
 .single-match {
     display: flex;

     width: 100%;
 }

 #map {
     height: 100%;
 }
</style>