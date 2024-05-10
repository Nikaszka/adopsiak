<template>
  <div class="add-animal-container">
    <h2>Dodaj nowe zwierzę</h2>
    <form @submit.prevent="submitForm">
      <div class="animal-type-gender form-group">
        <label for="animalType">Zwierzę:</label>
        <select id="animalType" v-model="formData.genus">
          <option :value="0">Kot</option>
          <option :value="1">Pies</option>
        </select>
        <label for="gender">Płeć:</label>
        <select id="gender" v-model="formData.gender">
          <option :value="1">Samica</option>
          <option :value="0">Samiec</option>
        </select>
      </div>
      <div class="form-group">
        <label for="name">Imię:</label>
        <input type="text" id="name" v-model="formData.name" required>
      </div>
      <div class="form-group">
        <label for="age">Wiek:</label>
        <input type="text" id="age" v-model="formData.age" required>
      </div>
      <div class="form-group">
        <label for="breed">Rasa:</label>
        <input type="text" id="breed" v-model="formData.breed" required>
      </div>
      <div class="form-group">
        <label for="localization">Lokalizacja:</label>
        <input type="text" id="localization" v-model="formData.localization" required>
      </div>
      <div class="form-group">
        <label for="image">Zdjęcie:</label>
        <input type="file" id="image" ref="fileInput" accept="image/*" @change="handleFileChange">
      </div>
      <div class="form-group">
        <label for="description">Opis:</label>
        <textarea id="description" v-model="formData.description" rows="4"></textarea>
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

      <button class="button-add" type="submit">Dodaj</button>
    </form>
  </div>
</template>

<script setup>

import { computed, ref, onMounted, reactive } from 'vue'
const props = defineProps(['id'])

const formData = ref({
  name: '',
  genus: 1,
  gender: 0,
  age: '',
  breed: '',
  localization: '',
  description: '',
  status: 0,
});

const fileInput = ref(null);
let selectedFile = null;

function handleFileChange(event) {
  if (event) {
    selectedFile = event.target.files[0];
  } else {
    selectedFile = null;
  }
}

async function uploadImage() {
  const imageData = new FormData();
  imageData.append('photo', selectedFile);

  try {
    const response = await fetch(`https://localhost:7241/Animals/${newAnimalId.value}/addPhoto`, {
      method: 'POST',
      body: imageData,
    });

    if (!response.ok) {
      throw new Error('Failed to upload image.');
    }

  } catch (error) {
    console.error('Error uploading image:', error);
    alert('Failed to upload image.');
  }
}


const newAnimalId = ref();
const submitForm = async () => {

  const url = "https://localhost:7241/Animals/add";
  if (allFieldsFilled()) {
    try {
      const response = await fetch(url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData.value)
      });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      newAnimalId.value = data;

      uploadImage();

      console.log('Formularz został pomyślnie przesłany:', newAnimalId.value);
      resetForm();
    } catch (error) {
      console.error('Wystąpił błąd podczas wysyłania formularza:', error);
    }
  } else {
    alert("Proszę uzupełnić wszystkie pola formularza.")
  }

};

const resetForm = () => {
  formData.value = {
    name: '',
    genus: 1,
    gender: 0,
    age: '',
    breed: '',
    localization: '',
    description: '',
  }
  selectedFile = null;
  fileInput.value.value = ''
  handleFileChange();

};


function allFieldsFilled() {
  // Sprawdź, czy wszystkie pola są uzupełnione
  if (!selectedFile) {
    alert('Please select a file.');
    return false;
  }

  return Object.values(formData.value).every(value => value !== "")
}

</script>

<style scoped>
.add-animal-container {
  max-width: 600px;
  min-width: 400px;
  margin: 0 auto;
}

.form-group {
  margin-bottom: 20px;
}

label {
  display: block;
  font-weight: bold;
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

.animal-benefits input {
  font: italic 400 16px Inter, sans-serif;
}

@media (max-width: 900px) {
  .text-area {
    font: italic 400 15px Inter, sans-serif;
    /* margin: 10px; */
  }

  .animal-benefits input {
    font: italic 400 13px Inter, sans-serif;
  }

  .animal-benefits {
    padding: 3px;
  }
}

.button-add {
  border-radius: 20px;
  background-color: rgb(94, 169, 59);
  align-self: center;
  margin-top: 40px;
  color: white;
  text-align: center;
  padding: 10px 20px;
  font: italic 20px Inter, sans-serif;
  cursor: pointer;
  text-decoration: none;
  border: 1px solid rgb(94, 169, 59);
  display: block;
  margin: auto;
}

.button-add:hover {
  background-color: #96D879;
}

.animal-type-gender {
  display: flex;
  align-items: center;
}

.animal-type-gender label {
  margin-right: 10px;
}

.animal-type-gender select {
  width: 80px;
  /* padding-right: 10px; */
  margin-right: 20px;
}
</style>