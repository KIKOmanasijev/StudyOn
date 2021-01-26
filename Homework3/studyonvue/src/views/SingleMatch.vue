<template>
  <div class="single-match">
    <Sidemenu/>
    <SingleMatchBox/>
    <MapContainer/>
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";
import MapContainer from "../components/MapContainer";
import SingleMatchBox from "../views/UI/SingleMatchBox";

export default {
  name: 'SingleMatch',
  components: {
    Sidemenu,
    MapContainer,
    SingleMatchBox
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