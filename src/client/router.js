import Vue from 'vue'
import VueRouter from 'vue-router'
import Sandbox from './views/Sandbox.vue'
import NavDrawer from './views/NavDrawer.vue'
import Toolbar from './views/Toolbar.vue'
Vue.use(VueRouter)

export default new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'Sandbox',
      components: {
        default: Sandbox,
        navdrawer: NavDrawer,
        toolbar: Toolbar
      }
    }
  ]
})