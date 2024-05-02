<template>
    <div class="nav-menu"> 
  <i 
  @click="showMenu()"><font-awesome-icon :icon="['fas', 'bars']" />
  </i>
  <div
  class="nav-content"
  :class="this.showMobileMenu ? 'open-menu' : 'closed-menu'"
  >
  <ul class="nav-items">
    <router-link to="/about" class="nav-button" @click = "closeMenu">O nas</router-link>
    <router-link to="/animals" class="nav-button" @click = "closeMenu">Zwierzęta</router-link>
    <router-link to="/support" class="nav-button" @click = "closeMenu">Wsparcie</router-link>
    <router-link to="/adoption" class="nav-button" @click = "closeMenu">Adopcja</router-link>
    <router-link to="/contact" class="nav-button" @click = "closeMenu">Kontakt</router-link>
  </ul>
  </div>
  </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        showMobileMenu: false
      };
    },
    methods: {
      showMenu() {
        this.showMobileMenu = !this.showMobileMenu;
      },
      closeMenu() {
      this.showMobileMenu = false; // Ustaw showMobileMenu na false, aby zamknąć menu
    }
      
    }
  };
  </script>
  
  <style lang="scss" scoped>
  .nav-menu {
    background-color: white;
  }
  
  .nav-content {
    display: flex;
    justify-content: space-between;
    padding: 10px 30px;
    align-items: center;
    justify-content: flex-end;
  }
  
  .nav-items {
    display: flex;
    justify-content: center;
    align-items: center;
    list-style: none;
    margin: 0;
    padding: 0;
    li {
      padding: 0 10px;
    }
  }
  
  i {
    display: none;
  }
  
  // Mobile version - hidden hamburger menu
  @media screen and (max-width: 991px) {
    .nav-menu {
      padding-top: 10px;
      position: absolute;
      width: 100%;
      top: 90px;
 
    }
  
    .open-menu {
      opacity: 1;
      height: 150px;
      
    }
  
    .closed-menu {
      opacity: 0;
      height: 0;
      padding: 0;
    }
  
    .nav-content {
      flex-direction: column;
      z-index: 2;
      position: relative;
      transition: all 0.2s ease-out;

    }
  
    .nav-items {
      flex-direction: column;
    }
  
    i {
      display: block;
      text-align: right;
      padding: 0 10px 10px 0;
    }
  }
  </style>