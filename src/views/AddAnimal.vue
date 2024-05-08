<template>
    <div class="add-animal-container">
      <h2>Dodaj nowe zwierzę</h2>
      <form @submit.prevent="dodajZwierze">
        <div class="form-group">
          <label for="name">Imię:</label>
          <input type="text" id="name" v-model="form.name" required>
        </div>
        <div class="form-group">
          <label for="age">Wiek:</label>
          <input type="text" id="age" v-model="form.age" required>
        </div>
        <div class="form-group">
          <label for="breed">Rasa:</label>
          <input type="text" id="breed" v-model="form.breed" required>
        </div>
        <div class="form-group">
          <label for="localization">Lokalizacja:</label>
          <input type="text" id="localization" v-model="form.localization" required>
        </div>
        <div class="form-group">
          <label for="image">Zdjęcie:</label>
          <input type="file" id="image" accept="image/*" @change="handleImageUpload">
        </div>
        <div class="form-group">
          <label for="description">Opis:</label>
          <textarea id="description" v-model="form.description" rows="4"></textarea>
        </div>
        <!-- Dodane inputy checkbox -->
        <div class="form-group">
          <label for="childFriendly">Przyjazny dzieciom:</label>
          <input type="checkbox" id="childFriendly" v-model="form.childFriendly">
        </div>
        <div class="form-group">
          <label for="catFriendly">Przyjazny kotom:</label>
          <input type="checkbox" id="catFriendly" v-model="form.catFriendly">
        </div>
        <div class="form-group">
          <label for="dogFriendly">Przyjazny psom:</label>
          <input type="checkbox" id="dogFriendly" v-model="form.dogFriendly">
        </div>
        <div class="form-group">
          <label for="likesToPlay">Lubi bawić się:</label>
          <input type="checkbox" id="likesToPlay" v-model="form.likesToPlay">
        </div>
        <div class="form-group">
          <label for="likesToCuddle">Lubi przytulać się:</label>
          <input type="checkbox" id="likesToCuddle" v-model="form.likesToCuddle">
        </div>
        <div class="form-group">
          <label for="doesntLikeShelter">Nie lubi schroniska:</label>
          <input type="checkbox" id="doesntLikeShelter" v-model="form.doesntLikeShelter">
        </div>
        <button type="submit">Dodaj</button>
      </form>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import axios from 'axios';
  
  const form = ref({
    name: '',
    age: '',
    breed: '',
    localization: '',
    image: null,
    description: '',
    childFriendly: false,
    catFriendly: false,
    dogFriendly: false,
    likesToPlay: false,
    likesToCuddle: false,
    doesntLikeShelter: false,
  });
  
  const dodajZwierze = async () => {
    try {
      const formData = new FormData();
      formData.append('name', form.value.name);
      formData.append('age', form.value.age);
      formData.append('breed', form.value.breed);
      formData.append('localization', form.value.localization);
      formData.append('image', form.value.image);
      formData.append('description', form.value.description); // Dodanie opisu
      formData.append('childFriendly', form.value.childFriendly);
      formData.append('catFriendly', form.value.catFriendly);
      formData.append('dogFriendly', form.value.dogFriendly);
      formData.append('likesToPlay', form.value.likesToPlay);
      formData.append('likesToCuddle', form.value.likesToCuddle);
      formData.append('doesntLikeShelter', form.value.doesntLikeShelter);
      
      const response = await axios.post('https://localhost:7241/Animals/add', formData);
      console.log('Odpowiedź serwera:', response.data);
      // Po udanym dodaniu możemy przekierować użytkownika lub wykonać inne akcje
    } catch (error) {
      console.error('Błąd podczas dodawania zwierzęcia:', error);
      // Obsłuż błąd, np. wyświetlając komunikat dla użytkownika
    }
  };
  
  const handleImageUpload = (event) => {
    form.value.image = event.target.files[0];
  };
  </script>
  
  <style scoped>
  .add-animal-container {
    max-width: 600px;
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
  
  button[type="submit"] {
    padding: 10px 20px;
    background-color: #007bff;
    color: #fff;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-size: 16px;
  }
  
  button[type="submit"]:hover {
    background-color: #0056b3;
  }
  </style>
  