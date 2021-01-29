import Vue from 'vue'
import App from './App.vue'
import Vuex from 'vuex';

Vue.config.productionTip = false

import BaseDialog from "./views/UI/BaseDialog"
import * as VueGoogleMaps from 'vue2-google-maps'
import router from './router'
import axios from "axios";

Vue.use(Vuex);
const store = new Vuex.Store({
  state() {
    return {
      matches: [],
      fields: [],
      loggedUser: null,
      currentPage: 1,
      pageSize: 20,
    };
  },
  mutations: {
    logInUser(state, payload) {
      state.loggedUser = payload.user;

      localStorage.setItem("token", payload.user.jwt);
      localStorage.setItem("user", payload.user.username);
    },
    logOutUser(state) {
      state.loggedUser = null;
      localStorage.removeItem("token");
      localStorage.removeItem("user");
    },
    checkLoggedUser(state) {
      let user = localStorage.getItem("user");
      if (user) {
        state.loggedUser = user;
        state.jwt = localStorage.getItem("token");
      }
    },
    setMatches(state, payload) {
      state.matches = payload.matches;
    },
    getAllFields(state, payload) { 
      state.fields = payload;
    },
  },
  actions: {
    searchMatches({commit, state}) {
      axios
        .get(
          `https://localhost:5001/matches/search?CurrentPage=${state.currentPage}&PageSize=20`,
          {
            headers: {
              "Content-Type": "application/json",
            },
          }
        )
        .then((res) => {
          commit("setMatches", {
            matches: res.data.payload,
          });
        });
    }
  }
});

Vue.component("BaseDialog", BaseDialog);
Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyCkTeDImtgXN0fuCc5tCH4Pvryr3pFVfzM'
  }
})

new Vue({
  router,
  render: h => h(App),
  store: store
}).$mount('#app')
