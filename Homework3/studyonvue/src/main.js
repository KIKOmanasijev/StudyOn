import Vue from 'vue'
import App from './App.vue'

Vue.config.productionTip = false

import BaseDialog from "./views/UI/BaseDialog"
import * as VueGoogleMaps from 'vue2-google-maps'
import router from './router'

Vue.component("BaseDialog", BaseDialog);
Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyCkTeDImtgXN0fuCc5tCH4Pvryr3pFVfzM'
  }
})

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
