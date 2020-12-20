<template>
  <div id="app">
    <Sidemenu/>
  </div>
</template>

<script>

import Sidemenu from "./components/Sidemenu";

export default {
  name: 'App',
  components: { 
    Sidemenu 
  },
  data(){
    return {
      courts: [
        {
          id: 1,
          lat: 41.9990051,
          lng: 21.2848064,
          sport: "Football",
          name: "Forza Karpos"
        }
      ]
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
}
</style>
