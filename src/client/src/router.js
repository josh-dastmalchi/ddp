import Vue from 'vue'
import VueRouter from 'vue-router'
import Sandbox from './views/Sandbox.vue'
Vue.use(VueRouter)

export default new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'Sandbox',
      component: Sandbox
    }
  ]
})
