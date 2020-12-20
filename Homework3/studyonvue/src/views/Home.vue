<template>
  <div class="home">
    <Sidemenu/>
    <ListMatches :matches="matches" :user="user"/>
    <MapContainer :markers="getAllMarkers()"/>
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";
import ListMatches from "../components/ListMatches";
import MapContainer from "../components/MapContainer";

export default {
  name: 'Home',
  data(){
   return {
    user: {
      loggedIn: true
    },
    matches: [
      {
        field: {
            id: 1,
            fieldName: "Игралиште Форза Каропош",
            fieldImg: "https://ading.com.mk/CMS/Upload/Referenci/tenisko-igraliste-micei-international(1).jpg",
            location: {lat:42.0012952, lng:21.4434693}
        },                    
        sport: "Football",
        date: new Date(2020, 12, 25, 16, 30),
        maxPlayers: 10,
        currentPlayers: [1,2,3,4,5]
      },
      {
        field: {
            id: 2,
            fieldName: "К-Спорт Сала",
            fieldImg: "https://ading.com.mk/CMS/Upload/Referenci/tenisko-igraliste-micei-international(1).jpg",
            location: {lat:42.0015952, lng:21.416393}
        },                    
        sport: "Football",
        date: new Date(2020, 12, 25, 16, 30),
        maxPlayers: 10,
        currentPlayers: [1,2,3,4,5]
      }
    ],
   }
  },
  components: {
    Sidemenu,
    ListMatches,
    MapContainer  
  },
  created(){
    this.getAllMarkers()
  },
  methods: {
    getAllMarkers(){
      let markers = this.matches.map((match) => {
        return match.field.location
      });

      return markers;
    }
  }
}
</script>

<style scoped>
  .home {
     font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;

    width: 100%;
    height: 100vh;

    display: flex;
  }
</style>