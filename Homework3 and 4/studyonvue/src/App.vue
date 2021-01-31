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
  provide: ['getAllFields'],
  mounted(){
      this.$store.commit('checkLoggedUser');
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
    }
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
