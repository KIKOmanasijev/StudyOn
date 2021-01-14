<template>
  <div class="home">
    <Sidemenu/>
    <ListMatches :matches="getMatches" :user="user"/>

    <BaseDialog v-if="modal">
      <template #title><h2>Add new match</h2></template>
      <template #content><MatchForm/></template>
    </BaseDialog>
    <MapContainer :zindex="zindex"/>
    <!-- <MapContainer :markers="getAllMarkers()"/> -->
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";
import ListMatches from "../components/ListMatches";
import MapContainer from "../components/MapContainer";
import MatchForm from "../components/MatchForm";
import axios from "axios";

export default {
  name: 'Home',
  data(){
   return {
    user: {
      loggedIn: true
    },
    matches: [],
    modal: false
   }
  },
  mounted(){
    this.getAllMatches();
  },
  components: {
    Sidemenu,
    ListMatches,
    MapContainer,
    MatchForm  
  },
  created(){
    // this.getAllMarkers()
  },
  provide(){
    return {      
     getAllMatches: this.getAllMatchesBySport,
     toggleModal: this.toggleModal,
     addMatch: this.addMatch
    }
  },
  computed: {
    getMatches(){
      return this.matches
    },
    zindex(){
      return this.modal;
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
      // console.log(match);
      axios.post('https://localhost:5001/matches/create', JSON.stringify(match), {
        headers: {
          'Content-Type': 'application/json'
        },
        data: JSON.stringify(match)
      }).then(res => console.log(res)).catch(err => console.log(err));
      this.getAllMatches();
      this.toggleModal();
    },
    getAllMatches(){
      axios.get('https://localhost:5001/matches/search?CurrentPage=1&PageSize=20')
      .then(res => {
        this.matches = res.data.payload;
      })
    },
    getAllMatchesBySport(sport){
      if (sport.trim() == ""){
        this.getAllMatches();
        return;
      }
      axios.get('https://localhost:5001/matches/search?CurrentPage=1&PageSize=20&Type='+sport)
      .then(res => {
        this.matches = res.data.payload;
      })
    },
    toggleModal(){
      this.modal = !this.modal;
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