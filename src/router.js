import {createRouter, createWebHistory} from 'vue-router'
import Home from './views/Home.vue'
import About from './views/About.vue'
import Animals from './views/Animals.vue'
import Contact from './views/Contact.vue'
import Support from './views/Support.vue'
import Adoption from './views/Adoption.vue'
import SelectedAnimal from './views/SelectedAnimal.vue'
import AdoptionForm from './views/AdoptionForm.vue'
import LoginPage from './views/LoginPage.vue'
import AddAnimal from './views/AddAnimal.vue'
import Admin from './views/Admin.vue'
import EditAnimal from './views/EditAnimal.vue'
import FormDetails from './views/FormDetails.vue'
import { isUserLogged } from './session.js'

const router = createRouter({
    history: createWebHistory(),
    routes: [
      {
        path: '/',
        component: Home
      },
      {
        path: '/About',
        component: About
      }, 
      {
        path: '/Animals',
        name: 'Animals',
        component: Animals
      },
      {
        path: '/Support',
        component: Support
      }, 
      {
        path: '/Adoption',
        component: Adoption
      },
      {
        path: '/Contact',
        component: Contact
      },
      {
        path: '/animal/:id',
        name: 'SelectedAnimal',
        component: SelectedAnimal,
        props: true
      },
      {
        path: '/animal/adoption-form/:id',
        name: 'AdoptionForm',
        component: AdoptionForm,
        props: true
      },
      {
        path: '/admin/login',
        component: LoginPage,
        meta: {
          loginPage: true
        }
      },
      {
        path: '/animal/new',
        component: AddAnimal,
      },
      {
        path: '/admin',
        component: Admin,
        meta: {
          requireAuth: true
        }
      },
      {
        path: '/animal/edit/:id',
        name: 'EditAnimal',
        component: EditAnimal,
        props: true,
        meta: {
          requireAuth: true
        }
      },
      {
        path: '/AdoptionForms/:id',
        name: 'FormDetails',
        component: FormDetails,
        props: true
      },
    ],
    scrollBehavior(to, from, savedPosition) {
      if (to.hash) {
        return { el: to.hash };
      } else {
        return { top: 80 };
      }
    }
});

router.beforeEach((to, from, next) => {
  if(to.meta.loginPage) {
    if(isUserLogged()){
      next('/admin');
      return;
    }
  }
  if(to.meta.requireAuth){
    if(!isUserLogged()){
      next('/admin/login');
      return;
    }
  }
  next();
})

export default router;