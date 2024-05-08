<template>
  <div class="filter-box">
    <div class="filter-buttons-box">
      <button class="animal-btn-filter" :class="{ 'selected': selectedAnimal === 'dog' }"
        @click="selectAnimal('dog')"><font-awesome-icon icon="dog" />pies</button>
      <button class="animal-btn-filter" :class="{ 'selected': selectedAnimal === 'cat' }"
        @click="selectAnimal('cat')"><font-awesome-icon icon="cat" />kot</button>
      <button class="gender-btn-filter" @click="toggleGenderOptions">płeć
        <div class="arrow-down"></div>
        <ul class="gender-options" v-if="showGenderOptions">
          <li @click="selectGender('female')" :class="{ 'selectedGender': selectedGender === 'female' }">Samica</li>
          <li @click="selectGender('male')" :class="{ 'selectedGender': selectedGender === 'male' }">Samiec</li>
        </ul>
      </button>
    </div>
    <button class="find-btn" @click="search">szukaj</button>
  </div>
  <div class="animal-adoption">
    <div class="animal-grid">
      <div v-for="animal in animals" :key="animal.id" class="animal-column">
        <Animal :animal='animal'></Animal>
      </div>
    </div>
    <button @click="showMoreAnimals" class="more-animals-btn">Więcej zwierząt</button>
  </div>
</template>

<script setup>
//import z bazy
import Animal from '../components/Animal.vue'
import { reactive, onMounted, ref } from 'vue';

const animals = reactive([]);

let currentPage = 1;

const fetchAnimals = async () => {
  try {
    let url = `https://localhost:7241/Animals?page=${currentPage}&pageSize=${animalsPerPage}`;

    if (selectedAnimal) {
      url += `&genus=${selectedAnimal}`
    }
    if (selectedGender) {
      url += `&gender=${selectedGender}`
    }
    const response = await fetch(url);
    const data = await response.json();

    animals.push(...data);
  } catch (error) {
    console.error('Error fetching animals:', error);
  }
};

onMounted(fetchAnimals); // Fetch animals when the component is mounted

const animalsPerPage = 8;
let selectedAnimal = null;
let selectedGender = null;
const showGenderOptions = ref(false);

// Metoda do wczytywania więcej zwierząt
const showMoreAnimals = () => {
  currentPage += 1;

  fetchAnimals();
};

const resetList = () => {
  currentPage = 1;
  animals.splice(0, animals.length);
}

// Metoda do zaznaczania wybranego zwierzęcia
const selectAnimal = (animal) => {
  if (selectedAnimal === animal) {
    selectedAnimal = null;
  } else {
    selectedAnimal = animal;
  }
  resetList();
  fetchAnimals();
};

// Metoda do przełączania opcji płci
const toggleGenderOptions = () => {
  showGenderOptions.value = !showGenderOptions.value;
};

// Metoda do zaznaczania wybranej płci
const selectGender = (gender) => {
  if (selectedGender === gender) {
    selectedGender = null;
  } else {
    selectedGender = gender;
  }
  resetList();
  fetchAnimals();
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

.find-btn {
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

.filter-box {
  display: flex;
  margin-left: 300px;
  margin-right: 300px;
  justify-content: space-between;
  align-items: center;
  flex-wrap: wrap;
  margin-bottom: 50px;
}

.filter-box button {
  margin-right: 40px;
}

@media (max-width: 1500px) {
  .filter-box {
    margin-left: auto;
    margin-right: auto;
  }

  .filter-box button {
    margin-right: auto;
  }
}

.animal-btn-filter {
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

.gender-btn-filter {
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

.filter-buttons-box {
  display: flex;
  padding: 10px;
  gap: 10px;
}

@media (max-width: 1100px) {
  .gender-btn-filter {
    padding: 8px 17px 8px;
    font: italic 400 16px Inter, sans-serif;
  }

  .animal-btn-filter {
    padding: 8px 17px 8px;
    font: italic 400 16px Inter, sans-serif;
  }

  .find-btn {
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
