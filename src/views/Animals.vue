<template>
  <div class = "filter-box">
    <div class = "filter-buttons-box">
      <button class = "animal-btn-filter"
        :class="{ 'selected': selectedAnimal === 'pies' }"
        @click="selectAnimal('pies')"><font-awesome-icon icon="dog"/>pies</button>
      <button class = "animal-btn-filter"
        :class="{ 'selected': selectedAnimal === 'kot' }"
        @click="selectAnimal('kot')" ><font-awesome-icon icon="cat"/>kot</button>
      <button class = "gender-btn-filter" @click="toggleGenderOptions">płeć
        <div class="arrow-down"></div>
        <ul class="gender-options" v-show="showGenderOptions">
          <li @click="selectGender('samica')"
          :class="{ 'selectedGender': selectedGender === 'samica' }"
          >Samica</li>
          <li @click="selectGender('samiec')"
          :class="{ 'selectedGender': selectedGender === 'samiec' }"
          >Samiec</li>
        </ul>
      </button>  
    </div>
    <button class = "find-btn" @click="search">szukaj</button>
  </div>
    <div class="animal-adoption">
    <div class="animal-grid">
      <!-- <div v-for="(animal, index) in displayedAnimals" :key="index" class="animal-column">
          <router-link :to="{ name: 'SelectedAnimal', params: { id: animal.id }}" class="router-link-active">
          <img :src="animal.image" :alt="animal.name" class="animal-image" /></router-link>
          <div class="animal-card">           
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
            <div class = "animal-editing">
            <router-link :to="{ name: 'SelectedAnimal', params: { id: animal.id }}" class="editing-button">Edytuj</router-link> 
            <button class="deleting-button">Usuń</button>
          </div>
          </div>
        
      </div> -->
      <div v-for="animal in animals" :key="animal.id" class="animal-column">
          <Animal :animal='animal'></Animal>
      </div>

    </div>
    <button @click="showMoreAnimals" v-if="!allAnimalsDisplayed && displayedAnimals.length < animals.length"  class="more-animals-btn" >Więcej zwierząt</button>
  </div>
</template>


<!-- <script>
import Animal from '@/components/Animal.vue'
import { reactive, onMounted, watch } from 'vue';

export default {
  setup() {
    const animals = reactive([]);
    const displayedAnimals = reactive([]);
    const animalsPerPage = 8;
    let startIndex = 0;
    let allAnimalsDisplayed = false;
    let selectedAnimal = null;
    const filteredAnimals = reactive([]);
    let showGenderOptions = false;
    let selectedGender = null;

    const fetchAnimals = async () => {
      try {
        const response = await fetch('https://localhost:7241/Animals?page=1&pageSize=16');
        const data = await response.json();
        animals.splice(0, animals.length, ...data);
      } catch (error) {
        console.error('Error fetching animals:', error);
      }
    };

    onMounted(fetchAnimals);

    const updateDisplayedAnimals = () => {
      if (selectedAnimal) {
        displayedAnimals.splice(0, displayedAnimals.length, ...animals.filter(animal => animal.animal === selectedAnimal).slice(0, startIndex + animalsPerPage));
      } else {
        displayedAnimals.splice(0, displayedAnimals.length, ...animals.slice(0, startIndex + animalsPerPage));
      }
    };

    watch(() => selectedAnimal, updateDisplayedAnimals);

    const showMoreAnimals = () => {
      startIndex += animalsPerPage;
      updateDisplayedAnimals();

      if ((startIndex + animalsPerPage) >= animals.length) {
        allAnimalsDisplayed = true;
      }
    };

    const selectAnimal = (animal) => {
      if (selectedAnimal === animal) {
        selectedAnimal = null;
      } else {
        selectedAnimal = animal;
        updateDisplayedAnimals();
      }
    };

    const search = () => {
      const genderFilter = selectedGender !== null ? { gender: selectedGender } : {};
      const animalFilter = selectedAnimal !== null ? { animal: selectedAnimal } : {};
      const filters = { ...genderFilter, ...animalFilter };

      if (Object.keys(filters).length === 0) {
        updateDisplayedAnimals();
      } else {
        filteredAnimals.splice(0, filteredAnimals.length, ...animals.filter(animal => {
          return Object.entries(filters).every(([key, value]) => animal[key] === value);
        }));
        displayedAnimals.splice(0, displayedAnimals.length, ...filteredAnimals);
      }
    };

    const toggleGenderOptions = () => {
      showGenderOptions = !showGenderOptions;
    };

    const selectGender = (gender) => {
      if (selectedGender === gender) {
        selectedGender = null;
      } else {
        selectedGender = gender;
        search();
      }
    };

    return {
      animals,
      displayedAnimals,
      animalsPerPage,
      allAnimalsDisplayed,
      selectedAnimal,
      selectedGender,
      showGenderOptions,
      fetchAnimals,
      updateDisplayedAnimals,
      showMoreAnimals,
      selectAnimal,
      search,
      toggleGenderOptions,
      selectGender
    };
  }
};
</script> -->


