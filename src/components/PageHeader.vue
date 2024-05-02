<template>
<header>
  <div class="column-header">
    <router-link to="/" class="logo-container">
          <img src="/kot_pies.jpg" alt="Logo">
    </router-link>
  </div>
  <div class="column-header">
    <div class = "header-info">
          <span><font-awesome-icon icon="envelope"/>  555-444-333</span>
          <span><font-awesome-icon icon="envelope"/>  adopsiak@gmail.com</span>
    </div>
  </div>
  <div class="column-header">
    <div class = "header-social-icons">
          <span><font-awesome-icon :icon="['fab', 'instagram']" /></span>
          <span><font-awesome-icon :icon="['fab', 'facebook']"/></span>
    </div>
  </div>
        <!-- <div>

        </div>
        


        <div class = "header-social-icons">
          <span><font-awesome-icon :icon="['fab', 'instagram']" /></span>
          <span><font-awesome-icon :icon="['fab', 'facebook']"/></span>
        </div> -->
</header>
</template>

<style lang="scss" scoped>
header {
    padding: 30px;
    background-color: rgb(94, 169, 59);
    color: white;

    display: flex;
    justify-content: space-between;
    align-items: center;
}
.header-info span {
    padding: 170px;
}

.header-social-icons span {
    margin-left: 10px;
}
.logo-container img {
    z-index: 1;
    width: 120px;
    position: absolute;
    top: 10 px;
    border-radius: 30px; 
}
.column-header {
    text-align: center;
}

@media screen and (max-width: 991px) {
  header {
    font-size: 10px;
}
  .header-info {
    margin-left: 14vh;
    display: flex;
    flex-direction: column;
  }

  .header-info span {
      padding: 1px;
  }
  .logo-container img {
    width: 100px; 
}

}
</style>
