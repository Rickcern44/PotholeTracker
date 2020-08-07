import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import store from './store/index'
import axios from 'axios'
//Google maps
import * as VueGoogleMaps from "vue2-google-maps";

Vue.config.productionTip = false

//Map key import
Vue.use(VueGoogleMaps, {
  load: {
    key: "AIzaSyAj_oxrFECAQDBRlqJxmXTaiFhjIutgIzI",
    libraries: "places" // necessary for places input
  }
});


axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
