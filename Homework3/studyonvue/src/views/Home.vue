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
import axios from "axios";

export default {
  name: 'Home',
  mounted(){
    this.getAllMatches();
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
  async created(){
      await this.getAllFields();
      this.markers = this.getAllMarkers();
  },
  provide(){
    return {      
     getAllMatches: this.getAllMatchesBySport,
     addMatch: this.addMatch,
     logged: this.logged,
    }
  },
  computed: {
    getMatches(){
      return this.matches
    }
  },
  methods: {
    addMatch(data){
      let match = {
        'CourtId': data.CourtId,
        'MaxPlayers': parseInt(data.MaxPlayers),
        'CurrentPlayers': 1,
        'Type': data.Type,
        'StartTime': data.StartTime,
        'EndTime': data.EndTime
      }

      const instance = axios.create({
        baseURL: 'https://localhost:5001/matches'
      });

      instance.defaults.headers.common['Authorization'] = `bearer ${this.$store.state.jwt}`
      instance.defaults.headers.post['Content-Type'] = "application/json";
      instance.post('/create', JSON.stringify(match)).then(
        () => {
          this.getAllMatches();
        }
      );
      
    },
     getAllMatches(){
      axios.get(`https://localhost:5001/matches/search?CurrentPage=${this.$store.state.currentPage}&PageSize=20`, 
      {     
        headers: {         
          'Content-Type': 'application/json'     
        } 
      }).then((res) => {
        this.$store.commit('setMatches', {
          matches: res.data.payload
        })
      }).catch(e => {
        console.log(e);
      })     
    },
    async getAllMatchesBySport(sport){
      if (sport.trim() == ""){
        this.getAllMatches();
        return;
      }

      let matches; 
      await axios.get(`https://localhost:5001/matches/search?CurrentPage=${this.$store.state.currentPage}&PageSize=20&Type=${sport}`).then(res => {
        matches = res.data.payload;
      });

      this.$store.commit('setMatches', {
        matches: matches
      });
    },
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