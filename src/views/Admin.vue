<template>
    <div class="welcome-page">
        <h1>Witaj, <i style="color: rgb(94, 169, 59);">{{ username }}</i>!</h1>
        <p>Jesteś zalogowany jako administrator.</p>
        <p>Tutaj możesz zarządzać zawartością strony.</p>
        <div class="logout-button">
            <button @click="logOut">Wyloguj</button>
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
</style>