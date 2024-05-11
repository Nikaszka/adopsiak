<template>
  <router-link :to="{ name: 'SelectedAnimal', params: { id: animal.id } }" class="router-link-active">
    <div class="animal-card">
      <img v-if="animal.animalPhotoId" :src='getPhoto(animal.animalPhotoId)' :alt="animal.name" class="animal-image" />
      <h3 class="animal-name">{{ animal.name }}</h3>
      <div class="animal-breed">
        <font-awesome-icon icon="paw" />
        <span class="breed-name">{{ animal.breed }}</span>
      </div>
      <div class="animal-gender">
        <font-awesome-icon icon="venus-mars" />
        <span class="gender-age">{{ animal.gender === 0 ? 'samiec' : 'samica' }}, {{ animal.age }}</span>
      </div>
      <div class="animal-location">
        <font-awesome-icon icon="location-dot" />
        <span class="location-address">{{ animal.localization }}</span>
      </div>
      <div v-if="store.userLogged && showButtons" class="animal-editing">
        <router-link :to="`/animal/edit/${animal.id}`" class="editing-button">Edytuj</router-link>
        <router-link :to="`/animals`" class="deleting-button" @click="deleteAnimal(animal)">Usuń</router-link>
      </div>
    </div>
  </router-link>
</template>

<script setup>
import { defineProps } from 'vue';
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { refreshStore, store } from '@/session.js';

const props = defineProps({
  animal: Object,
  showButtons: {
    type: Boolean,
    default: true,
  }
});

const baseUrl = 'https://localhost:7241/AnimalPhoto/';
const getPhoto = (animalPhotoId) => {
  return `${baseUrl}${animalPhotoId}`;
};

const deleteAnimal = async (animal) => {
  const confirmed = window.confirm(`"${animal.name}": Czy na pewno chcesz usunąć to zwierzę?`);
  if (confirmed) {

    try {
      const response = await fetch(`https://localhost:7241/Animals/delete/${animal.id}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        console.log('Animal deleted successfully');
        window.location.reload();
      } else {
        console.error('Failed to delete animal');
      }
    } catch (error) {
      console.error('Error deleting animal:', error);
    }
  }
};
</script>

<style scoped>
.animal-editing {
  display: flex;
  margin-top: 10px;
  margin-bottom: 0;
  width: 100%;
}

.editing-button {
  text-decoration: none;
  background-color: rgb(94, 169, 59);
  flex: 1;
  color: white;
  padding-top: 10px;
  padding-bottom: 10px;
}

.deleting-button {
  text-decoration: none;
  background-color: #b25959;
  flex: 1;
  border: none;
  color: white;
  cursor: pointer;
  padding-top: 10px;
  padding-bottom: 10px;
}


.router-link-active {
  text-decoration: none;
}

.animal-card {
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25);
  background-color: #fdfafa;
  display: flex;
  width: 100%;
  flex-grow: 1;
  /* padding-bottom: 9px; */
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
</style>