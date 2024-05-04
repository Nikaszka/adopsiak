<template>
    <div class="animal-adoption">
    <div class="animal-grid">
      <div v-for="(animal, index) in displayedAnimals" :key="index" class="animal-column">
        <router-link to="/animals" class="router-link-active">
          <div class="animal-card">
            <img :src="animal.image" :alt="animal.name" class="animal-image" />
            <h3 class="animal-name">{{ animal.name }}</h3>
            <div class="animal-breed">
              <font-awesome-icon icon="paw" />
              <span class="breed-name">{{ animal.breed }}</span>
            </div>
            <div class="animal-gender">
              <font-awesome-icon icon="venus-mars" />
              <span class="gender-age">{{ animal.gender }}, {{ animal.age }}</span>
            </div>
            <div class="animal-location">
              <font-awesome-icon icon="location-dot" />
              <span class="location-address">{{ animal.location }}</span>
            </div>
          </div>
        </router-link>
      </div>
    </div>
    <!-- <router-link to="/animals" class="more-animals-btn">Więcej zwierzaków</router-link> -->
    <button @click="showMoreAnimals" v-if="!allAnimalsDisplayed && displayedAnimals.length < animals.length"  class="more-animals-btn" >Więcej zwierząt</button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      animals: [
        { name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg" },
        { name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png" },
        { name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg" },
        { name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg" },
        { name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg" },
        { name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png" },
        { name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg" },
        { name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg" },
        { name: "Lila", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg" },
        { name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png" },
        { name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg" },
        { name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg" },
        { name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg" },
        { name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png" },
        { name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg" },
        { name: "Azor", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg" },
        { name: "Azor", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg" }
        
      ],
      displayedAnimals: [],
      animalsPerPage: 8,
      startIndex: 0, 
      allAnimalsDisplayed: false 
    };
  },
  created() {
    this.updateDisplayedAnimals();
  },
  methods: {
    updateDisplayedAnimals() {
        this.displayedAnimals = this.animals.slice(0, this.startIndex + this.animalsPerPage);
    },
    showMoreAnimals() {
      this.startIndex += this.animalsPerPage;
      this.updateDisplayedAnimals();

      if ((this.startIndex + this.animalsPerPage) >= this.animals.length) {
        this.allAnimalsDisplayed = true;
      }
    }
  }
};  
</script>

<style scoped>
.router-link-active {
  text-decoration: none;
}

.animal-adoption {
  display: flex;
  flex-direction: column;
  margin-left: 300px;
  margin-right: 300px;
}

.animal-grid {
  margin-top: 39px;
  width: 100%;
  display: flex;
  gap: 20px;
  flex-wrap: wrap;
}

@media (max-width: 991px) {
  .animal-grid {
    max-width: 100%;
    flex-direction: column;
    align-items: stretch;
    margin-left: 0px;
    margin-right: 0px;
    gap: 0;
  }
  .animal-adoption {
    margin-left: 0px;
    margin-right: 0px;
  }
}

.animal-column {
  display: flex;
  flex-direction: column;
  line-height: normal;
  width: 23%;
  margin-left: 0px;
  margin-right: 0px;
}

@media (max-width: 1500px) {
  .animal-column {
    width: 100%;
  }
}

.animal-card {
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25);
  background-color: #fdfafa;
  display: flex;
  width: 100%;
  flex-grow: 1;
  padding-bottom: 9px;
  flex-direction: column;
  font-size: 16px;
  color: #000;
  font-weight: 600;
  text-align: center;
  margin: 0 auto;
}
@media (max-width: 991px) {
  .animal-card {
    margin-top: 40px;
    width: 70%;
  }
}

.animal-image {
  aspect-ratio: 1.82;
  object-fit: cover;
  object-position: center;
  width: 100%;
  z-index: 10;
  margin-top: -11px;
}

.animal-name {
  margin-top: 20px;
  font: italic 32px Inter, sans-serif;
}

.animal-breed,
.animal-gender,
.animal-location {
  display: flex;
  gap: 20px;
  white-space: nowrap;
}

@media (max-width: 1500px) {

  .animal-breed,
  .animal-gender,
  .animal-location {
    white-space: initial;
  }
}

.breed-icon,
.gender-icon,
.location-icon {
  aspect-ratio: 1.03;
  object-fit: contain;
  object-position: center;
  width: 37px;
}

.breed-name,
.gender-age,
.location-address {
  font-family: Inter, sans-serif;
  font-style: italic;
  flex-grow: 1;
  flex-basis: auto;
  margin: auto 0;
}

.animal-gender,
.animal-location {
  margin-top: 7px;
}

.location-icon {
  aspect-ratio: 0.97;
  width: 36px;
}

.more-animals-btn {
  border-radius: 50%;
  background-color: #7fc160;
  align-self: center;
  margin-top: 40px;
  color: #fff;
  text-align: center;
  padding: 17px 28px 10px;
  font: italic 600 32px Inter, sans-serif;
  border: none;
  cursor: pointer;
  text-decoration: none;
}
</style>
