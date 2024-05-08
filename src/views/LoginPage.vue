<template>
    <div class="login-container">
        <h2>Login</h2>
        <form @submit.prevent="login">
          <div class="form-group">
            <label for="email">Email:</label>
            <input type="email" id="email" v-model="email" required />
          </div>
          <div class="form-group">
            <label for="password">Password:</label>
            <input type="password" id="password" v-model="password" required />
          </div>
          <button type="submit">Login</button>
        </form>
      </div>
    
    
      <div>
        <button v-if="isLoggedIn" @click="dodaj">Dodaj</button>
      </div>
    </template>
    
    <script setup>
    import { ref } from 'vue';
    
    const email = ref('');
    const password = ref('');
    
    
    const login = async () => {
      // Dane do wysłania na serwer
      const formData = {
        email: email.value,
        password: password.value,
        twoFactorCode: "",
        twoFactorRecoveryCode: "",
      };
    
    try {
        const response = await fetch('https://localhost:7241/login?useCookies=true&useSessionCookies=false', {
          method: 'POST',
          credentials: 'include',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(formData),
        });
    
        if (response.ok) {
          console.log('Login successful!'); // Tutaj możesz obsłużyć sukces logowania
          
          // Na przykład przekierować użytkownika na inną stronę
        } else {
          console.error('Login failed:', response.statusText);
          // Tutaj możesz obsłużyć nieudane logowanie, np. wyświetlając komunikat dla użytkownika
        }
    }
    catch (error) {
        console.error('Error during login:', error);
        // Tutaj możesz obsłużyć błędy sieciowe lub inne błędy związane z logowaniem
      }
    };
    
    

    import { useRouter } from 'vue-router';

    const isLoggedIn = ref(true);  //token
    const router = useRouter();

    const przeniesDoStronyZInputami = () => {
    // Przeniesienie użytkownika do strony z inputami
    router.push('/strona-z-inputami');
    };

    const dodaj = () => {
    // Logika dodawania
    console.log('Przycisk "Dodaj" został kliknięty');
    };
    </script>
    
    <style scoped>
    .login-container {
      max-width: 500px;
      margin: auto;
      margin-top: 5%;
      margin-bottom: 5%;
      padding: 20px;
      border: 1px solid #ccc;
      border-radius: 5px;
    }
    
    .form-group {
      margin-bottom: 15px;
    }
    
    label {
      display: block;
      margin-bottom: 5px;
    }
    
    input[type="email"],
    input[type="password"] {
      padding: 10px;
      font-size: 16px;
      border: 1px solid #ccc;
      border-radius: 5px;
      position: center;
    }
    
    button {
      background-color: rgb(94, 169, 59);
      color: #fff;
      padding: 10px 20px;
      border: none;
      border-radius: 5px;
      cursor: pointer;
    }
    
    button:hover {
      background-color: #96D879;
    }
    </style>