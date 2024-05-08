import { createApp } from 'vue'
import router from './router'
import App from './App.vue'
import './assets/app.css'

import { library } from "@fortawesome/fontawesome-svg-core";
import { faPhone, faEnvelope, faLocationDot, faHeart, faHandHoldingDollar, faHouse, faVenusMars, faPaw, faBars, faDog, faCat, faClock} from "@fortawesome/free-solid-svg-icons";
import { faInstagram, faFacebook } from "@fortawesome/free-brands-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

import Animal from './components/Animal.vue'

library.add(faPhone, faEnvelope, faLocationDot, faInstagram, faFacebook, faHeart, faHandHoldingDollar, faHouse, faVenusMars, 
            faPaw, faBars, faDog, faCat, faClock);

createApp(App)
.component('font-awesome-icon', FontAwesomeIcon)
.component('Animal', Animal)
.use(router)
.mount('#app')

// const app = createApp(App)

// app.mount('#app')
// app.component('Animal', Animal)
// app.use(router)
// app.component('font-awesome-icon', FontAwesomeIcon)

