<template>
  <div id="app">
    <router-link to="/"></router-link>
    <router-link to="/fields"></router-link>
    <router-link to="/faq"></router-link>
    <router-view></router-view>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'App',
  components: {
    // Sidemenu,
    // ListMatches,
    // MapContainer
  },
  data(){
    return {
      user: {
        loggedIn: true
      },
      matches: []
    }
  },
  mounted(){
     axios.get('https://localhost:5001/matches/search?CurrentPage=1&PageSize=20')
      .then(res => this.matches = res.data.payload)
  }
}
</script>

<style>
html, body, * {
  box-sizing: border-box;
}

body {
  margin: 0;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100vh;

  display: flex;

}
</style>
