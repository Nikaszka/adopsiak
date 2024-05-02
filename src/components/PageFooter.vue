<template>
<footer>
  <div class="column">
    <div class = "logo-footer">
      <router-link to="/">
        <img src="/kot_pies.jpg" alt="Logo">
      </router-link>
    </div>
    
  </div>
  <div class ="column">
    <div class ="footer-menu">
      <ul>
        <li><router-link to="/about" class = "footer-menu-buttons">O schronisku</router-link></li>
        <li><router-link to="/animals" class = "footer-menu-buttons">Zwierzęta do adopcji</router-link></li>
        <li><router-link to="/support" class = "footer-menu-buttons">Dary rzeczowe</router-link></li>      
        <li><router-link to="/adoption" class = "footer-menu-buttons">Jak adoptować?</router-link></li>
        <li><router-link to="/contact" class = "footer-menu-buttons">Kontakt</router-link></li>
      </ul>
    </div>      
  </div>
  <div class="column">
    <div class="footer-menu">
      <ul>
        <li><h4>Kontakt</h4></li>
        <li><font-awesome-icon icon="envelope"/> adopsiak@gmail.com</li>
        <li><font-awesome-icon icon="phone" /> + 555 444 333</li>      
        <li><font-awesome-icon icon="location-dot"/> AdoPsiak sp.z.o.o <br> ul. Słoneczna 25 <br> 30-500 Kraków</li>
        <li>poniedziałek - piątek <br> 9:00-18:00</li>
        
      </ul>  
    </div>
  </div>
</footer>
</template>

<style>
  footer {
    background-color: rgb(94, 169, 59);
    display: flex;
    align-items: center;
  }

  .column {
    padding: 20px;
    flex: 1;
    text-align: center;
  }

  .logo-footer img {
    width: 170px;
    height: auto;
    margin-top: 10px;
    margin-bottom: 10px;
    border-radius: 30px;
  }

  .footer-menu {
    text-align: left;
  }

  .footer-menu-buttons {
    text-decoration: none;
    color: white;
}

.footer-menu ul li {
    margin-bottom: 10px;
    color: white;
}

  @media screen and (max-width: 768px) {
  .column{
      padding: 0;
      
  }
  .footer-menu-buttons {
    color: white !important;
    border: none;
    font-size: 10px;

  }
  .logo-footer img {
    width: 100px;
  }
  .footer-menu ul li {
    font-size: 10px;
}

}
</style>