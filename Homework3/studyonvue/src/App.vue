<template>
  <div id="app">
    <router-link to="/"></router-link>
    <router-link to="/fields"></router-link>
    <router-link to="/faq"></router-link>
    <router-view></router-view>
  </div>
</template>

<script>


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
                  location: {lat:42.5012952, lng:21.484693}
              },                    
              sport: "Football",
              date: new Date(2020, 12, 25, 16, 30),
              maxPlayers: 10,
              currentPlayers: [1,2,3,4,5]
          }
      ],
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
