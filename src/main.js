import { createApp } from 'vue'
import router from './router'
import App from './App.vue'
import './assets/app.css'

import { library } from "@fortawesome/fontawesome-svg-core";
import { faPhone, faEnvelope, faLocationDot, faHeart, faHandHoldingDollar, faHouse} from "@fortawesome/free-solid-svg-icons";
import { faInstagram, faFacebook } from "@fortawesome/free-brands-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

library.add(faPhone, faEnvelope, faLocationDot, faInstagram, faFacebook, faHeart, faHandHoldingDollar, faHouse);

createApp(App)
.component('font-awesome-icon', FontAwesomeIcon)
.use(router)
.mount('#app')
