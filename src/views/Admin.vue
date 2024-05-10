<template>
    <div class="welcome-page">
        <h1>Witaj, <i style="color: rgb(94, 169, 59);">{{ username }}</i>!</h1>
        <p>Jesteś zalogowany jako administrator.</p>
        <p>Tutaj możesz zarządzać zawartością strony.</p>
        <div class="logout-button">
            <button @click="logOut">Wyloguj</button>
        </div>
    </div>

    <div class="inbox">
    <h1>Skrzynka odbiorcza</h1>
    <div v-if="forms.length === 0">Brak formularzy do wyświetlenia.</div>
    <div v-else>
      <div v-for="form in forms" :key="form.id" class="form-item">
        <p>Identyfikator zgłoszenia: {{ form.id }}</p>
        <p>Od: {{ form.emailAddress }}</p>
        <button @click="viewFormDetails(form.id)">Pokaż szczegóły</button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { getUserLogged, store } from '@/session.js';
import { onMounted, ref } from 'vue'
import { useRouter } from 'vue-router';

const router = useRouter();

const username = ref('');

onMounted(() => {
    username.value = getUserLogged();
})

const logOut = async () => {
    await fetch('https://localhost:7241/logout', {
        method: 'POST',
        credentials: 'include',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    store.userLogged = false;
    router.push('/admin/login');
}

const forms = ref([]);

const fetchForms = async () => {
  try {
    const response = await fetch('https://localhost:7241/AdoptionForms/', {
      method: 'GET',
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('accessToken')}` // Przykładowe uwierzytelnienie
      }
    });
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    forms.value = data;
  } catch (error) {
    console.error('Error fetching forms:', error);
  }
};

onMounted(fetchForms);

const viewFormDetails = (formId) => {
  router.push({ name: 'FormDetails', params: { id: formId } });
};
</script>


<style scoped>
.welcome-page {
    text-align: center;
    margin-top: 50px;
}

h1 {
    font-size: 32px;
    color: #333;
}

p {
    font-size: 18px;
    color: #666;
    margin-bottom: 20px;
}

.logout-button {
    margin-top: 30px;
}

button {
  background-color: rgb(169, 70, 59);
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

button:hover {
  background-color: #f0522f;
}

/* inbox */

.inbox {
  text-align: center;
  margin-top: 50px;
}

h1 {
  font-size: 32px;
  color: #333;
}

.form-item {
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 10px;
  margin-bottom: 10px;
}

button {
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 5px;
  padding: 5px 10px;
  cursor: pointer;
}

button:hover {
  background-color: #0056b3;
}
</style>
