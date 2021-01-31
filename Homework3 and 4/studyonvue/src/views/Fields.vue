<template>
  <div class="fields">
    <Sidemenu/>
    <ListFields/>
    <MapContainer :markers="markers"/>
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";
import ListFields from "../components/ListFields";
import MapContainer from "../components/MapContainer";

import repo from "../repository/repo";

export default {
  name: 'Fields',
  data(){
   return {
     markers: [],
      fields: [],
   }
  },
  components: {
    Sidemenu,
    ListFields,
    MapContainer  
  },
  async mounted(){
    await repo.fetchAllFields();
    this.markers = repo.fetchAllMarkers();
  } 
}
</script>

<style scoped>
  .fields {
     font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;

    width: 100%;
    height: 100vh;

    display: flex;
  }

  .list-panel {
    overflow: scroll;
  }
</style>