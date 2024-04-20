<template>
  <div>
    <!-- <div class = "headers"> -->
        <page-header> </page-header>       
        <page-nav>                  
          <router-link to="/about" class="nav-button">O nas</router-link>
          <router-link to="/animals" class="nav-button">Zwierzęta</router-link>
          <router-link to="/support" class="nav-button">Wsparcie</router-link>
          <router-link to="/adoption" class="nav-button">Adopcja</router-link>
          <router-link to="/contact" class="nav-button">Kontakt</router-link>
        </page-nav>
      </div>
       
    <page-main>
      <router-view></router-view>
    </page-main>

    <page-footer></page-footer>
  <!-- </div> -->
</template>


<script setup>
import {ref} from 'vue'
import PageHeader from './components/PageHeader.vue'
import PageNav from './components/PageNav.vue'
import PageFooter from './components/PageFooter.vue'
import PageMain from './components/PageMain.vue'

</script>
