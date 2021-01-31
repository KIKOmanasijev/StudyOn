<template>
  <div class="home">
    <Sidemenu/>
    <ListMatches :matches="$store.state.matches"/>
    <MapContainer :markers="markers"/>
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";
import ListMatches from "../components/ListMatches";
import MapContainer from "../components/MapContainer";
import repo from "../repository/repo";

export default {
  name: 'Home',
  async mounted(){
    repo.fetchAllMatches();
    await repo.fetchAllFields();
    this.markers = repo.fetchAllMarkers();
  },
  data(){
    return {
      markers: []
    }
  },
  components: {
    Sidemenu,
    ListMatches,
    MapContainer,
  },
  provide(){
    return {      
     getAllMatches: repo.fetchMatchesBySport,
     addMatch: repo.addMatch,
    }
  },
  computed: {
    getMatches(){
      return this.matches
    }
  }
}
</script>

<style >
  .home {
     font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;

    width: 100%;
    height: 100vh;

    display: flex;
    max-height: 100vh;
  }

  #map {
    flex: 1;
  }

  .z-index-1 {
    z-index: -1;
  }
</style>