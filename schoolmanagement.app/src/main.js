window.__VUE_PROD_HYDRATION_MISMATCH_DETAILS__ = false;
import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import vuetify from './plugins/vuetify';
import { loadFonts } from './plugins/webfontloader';
import Toast from 'vue-toastification';
import 'vue-toastification/dist/index.css';

loadFonts();

createApp(App)
  .use(Toast)
  .use(router)
  .use(vuetify)
  .mount('#app');
