<template>
  <div class="home">
    <Sidemenu/>
    <ListMatches :matches="$store.state.matches" :user="user"/>

    <!-- <BaseDialog v-if="modal">
      <template #title><h2>Add new match</h2></template>
      <template #content><MatchForm/></template>
    </BaseDialog> -->
    <MapContainer/>
    <!-- <MapContainer :markers="getAllMarkers()"/> -->
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";
import ListMatches from "../components/ListMatches";
import MapContainer from "../components/MapContainer";
import axios from "axios";

export default {
  name: 'Home',
  data(){
   return {
    user: {
      loggedIn: true
    },
    matches: [],
    logged: true
   }
  },
  mounted(){
    this.getAllMatches();
  },
  components: {
    Sidemenu,
    ListMatches,
    MapContainer,
  },
  created(){
    // this.getAllMarkers()
  },
  provide(){
    return {      
     getAllMatches: this.getAllMatchesBySport,
     addMatch: this.addMatch,
     logged: this.logged
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
        'UserId': data.userId,
        'CourtId': data.courtId,
        'MaxPlayers': data.maxPlayers,
        'CurrentPlayers': 1,
        'Type': data.type,
        'StartTime': data.startTime,
        'EndTime': data.endTime
      }
      axios.post('https://localhost:5001/matches/create', JSON.stringify(match), {
        headers: {
          'Authorization': `Bearar ${this.$store.state.jwt}`,
          'Content-Type': 'application/json'
        }
      }).then(res => console.log(res)).catch(err => console.log(err));
      this.getAllMatches();
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
      await axios.get(`https://localhost:5001/matches/search?${this.$store.state.currentPage}=1&PageSize=20&Type=${sport}`).then(res => {
        matches = res.data.payload;
      });

      this.$store.commit('setMatches', {
        matches: matches
      });
    }
    // getAllMarkers(){
    //   let markers = this.matches.map((match) => {
    //     return match.field.location
    //   });

    //   return markers;
    // }
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
  }

  #map {
    flex: 1;
  }

  .z-index-1 {
    z-index: -1;
  }
</style>