<template>
  <div class="contact-container">
    <div class="contact-form">
      <h2 class="form-title">Napisz do nas!</h2>
      <div class="form-container">
        <form class="contact-form-fields" @submit.prevent="submitForm">
          <div class="form-group">
            <label for="topic"></label>
            <textarea
              id="topic"
              v-model="formData.topic"
              class="form-input"
              placeholder="Temat*"
              required
            ></textarea>
          </div>
          <div class="form-group">
            <label for="firstName"></label>
            <input
              type="text"
              id="firstName"
              v-model="formData.firstName"
              class="form-input"
              placeholder="Imię*"
              required
            />
          </div>
          <div class="form-group">
            <label for="lastName"></label>
            <input
              type="text"
              id="lastName"
              v-model="formData.lastName"
              class="form-input"
              placeholder="Nazwisko"
            />
          </div>
          <div class="form-group">
            <label for="phone"></label>
            <input
              type="tel"
              id="phone"
              v-model="formData.phone"
              class="form-input"
              placeholder="Numer telefonu"
            />
          </div>
          <div class="form-group">
            <label for="email"></label>
            <input
              type="email"
              id="email"
              v-model="formData.email"
              class="form-input"
              placeholder="Adres e-mail*"
              required
            />
          </div>
          <div class="form-group">
            <label for="message"></label>
            <textarea
              id="message"
              v-model="formData.message"
              class="form-textarea"
              placeholder="Treść wiadomości*"
              required
            ></textarea>
          </div>
          <button type="submit" class="submit-button">Wyślij</button>
        </form>
      </div>
    </div>

    <div class="contact-info">
      <h3 class="info-title">Informacje</h3>
      <div class="info-item" @click="openEmail">
        <font-awesome-icon icon="envelope"/>
        <div class="info-text">adopsiak@gmail.com</div>
      </div>
      <div class="info-item" @click="openPhone">
        <font-awesome-icon icon="phone" />
        <div class="info-text">+ 555 333 444</div>
      </div>
      <div class="info-item">
        <font-awesome-icon icon="location-dot"/>
        <div class="info-text">
          AdoPsiak sp. z o.o.<br />
          Ul. Słoneczna 25<br />
          30-500 Kraków
        </div>
      </div>
      <div class="info-item">
        <font-awesome-icon icon="clock" />
        <div class="info-text">
           poniedziałek - piątek<br />
          9:00 - 18:00
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      formData: {
        firstName: "",
        lastName: "",
        phone: "",
        email: "",
        message: "",
      },
    };
  },
  methods: {
    submitForm() {
      // Handle form submission logic here
      console.log("Form submitted:", this.formData);
      // Reset form fields after submission
      this.formData = {
        firstName: "",
        lastName: "",
        phone: "",
        email: "",
        message: "",
      };
    },
    openEmail() {
      window.location.href = "mailto:adopsiak@gmail.com";
    },
    openPhone() {
      window.location.href = "tel:+555333444";
    },
  },
};
</script>

<style scoped>
.contact-container {
  display: flex;
  gap: 20px;
  align-items: flex-start;
  justify-content: center; 
}


.contact-info {
  border-radius: 20px;
  background-color: #daf0d0;
  font-size: 24px;
  color: #000;
  font-weight: 400;
  padding: 40px 28px;
}

contact-form {
  border-radius: 20px;
  background-color: #f0f0f0;
  padding: 20px;
  width: 100%; 
  max-width: 400px; 
}

.form-title {
  color: #000;
  font: 400 40px Inter, sans-serif;
  margin: 0; 
}


.contact-info {
  border-radius: 20px;
  background-color: #daf0d0;
  font-size: 24px;
  color: #000;
  font-weight: 400;
  padding: 40px 28px;
  margin-top: 37px; 
}

.info-title {
  font: 40px Inter, sans-serif;
  margin: 0; 
}

.info-item {
  display: flex;
  margin-top: 36px;
  gap: 20px;
  text-align: left;
}

.info-icon {
  width: 36px;
  height: 36px;
  object-fit: contain;
}

.info-text {
  font-family: Inter, sans-serif;
}

.submit-button {
  border-radius: 10px;
  border: 1px solid rgba(0, 0, 0, 1);
  background-color: #fff;
  color: #000;
  margin-top: 30px;
  padding: 8px 41px 12px;
  font: 400 24px Inter, sans-serif;
  cursor: pointer;
}

.form-group {
  margin-bottom: 20px;
}

.form-label {
  font-family: Inter, sans-serif;
  align-items: start;
  border: 1px solid rgba(209, 209, 209, 1);
  background-color: #fff;
  white-space: nowrap;
  padding: 6px 15px 18px;
}

.form-input,
.form-textarea {
  font-family: Inter, sans-serif;
  align-items: start;
  border: 1px solid rgba(209, 209, 209, 1);
  background-color: #fff;
  padding: 15px;
}

.form-textarea {
  min-height: 120px;
}

.contact-form-fields {
  border-radius: 20px;
  background-color: #f0f0f0;
  padding: 20px;
}
</style>