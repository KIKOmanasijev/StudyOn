<template>
  <div class="fields">
    <Sidemenu/>
    <ListFields :getAllFields="getAllFields"/>
    <MapContainer :markers="markers"/>
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";
import ListFields from "../components/ListFields";
import MapContainer from "../components/MapContainer";

import axios from "axios";

export default {
  name: 'Fields',
  data(){
   return {
     markers: [],
      fields: [],
   }
  },
  provide: ['getAllFields'],
  components: {
    Sidemenu,
    ListFields,
    MapContainer  
  },
  async mounted(){
    await this.getAllFields();
    this.markers = this.getAllMarkers();
  },
  methods: {    
    async getAllFields(){
      let courts = await axios.get(`http://localhost:5000/courts/search?CurrentPage=${this.$store.state.currentPage}&PageSize=20`, {
        headers: {
          "Authorization": `bearer ${this.$store.state.jwt}`,
          'Access-Control-Allow-Origin' : '*',
        }
      });
      this.$store.commit('getAllFields', courts.data.payload);      
    },
    getAllMarkers(){
      let markers = this.$store.state.fields.map((field) => {
        return {
          lat: field.lat,
          lng: field.lng
        }
      });

      return markers;
    },
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