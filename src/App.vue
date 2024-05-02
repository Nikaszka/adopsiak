<template>
  <div class="container">
    <page-header></page-header>             
    <page-nav></page-nav>    
    <page-main>
      <router-view></router-view>
    </page-main>
    <page-footer></page-footer>
  </div>
</template>


<script setup>
import PageHeader from './components/PageHeader.vue'
import PageNav from './components/PageNav.vue'
import PageFooter from './components/PageFooter.vue'
import PageMain from './components/PageMain.vue'

</script>

<script>
export default {
  data() {
    return {
      showMobileMenu: false,
    };
  },
  methods: {
    showMenu() {
      this.showMobileMenu = !this.showMobileMenu;
    },
  },
};
</script>
