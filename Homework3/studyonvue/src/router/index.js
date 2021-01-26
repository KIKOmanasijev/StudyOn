import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Fields from '../views/Fields.vue'
import Faq from '../views/Faq.vue'
import SingleMatch from "../views/SingleMatch.vue";

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    props: true
  },
  {
    path: '/fields',
    name: 'Fields',
    component: Fields
  },
  {
    path: '/faq',
    name: 'Faq',
    component: Faq
  },
  {
    path: '/match/:matchId',
    name: 'Single Match',
    component: SingleMatch
  }
  // {
  //   path: '/field/:id',
  //   name: "Single Field",
  //   component: Field
  // },
  // {
  //   path: '/match/:id',
  //   name: 'Single Match',
  //   component: Match
  // }
]

const router = new VueRouter({
  routes,
  mode: 'history'
})

export default router
