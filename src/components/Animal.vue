<script setup>
const props = defineProps(['animal'])

const baseUrl = 'https://localhost:7241/AnimalPhoto/';
const getPhoto = (animalPhotoId) => {
  return `${baseUrl}${animalPhotoId}`;
};

</script>


<template>
        <router-link :to="{ name: 'SelectedAnimal', params: { id: animal.id }}" class="router-link-active">
          <div class="animal-card">
            <!-- <img src='https://localhost:7241/AnimalPhoto/8439f023-f3b1-4fb2-af6e-ab9f4332b3c2' :alt="animal.name" class="animal-image" /> -->
            <img v-if="animal.animalPhotoId" :src='getPhoto(animal.animalPhotoId)' :alt="animal.name" class="animal-image" />
            <img v-if="!animal.animalPhotoId" :alt="animal.name" class="animal-image" />
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
          </div>
        </router-link>
</template>

<style scoped>
.router-link-active {
  text-decoration: none;
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
</style>