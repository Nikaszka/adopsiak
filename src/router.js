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

export default createRouter({
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
      },
      {
        path: '/animal/new',
        component: AddAnimal,
      },
    ]
})