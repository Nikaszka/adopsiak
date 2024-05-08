<template>
  <div class = "selected-animal-container">
    <input type="text" id="myInput" :value="animals[index].name" class="title"></input>
    <div class = "animal-data">
      <div class="animal-photo">
        <img :src="animals[index].image" :alt="animals[index].name" class="animal-image" />
      </div>
      <div class = "animal-desciption">
        <div class = "animal-breed">
          <font-awesome-icon icon="paw" class="info-icon"/>
          <input type="text" id="myInput" :value="animals[index].breed" class="breed-name"></input> 
        </div>
        <div class = "animal-gender">
          <font-awesome-icon icon="venus-mars" class="info-icon"/>
          <input type="text" id="myInput" :value="animals[index].gender + ', ' + animals[index].age" class="gender-age"></input>
        </div>
        <div class = "animal-location">
          <font-awesome-icon icon="location-dot" class="info-icon"/>
          <input type="text" id="myInput" :value="animals[index].location" class="location-address"></input>
        </div>
        <div class="other-benefits">
          <div class = "animal-benefits">
          <font-awesome-icon icon="heart" class="heart-icon"/>
          <input type="text" id="myInput" value="Uwielbia pieszczoty"></input> 
        </div>
        <div class = "animal-benefits">
          <font-awesome-icon icon="heart" class="heart-icon" />
          <input type="text" id="myInput" value="Uwielbia zabawę" class="gender-age"></input>
        </div>
        <div class = "animal-benefits">
          <font-awesome-icon icon="heart" class="heart-icon"/>
          <input type="text" id="myInput" value="Akceptuje inne zwierzęta"></input>
        </div>      
        </div>      
      </div>

    </div>
    <div class="description">
      <textarea class="text-area" placeholder="Description">
      {{description}}
      </textarea>
    </div>
    <div class="animal-help">
      <div class="animal-donation">
      <div class="animal-donation-title">Zaangażuj się w pomoc dla tego zwierzaka</div>
      <input type="text" placeholder="0,00 zł" class="donation-input">
      <div><button class="donation-button">Wesprzyj finansowo</button></div> 
    </div>
    
      <router-link to="/animals" class="router-link-active">
      <div>
        <div class="animal-form-title">Przejdź do formularza Adopcji </div>
        <font-awesome-icon :icon="['fas', 'pen']" class="pen-icon"/>
      </div>
      </router-link>
           
    
    </div>
 
  </div>
  

</template>
<script setup>
  import { computed, ref } from 'vue'
  import animals from '../animals.js'
  const props = defineProps(['id'])
  const index = computed(() => animals.findIndex(c => c.id == props.id))
  const description = ref("Tutaj spotykasz Królewnę - roczną kicię o zielonych oczach i puszystym  futerku, która weszła do naszego schroniska z uroczym uśmiechem na  pyszczku. Królewna to kwintesencja energii i radości. Zawsze gotowa do  zabawy i szalonych akrobacji, ta malutka kotka sprawi, że twoje dni będą  pełne uśmiechu i miłości. Jej delikatne mruczenie jest jak melodia dla  uszu, a czułe przytulenie potrafi rozgrzać serce każdego. Milusia szuka  kochającego domu, w którym będzie mogła rozwinąć swoje skrzydełka i zaskakiwać swoim urokiem każdego dnia. Czy to ty jesteś tą wyjątkową  osobą, na którą Królewna czeka? Przyjdź i pozwól tej małej kulce futra  wprowadzić więcej radości do twojego życia!")
</script>

<style scoped>
.info-icon,
.heart-icon{
  font-size: 35px;
}
.heart-icon{
  color: green;
}
.other-benefits{
  margin-top: 80px;
}
.animal-form-title{
  margin-left: 5px;
  margin-right: 5px;
  margin-bottom: 10px;
}
.router-link-active {
  text-decoration: none;
  color: black;
  text-align: center;
  align-items: center;
  justify-content: center;
  display: flex;
  background-color: rgb(94, 169, 59);
  border-radius: 10px; 
  height: 100%;
  font: italic 400 25px Inter, sans-serif;
}
@media (max-width: 991px) {
  .router-link-active{
    font: italic 400 15px Inter, sans-serif;
}
.info-icon,
.heart-icon{
  font-size: 18px;
}
.other-benefits{
  margin-top: 10px;
}
}
.pen-icon{
  font-size: 30px;
}
.animal-help{
  margin-top: 30px;
  display: flex;
}
.donation-button{
  margin-top: 10px;
  margin-bottom: 30px;
  background-color: rgb(70, 114, 50);
  color: white;
  align-items: center;
  border-radius: 10px;
  border: none;
  padding: 10px;

}
.donation-input{
  border: none;
  border-radius: 10px;
  width: 30%;
  text-align: center;
  height: 30%
}
.animal-donation-title{
  font: italic 400 30px Inter, sans-serif;
  padding: 20px;
}
.animal-donation{
  background-color: rgb(176, 212, 159);
  /* margin-bottom: 30px; */
  align-items: center;
  border-radius: 10px;
  padding-bottom: 15px;
  text-align: center;
  flex:1;
  margin-right: 10px

}
@media (max-width: 991px) {
  .animal-donation-title{
    font: italic 400 20px Inter, sans-serif;
}
}
.selected-animal-container{
  display: grid;
  margin-left: 200px;
  margin-right: 200px;
}
@media (max-width: 991px) {
  .selected-animal-container{
  margin: auto;
}
}
.title{
  text-align: left;
  border: none;
  margin-top: 10px;
  margin-bottom: 30px;
  font: italic 400 50px Inter, sans-serif;
}
@media (max-width: 991px) {
  .title{
    font: italic 400 30px Inter, sans-serif;
    margin: 10px;
    text-align: center;
}
}
.animal-data{
  display: flex; 
  text-align: justify;

}
@media (max-width: 991px) {
  .animal-data {
    margin: auto;
}}

.animal-photo{
  margin-right: 30px;
}
.animal-photo img{
  width: 600px;
  height: auto;
}
@media (max-width: 1200px) {
  .animal-photo img{
  width: 400px;
}}
@media (max-width: 900px) {
  .animal-photo img{
  width: 200px;
}}

.animal-description{
  max-width: 820px;
  margin: 0px auto;
  margin-top: 50px;
}
.animal-benefits{
  display: flex;
  white-space: nowrap;
  padding: 10px;
  gap: 15px;
}
.animal-benefits input{
  border: none;
  font: italic 400 20px Inter, sans-serif;
}

.animal-location,
.animal-gender,
.animal-breed{
  display: flex;
  white-space: nowrap;
  padding: 10px;
}
.animal-gender{
  gap: 15px;
}
.animal-breed{
  gap: 25px;
}
.animal-location{
  gap: 30px;
}
.animal-location input,
.animal-gender input,
.animal-breed input{
  border: none;
  font: italic 400 20px Inter, sans-serif;
}
.description {
  float: left;
  width: 100%;
  height: auto;
}
.text-area {
  float: left;
  width: 100%;
  min-height: 180px;
  outline: none;
  resize: none;
  border: none;
  font: italic 400 20px Inter, sans-serif;
  text-align: justify;
}
@media (max-width: 900px) {
  .text-area{
    font: italic 400 15px Inter, sans-serif;
    /* margin: 10px; */
  }
.animal-location input,
.animal-gender input,
.animal-breed input, 
.animal-benefits input{
  font: italic 400 13px Inter, sans-serif;
}
.animal-location,
.animal-gender,
.animal-breed, 
.animal-benefits{
  padding: 3px;
}
}

</style>