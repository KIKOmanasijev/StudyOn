<template>
  <div class="fields">
    <Sidemenu/>
    <ListFields :fields="fields" :user="user"/>
    <MapContainer :markers="getAllMarkers()"/>
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";
import ListFields from "../components/ListFields";
import MapContainer from "../components/MapContainer";

export default {
  name: 'Fields',
  data(){
   return {
    user: {
      loggedIn: true
    },
    fields: [
      {
        id: 1,
        fieldName: "Игралиште Форза Каропош",
        fieldImg: "https://ading.com.mk/CMS/Upload/Referenci/tenisko-igraliste-micei-international(1).jpg",
        location: {lat:41.9912952, lng:21.4134693},
        sport: "Football",
        rating: 5
      }, 
      {
        id: 2,
        fieldName: "Игралиште Кисела Вода",
        fieldImg: "https://a1on.mk/wp-content/uploads/2018/04/detski-igralista-kiselavoda-3.jpg",
        location: {lat:42.0002952, lng:21.4034693},
        sport: "Football",
        rating: 5
      }
    ],
   }
  },
  components: {
    Sidemenu,
    ListFields,
    MapContainer  
  },
  methods: {
    getAllMarkers(){
      let markers = this.fields.map((match) => {
        return match.location
      });

      return markers;
    }
  }
}
</script>

<style>
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
</style>