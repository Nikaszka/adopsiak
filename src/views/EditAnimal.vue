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
      <div class="form-group">
        <label for="description">Opis:</label>
        <textarea type="text" id="description" v-model="animal.description" class="form-input" > </textarea>
      </div>
      <div class="form-group">
          <label for="childFriendly">Przyjazny dzieciom:</label>
          <input type="checkbox" id="childFriendly" v-model="animal.childFriendly">
        </div>
        <div class="form-group">
          <label for="catFriendly">Przyjazny kotom:</label>
          <input type="checkbox" id="catFriendly" v-model="animal.catFriendly">
        </div>
        <div class="form-group">
          <label for="dogFriendly">Przyjazny psom:</label>
          <input type="checkbox" id="dogFriendly" v-model="animal.dogFriendly">
        </div>
        <div class="form-group">
          <label for="likesToPlay">Lubi bawić się:</label>
          <input type="checkbox" id="likesToPlay" v-model="animal.likesToPlay">
        </div>
        <div class="form-group">
          <label for="likesToCuddle">Lubi przytulać się:</label>
          <input type="checkbox" id="likesToCuddle" v-model="animal.likesToCuddle">
        </div>
        <div class="form-group">
          <label for="doesntLikeShelter">Nie lubi schroniska:</label>
          <input type="checkbox" id="doesntLikeShelter" v-model="animal.doesntLikeShelter">
        </div>
        <div class="form-group">
        <label for="status">Status:</label> 
        <select id="status" v-model="animal.status" class="form-select">
          <option value=0>Do adopcji</option>
          <option value=1>Adoptowany</option>
        </select>
      <button @click="saveChanges" class="submit-button">Zapisz zmiany</button>
    </div>
  </div>
</div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { defineProps } from 'vue'

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
    console.log('Changes saved successfully:', data)
  } catch (error) {
    console.error('Error saving changes:', error)
  }
}
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
</style>