<script setup>
//import z bazy
import Animal from '../components/Animal.vue'
import { reactive, onMounted } from 'vue';

const animals = reactive([]);

let currentPage = 1;

const fetchAnimals = async () => {
    try {
        const response = await fetch(`https://localhost:7241/Animals?page=${currentPage}&pageSize=${animalsPerPage}`);
        const data = await response.json();
        
        animals.push(...data);
    } catch (error) {
        console.error('Error fetching animals:', error);
    }
};

onMounted(fetchAnimals); // Fetch animals when the component is mounted



import { watch } from 'vue';

const displayedAnimals = reactive([]);
const animalsPerPage = 8;
let allAnimalsDisplayed = false;
let selectedAnimal = null;
const filteredAnimals = reactive([]);
let showGenderOptions = false;
let selectedGender = null;

// Metoda do wczytywania więcej zwierząt
const showMoreAnimals = () => {
  currentPage += 1;

  fetchAnimals();
};

// Metoda do zaznaczania wybranego zwierzęcia
const selectAnimal = (animal) => {
  if (selectedAnimal === animal) {
    selectedAnimal = null;
  } else {
    selectedAnimal = animal;
    updateDisplayedAnimals();
  }
};

// Metoda do filtrowania zwierząt
const search = () => {
  const genderFilter = selectedGender !== null ? { gender: selectedGender } : {};
  const animalFilter = selectedAnimal !== null ? { animal: selectedAnimal } : {};
  const filters = { ...genderFilter, ...animalFilter };

  if (Object.keys(filters).length === 0) {
    updateDisplayedAnimals();
  } else {
    filteredAnimals.splice(0, filteredAnimals.length, ...animals.filter(animal => {
      return Object.entries(filters).every(([key, value]) => animal[key] === value);
    }));
    displayedAnimals.splice(0, displayedAnimals.length, ...filteredAnimals);
  }
};

// Metoda do przełączania opcji płci
const toggleGenderOptions = () => {
  showGenderOptions = !showGenderOptions;
};

// Metoda do zaznaczania wybranej płci
const selectGender = (gender) => {
  if (selectedGender === gender) {
    selectedGender = null;
  } else {
    selectedGender = gender;
    search();
  }
};
</script>




