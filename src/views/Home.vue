<template>
  <PercentTax></PercentTax>

  <!-- <div class="animal-adoption">
    <h2 class="section-title">Zwierzaki do adopcji</h2>
    <div class="animal-grid">
      <div v-for="(animal, index) in animals" :key="index" class="animal-column">
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
  </div> -->
    <div class="animal-adoption">
    <div class="animal-grid">
      <div v-for="animal in animals" :key="animal.id" class="animal-column">
        <Animal :animal='animal'></Animal>
      </div>
    </div>
    <router-link to="/animals" class="more-animals-btn">Więcej zwierzaków</router-link>
  </div>
  
  <div class="stats-container">
    <div class="stats-wrapper">
      <div class="percent-tax-rate-title">AdoPsiak w liczbach</div>
      <div class="stats-row">
        <div v-for="(stat, index) in stats" :key="index" class="stats-item">
          <font-awesome-icon :icon="stat.icon" size="2xl" style="color: #ffffff;" />
          <p class="stats-value">{{stat.value}}</p>
          <p class="stats-label">{{ stat.label }}</p>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
//import z bazy
import Animal from '../components/Animal.vue'
import PercentTax from '../components/PercentTax.vue'
import { reactive, onMounted, ref } from 'vue';

const animals = reactive([]);
// const MonetarySum = reactive([]);
let currentPage = 1;

const fetchAnimals = async () => {
  try {
    let url = `https://localhost:7241/Animals?page=${currentPage}&pageSize=${animalsPerPage}`;

    const response = await fetch(url);
    const data = await response.json();

    animals.push(...data);
  } catch (error) {
    console.error('Error fetching animals:', error);
  }
};

// const fetchMonetarySum = async () => {
//   try {
//     let url = `https://localhost:7241/MonetarySupportController`;

//     const response = await fetch(url);
//     const data = await response.json();


//     MonetarySum.push(...data);
//   } catch (error) {
//     console.error('Error fetching monetary:', error);
//   }
// };

onMounted(fetchAnimals); // Fetch animals when the component is mounted
// onMounted(fetchMonetarySum);
const animalsPerPage = 4;

const stats = reactive([        
        { icon: "heart", value: "321", label: "zwierząt do adopcji" },
        { icon: "hand-holding-dollar", value: "258 035,25 zł", label: "zebranych środków w ramach wsparcia" },
        { icon: "house", value: "1231", label: "zwierząt znalazło swój dom" }]);

</script>

<!-- <script>
export default {
  data() {
    return {
      images: [
        { src: "/kot_syjamski.png", alt: "obrazek" },
        { src: "/pies1.jpg", alt: "obraz2" },
        { src: "/pies3.jpg", alt: "obraz3" }
      ],
      animals: [
        { name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg" },
        { name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png" },
        { name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg" },
        { name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg" }
      ],
      stats: [
        { icon: "heart", value: "321", label: "zwierząt do adopcji" },
        { icon: "hand-holding-dollar", value: "258 035,25 zł", label: "zebranych środków w ramach wsparcia" },
        { icon: "house", value: "1231", label: "zwierząt znalazło swój dom" }
      ]
    };
  }
};
</script> -->

<style scoped>
.percent-tax-rate-title {
  text-align: center;
  padding: 20px;
  font-size: 35px;
}

.router-link-active {
  text-decoration: none;
}

.animal-adoption {
  display: flex;
  flex-direction: column;
  margin-left: 300px;
  margin-right: 300px;
}

.section-title {
  color: #000;
  text-align: center;
  align-self: start;
  margin-left: 69px;
  font: 400 48px Inter, sans-serif;
}

@media (max-width: 991px) {
  .section-title {
    max-width: 100%;
    font-size: 30px;
    margin-left: 0px;
    align-self: center;
  }
}

.animal-grid {
  margin-top: 39px;
  width: 100%;
  display: flex;
  gap: 20px;
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
  width: 25%;
  margin-left: 0px;
  margin-right: 0px;
}

@media (max-width: 991px) {
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

@media (max-width: 991px) {

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

@media (max-width: 991px) {
  .more-animals-btn {
    padding: 0 20px;
    font-size: 20px;
  }
}

.divider-container {
  align-self: center;
  display: flex;
  margin-top: 67px;
  width: 100%;
  max-width: 1012px;
  flex-direction: column;
  justify-content: center;
}

@media (max-width: 991px) {
  .divider-container {
    max-width: 100%;
    margin-top: 40px;
    
  }

}

.divider {
  border-radius: 20px;
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25);
  background-color: rgba(101, 193, 58, 0.8);
  height: 1px;
}

@media (max-width: 991px) {
  .divider {
    max-width: 100%;
  }
}
</style>