<template>
<footer>
  <div class="column logo-footer">
    <router-link to="/">
      <img src="/kot_pies.jpg" alt="Logo">
    </router-link>
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