<!-- 
<script>
export default {
  data() {
    return {
      animals: [

    {id:0, name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg", animal: "pies"},
    {id:1, name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png", animal: "kot" },
    {id:2, name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg", animal: "pies" },
    {id:3, name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" },
    {id:4, name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg", animal: "pies"},
    {id:5, name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png", animal: "kot" },
    {id:6, name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg", animal: "pies" },
    {id:7, name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" },
    {id:8, name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg", animal: "pies"},
    {id:9, name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png", animal: "kot" },
    {id:10, name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg", animal: "pies" },
    {id:11, name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" },
    {id:12, name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg", animal: "pies"},
    {id:13, name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png", animal: "kot" },
    {id:14, name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg", animal: "pies" },
    {id:15, name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" },
    {id:16, name: "Azor", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" }
        
      ],
      displayedAnimals: [],
      animalsPerPage: 8,
      startIndex: 0, 
      allAnimalsDisplayed: false,
      selectedAnimal: null,
      filteredAnimals: [],
      showGenderOptions: false,
      selectedGender: null
    };
  },
  created() {
    this.updateDisplayedAnimals();
  },
  methods: {
    updateDisplayedAnimals() {
      if (this.selectedAnimal) {
      this.displayedAnimals = this.animals.filter(animal => animal.animal === this.selectedAnimal).slice(0, this.startIndex + this.animalsPerPage);
      } else {
      this.displayedAnimals = this.animals.slice(0, this.startIndex + this.animalsPerPage);
      }
    },
    showMoreAnimals() {
      this.startIndex += this.animalsPerPage;
      this.updateDisplayedAnimals();

      if ((this.startIndex + this.animalsPerPage) >= this.animals.length) {
        this.allAnimalsDisplayed = true;
      }
    },
      selectAnimal(animal) {
        // Jeśli kliknięty przycisk jest już zaznaczony, odznacz go
        if (this.selectedAnimal === animal) {
          this.selectedAnimal = null;
        } else {
          // W przeciwnym razie zaznacz nowy przycisk i zaktualizuj wyświetlane zwierzęta
          this.selectedAnimal = animal;
          this.updateDisplayedAnimals();
        }
    },
    search() {  
    const genderFilter = this.selectedGender !== null ? { gender: this.selectedGender } : {};
    const animalFilter = this.selectedAnimal !== null ? { animal: this.selectedAnimal } : {};
    const filters = { ...genderFilter, ...animalFilter };

    if (Object.keys(filters).length === 0) {
      this.updateDisplayedAnimals();
    } else {
      this.filteredAnimals = this.animals.filter(animal => {
        return Object.entries(filters).every(([key, value]) => animal[key] === value);
      });
      this.displayedAnimals = this.filteredAnimals;
    }
    },
    toggleGenderOptions() {
      this.showGenderOptions = !this.showGenderOptions;
    },
    selectGender(gender) {
      // Jeśli kliknięta płeć jest już zaznaczona, odznacz ją
      if (this.selectedGender === gender) {
        this.selectedGender = null;
      } else {
        // W przeciwnym razie zaznacz nową płeć i wywołaj wyszukiwanie
        this.selectedGender = gender;
        this.search();
      }
    }
  }
};  

</script> -->



<style scoped>
.animal-editing{
  display: flex;
  margin-top: 10px;  
  margin-bottom: 0;
  width: 100%;
  
}
.editing-button{
  text-decoration: none;
  background-color: rgb(94, 169, 59);
  flex: 1;
  color:white;
  padding-top: 10px;
  padding-bottom: 10px;
}
.deleting-button{
  text-decoration: none;
  background-color: #b25959;
  flex: 1;
  border: none;
  color:white;
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
    margin-bottom: 70px;
  }
}
/*
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
*/
@media (max-width: 991px) {
  .animal-card {
    margin-top: 40px;
    width: 70%;
    padding-bottom: 9px;
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
*/
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
.find-btn{
  border-radius: 50%;
  background-color: #703f11;
  align-self: center;
  margin-top: 40px;
  color: #fff;
  text-align: center;
  padding: 17px 28px 10px;
  font: italic 400 32px Inter, sans-serif;
  border: none;
  cursor: pointer;
  text-decoration: none;
  margin-left: auto;
}
.filter-box{
  display: flex;
  margin-left: 300px;
  margin-right: 300px;
  justify-content: space-between;
  align-items: center;
  flex-wrap: wrap;
  margin-bottom: 50px;
}
.filter-box button{
  margin-right: 40px;
}
@media (max-width: 1500px) {
  .filter-box{
  margin-left: auto;
  margin-right: auto;
  }
  .filter-box button{
  margin-right: auto;
  }
}
.animal-btn-filter{
  border-radius: 50%;
  background-color: white;
  align-self: center;
  margin-top: 40px;
  color: rgb(94, 169, 59);
  text-align: center;
  padding: 17px 28px 10px;
  font: italic 400 32px Inter, sans-serif;
  cursor: pointer;
  text-decoration: none;
  border: 1px solid rgb(94, 169, 59);  
}
.gender-btn-filter{
  border-radius: 50%;
  background-color: white;
  align-self: center;
  margin-top: 40px;
  color: rgb(94, 169, 59);
  text-align: center;
  padding: 17px 28px 10px;
  font: italic 400 32px Inter, sans-serif;
  cursor: pointer;
  text-decoration: none; 
  border: 1px solid rgb(94, 169, 59);
  position: relative;
  display: inline-block;
}
.arrow-down {
  position: absolute; 
  top: 50%; 
  right: 10px; 
  transform: translateY(-50%); 
  width: 0;
  height: 0;
  border-left: 5px solid transparent; 
  border-right: 5px solid transparent; 
  border-top: 5px solid rgb(94, 169, 59);
}
.filter-buttons-box{
  display: flex;
  padding: 10px;
  gap: 10px;
}
@media (max-width: 1100px) {
  .gender-btn-filter{
    padding: 8px 17px 8px;
    font: italic 400 16px Inter, sans-serif;
  }
  .animal-btn-filter{
    padding: 8px 17px 8px;
    font: italic 400 16px Inter, sans-serif;
  }
  .find-btn{
    padding: 8px 17px 8px;
    font: italic 400 16px Inter, sans-serif;
  }
}
.selectedGender,
.selected {
  background-color: rgb(227, 227, 129);
}
.gender-options {
  position: absolute;
  top: calc(100% + 5px);
  z-index: 1;
  margin: 0;
  padding: 0;
  background-color: white;
  border: 1px solid rgb(94, 169, 59);
  border-radius: 7px;
}

.gender-options li {
  padding: 10px;
  cursor: pointer;
  font-size: 15px;
}

.gender-options li:hover {
  background-color: rgb(245, 245, 245);
}
</style>
