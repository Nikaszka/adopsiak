<template>
    <p>Witaj {{ username }}</p>

    <div>
        <button @click="logOut">Wyloguj</button>
    </div>
</template>

<script setup>
import { getUserLogged } from '@/session.js';
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
    router.push('/admin/login');
}

</script>