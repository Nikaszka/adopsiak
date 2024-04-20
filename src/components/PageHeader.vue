<template>
    <header>
        <div>
        <router-link to="/" class="logo-container" >
          <img src="/kot_pies.jpg" alt="Logo">
        </router-link>
        </div>
        
        <div class = "header-info">
          <span><font-awesome-icon icon="envelope"/>  555-444-333</span>
          <span><font-awesome-icon icon="envelope"/>  adopsiak@gmail.com</span>
        </div>

        <div>
          <span><font-awesome-icon :icon="['fab', 'instagram']"/></span>
          <span><font-awesome-icon :icon="['fab', 'facebook']"/></span>
        </div>

    </header>
</template>