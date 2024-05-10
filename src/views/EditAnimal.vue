<template>
  <div class="edit-animal-container">
    <h1>Edytuj dane zwierzaka</h1>
    <div class="animal-details">
      <div class="form-group">
        <!-- <label for="genus">Płeć:</label> -->
        <select id="genus" v-model="animal.genus" class="form-select">
          <option value=0>Kot</option>
          <option value=1>Pies</option>
        </select>
      </div>
      <div class="form-group">
        <label for="name">Imię:</label>
        <input type="text" id="name" v-model="animal.name" class="form-input" />
      </div>
      <div class="form-group">
        <label for="breed">Rasa:</label>
        <input type="text" id="breed" v-model="animal.breed" class="form-input" />
      </div>
      <div class="form-group">
        <label for="gender">Płeć:</label>
        <select id="gender" v-model="animal.gender" class="form-select">
          <option value=0>Samiec</option>
          <option value=1>Samica</option>
        </select>
      </div>
      <div class="form-group">
        <label for="age">Wiek:</label>
        <input type="text" id="age" v-model.number="animal.age" class="form-input" />
      </div>
      <div class="form-group">
        <label for="localization">Lokalizacja:</label>
        <input type="text" id="localization" v-model="animal.localization" class="form-input" />
      </div>

      <div class="image-container">
        <div>
          <label>Obecne zdjęcie:</label>
          <img v-if="animal.animalPhotoId" :src='getPhoto(animal.animalPhotoId)' :alt="animal.name"
            class="animal-image" />
          <img v-if="!animal.animalPhotoId" :alt="animal.name" class="animal-image" />
        </div>
        <!-- Input for choosing a new image -->
        <div>
          <label for="image">Zdjęcie:</label>
          <input type="file" id="image" ref="fileInput" accept="image/*" @change="handleFileChange">
        </div>
      </div>


      <div class="form-group">
        <label for="description">Opis:</label>
        <textarea type="text" id="description" v-model="animal.description" class="form-input"> </textarea>
      </div>

      <div class="other-benefits">
        <div class="animal-benefits">
          <font-awesome-icon icon="heart" class="heart-icon" />
          <input type="text" id="myInput" value="Uwielbia pieszczoty"></input>
        </div>
        <div class="animal-benefits">
          <font-awesome-icon icon="heart" class="heart-icon" />
          <input type="text" id="myInput" value="Uwielbia zabawę" class="gender-age"></input>
        </div>
        <div class="animal-benefits">
          <font-awesome-icon icon="heart" class="heart-icon" />
          <input type="text" id="myInput" value="Akceptuje inne zwierzęta"></input>
        </div>
      </div>
      <div class="form-group">
        <label for="status">Status:</label>
        <select id="status" v-model="animal.status" class="form-select">
          <option value=0>Do adopcji</option>
          <option value=1>Adoptowany</option>
        </select>
        <router-link :to="'/animals'">
          <button @click="saveChanges" class="submit-button">Zapisz zmiany</button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { defineProps } from 'vue'
const fileInput = ref(null);
let selectedFile = null;

function handleFileChange(event) {
  if (event) {
    selectedFile = event.target.files[0];
  } else {
    selectedFile = null;
  }
}

const deleteAnimalPhoto = async (id) => {
  try {
    const response = await fetch(`https://localhost:7241/Animals/${id}/deletePhoto`, {
      method: 'DELETE',
    });
  } catch (error) {
    if (error.status != 404) {
      console.error('Error deleting animal photo:', error);
    }
  }

};





async function uploadImage() {
  const imageData = new FormData();
  imageData.append('photo', selectedFile);

  try {
    const response = await fetch(`https://localhost:7241/Animals/${props.id}/addPhoto`, {
      method: 'POST',
      body: imageData,
    });

    if (!response.ok) {
      throw new Error('Failed to upload image.');
    }

  } catch (error) {
    console.error('Error uploading image:', error);
  }
}

const props = defineProps(['id'])
const animal = ref({
  name: '',
  breed: '',
  gender: '',
  age: '',
  localization: '',
  description: '',
  childFriendly: '',
  catFriendly: '',
  dogFriendly: '',
  likesToPlay: '',
  likesToCuddle: '',
  doesntLikeShelter: '',
  genus: '',
  status: ''
})

const fetchAnimalData = async () => {
  try {
    const response = await fetch(`https://localhost:7241/animals/${props.id}`)
    const data = await response.json()
    animal.value = data
    // Ustawienie wartości gender na podstawie danych zwierzaka z serwera
    if (data.gender === 'male' || data.gender === 'female') {
      animal.gender = data.gender;
    } else {
      animal.gender = '';
    }
  } catch (error) {
    console.error('Error fetching animal data:', error)
  }
}

onMounted(fetchAnimalData)

const saveChanges = async () => {
  try {
    const response = await fetch(`https://localhost:7241/animals/update/${props.id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(animal.value)
    })
    if (!response.ok) {
      throw new Error('Network response was not ok')
    }
    const data = await response.json()

    if (selectedFile) {
      if (animal.animalPhotoId) {
        deleteAnimalPhoto(props.id)
      }
      uploadImage()
      window.location.reload();
    }

    console.log('Changes saved successfully:', data)
  } catch (error) {
    console.error('Error saving changes:', error)
  }
}


const baseUrl = 'https://localhost:7241/AnimalPhoto/';
const getPhoto = (animalPhotoId) => {
  return `${baseUrl}${animalPhotoId}`;
};
</script>

<style scoped>
.edit-animal-container {
  text-align: center;
}

.animal-details {
  margin: 0 auto;
  max-width: 400px;
}

.form-group {
  margin-bottom: 20px;
}

.form-input,
.form-select {
  font-family: Inter, sans-serif;
  align-items: start;
  border: 1px solid rgba(209, 209, 209, 1);
  background-color: #fff;
  padding: 10px;
  width: calc(100% - 22px);
}

.form-select {
  width: 100%;
}

.submit-button {
  border-radius: 10px;
  border: 1px solid rgba(0, 0, 0, 1);
  background-color: #fff;
  color: #000;
  margin-top: 30px;
  padding: 8px 41px 12px;
  font: 400 18px Inter, sans-serif;
  cursor: pointer;
}

.submit-button:hover {
  background-color: #d9d9d9;
}


.animal-image {
  /* max-width: 100%; */
  width: 130px;
  margin-bottom: 20px;
  padding-top: 10px;
}

.image-label {
  display: block;
  margin-bottom: 10px;
}

.image-container {
  display: flex;
}

.image-container div input {
  padding-left: 20px;
  padding-top: 15px;
  border: none;
}

textarea {
  min-height: 100px;
}


.info-icon,
.heart-icon {
  font-size: 35px;
}

.heart-icon {
  color: green;
}

.animal-form-title {
  margin-left: 5px;
  margin-right: 5px;
  margin-bottom: 10px;
}

@media (max-width: 991px) {

  .info-icon,
  .heart-icon {
    font-size: 18px;
  }

  .other-benefits {
    margin-top: 10px;
  }
}

.animal-benefits {
  display: flex;
  white-space: nowrap;
  align-items: center;
  padding: 10px;
  gap: 15px;
}

input[type="text"],
input[type="file"],
textarea {
  width: 100%;
  padding: 10px;
  box-sizing: border-box;
  border: 1px solid #ccc;
  border-radius: 5px;
}
</style>
