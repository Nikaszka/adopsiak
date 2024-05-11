<template>
  <div class="form-details">
    <h1>Szczegóły formularza</h1>
    <div v-if="form">
      <div class="form-info">
        <p><strong>Numer zgłoszenia:</strong> {{ form.id }}</p>
        <p><strong>Imię:</strong> {{ form.firstName }}</p>
        <p><strong>Nazwisko:</strong> {{ form.lastName }}</p>
        <p><strong>Adres email:</strong> {{ form.emailAddress }}</p>
        <p><strong>Numer telefonu:</strong> {{ form.phoneNumber }}</p>
        <p><strong>Adres:</strong> {{ form.streetName }}, {{ form.apartmentNumber }}, {{ form.city }}, {{ form.zipCode
          }}, {{ form.voivodeship }}</p>
        <p><strong>Wybrane zwierzę:</strong>
          <Animal :animal='form.selectedAnimal' :showButtons=false class="selected-animal"></Animal>
        </p>
        <h2>Odpowiedzi na pytania:</h2>
        <ul class="answer-list">
          <li><strong>O środowisko:</strong> {{ form.aboutEnviroment }}</li>
          <li><strong>O doświadczeniu z zwierzętami:</strong> {{ form.aboutExperienceWithAnimals }}</li>
          <li><strong>O innych zwierzętach w domu:</strong> {{ form.aboutOtherAnimals }}</li>
          <li><strong>O odpowiedzialności:</strong> {{ form.aboutResponsibility }}</li>
        </ul>
      </div>
    </div>
    <div v-else>
      <p class="loading-message">Ładowanie...</p>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import Animal from '../components/Animal.vue'

const router = useRouter();
const form = ref(null);

const fetchFormDetails = async () => {
  try {
    const formId = router.currentRoute.value.params.id;
    const response = await fetch(`https://localhost:7241/AdoptionForms/${formId}`, {
      method: 'GET',
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('accessToken')}`
      }
    });
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    const formData = await response.json();
    form.value = formData;
  } catch (error) {
    console.error('Error fetching form details:', error);
  }
};

onMounted(fetchFormDetails);
</script>

<style scoped>
.form-details {
  text-align: center;
  margin-top: 50px;
}

h1 {
  font-size: 32px;
  color: #333;
  margin-bottom: 20px;
}

h2 {
  color: #7fc160;
}

p {
  font-size: 18px;
  color: #666;
  margin-bottom: 10px;
}

li {
  font-size: 18px;
  color: #666;
  margin-bottom: 15px;
}

.form-info {
  margin-bottom: 30px;
}

.loading-message {
  font-size: 18px;
  color: #666;
}

.selected-animal{
  display: block;
  max-width: 310px;
  margin: 18px auto;
  display: flex;
  justify-content: center; 
  align-items: center; 
}
</style>
