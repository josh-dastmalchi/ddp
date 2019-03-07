import Vue from 'vue'
import App from './App.vue'
import router from './router'
import resource from 'vue-resource'
import store from './store'
import Vuetify from 'vuetify'

Vue.config.productionTip = false

Vue.use(Vuetify, {
  iconfont: 'md',
})

Vue.use(resource);
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')