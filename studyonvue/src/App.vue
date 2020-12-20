<template>
  <div id="app">
    <Sidemenu/>
    <ListMatches/>
    <MapContainer/>
  </div>
</template>

<script>

import Sidemenu from "./components/Sidemenu";
import ListMatches from "./components/ListMatches";
import MapContainer from "./components/MapContainer";

export default {
  name: 'App',
  components: {
    Sidemenu,
    ListMatches,
    MapContainer
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
