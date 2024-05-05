<template>
    <div class="contact-form">
      <h2 class="form-title">Napisz do nas!</h2>
      <div class="form-container">
        <div class="form-columns">
          <div class="form-column">
            <form class="contact-form-fields" @submit.prevent="submitForm">
              <label for="topic" class="form-label">Temat*</label>
              <div class="name-fields">
                <label for="firstName" class="visually-hidden">Imię*</label>
                <input
                  type="text"
                  id="firstName"
                  v-model="formData.firstName"
                  class="form-input"
                  placeholder="Imię*"
                  required
                />
                <label for="lastName" class="visually-hidden">Nazwisko</label>
                <input
                  type="text"
                  id="lastName"
                  v-model="formData.lastName"
                  class="form-input"
                  placeholder="Nazwisko"
                />
              </div>
              <label for="phone" class="visually-hidden">Numer telefonu</label>
              <input
                type="tel"
                id="phone"
                v-model="formData.phone"
                class="form-input"
                placeholder="Numer telefonu"
              />
              <label for="email" class="visually-hidden">Adres e-mail*</label>
              <input
                type="email"
                id="email"
                v-model="formData.email"
                class="form-input"
                placeholder="Adres e-mail*"
                required
              />
              <label for="message" class="visually-hidden">Treść wiadomości*</label>
              <textarea
                id="message"
                v-model="formData.message"
                class="form-textarea"
                placeholder="Treść wiadomości*"
                required
              ></textarea>
              <button type="submit" class="submit-button">Wyślij</button>
            </form>
          </div>
          <div class="form-column">
            <div class="contact-info">
              <h3 class="info-title">Informacje</h3>
              <button class="info-item" @click="openEmail">
                <img src="" alt="" class="info-icon" />
                <div class="info-text">adopsiak@gmail.com</div>
              </button>
              <button class="info-item" @click="openPhone">
                <img src="" alt="" class="info-icon" />
                <div class="info-text">+ 555 333 444</div>
              </button>
              <div class="info-item">
                <img src="" alt="" class="info-icon" />
                <div class="info-text">
                  AdoPsiak sp. z o.o.<br />
                  Ul. Słoneczna 25<br />
                  30-500 Kraków
                </div>
              </div>
              <div class="info-item">
                <img src="" alt="" class="info-icon" />
                <div class="info-text">
                  poniedziałek - piątek<br />
                  9:00 - 18:00
                </div>
              </div>
            </div>
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
  .contact-form {
    display: flex;
    flex-direction: column;
    margin-bottom: 31px;
    padding-bottom: 94px;
  }
  
  .form-title {
    color: #000;
    align-self: start;
    margin-left: 20px;
    font: 400 40px Inter, sans-serif;
  }
  
  @media (max-width: 991px) {
    .form-title {
      margin-left: 10px;
    }
  }
  
  .form-container {
    margin-top: 17px;
    width: 100%;
  }
  
  @media (max-width: 991px) {
    .form-container {
      max-width: 100%;
    }
  }
  
  .form-columns {
    display: flex;
    gap: 20px;
  }
  
  @media (max-width: 991px) {
    .form-columns {
      flex-direction: column;
      align-items: stretch;
      gap: 0;
    }
  }
  
  .form-column {
    display: flex;
    flex-direction: column;
    line-height: normal;
    width: 57%;
    margin-left: 0;
  }
  
  @media (max-width: 991px) {
    .form-column {
      width: 100%;
    }
  }
  
  .contact-form-fields {
    align-content: flex-start;
    flex-wrap: wrap;
    border-radius: 20px;
    background-color: #f0f0f0;
    display: flex;
    flex-grow: 1;
    flex-direction: column;
    font-size: 24px;
    color: var(--grey-1, #bababa);
    font-weight: 400;
    width: 100%;
    margin: 0 0 24px 28px;
    padding: 20px;
  }
  
  @media (max-width: 991px) {
    .contact-form-fields {
      max-width: 100%;
      margin-top: 40px;
    }
  }
  
  .form-label {
    font-family: Inter, sans-serif;
    align-items: start;
    border: 1px solid rgba(209, 209, 209, 1);
    background-color: #fff;
    white-space: nowrap;
    justify-content: center;
    margin-bottom: 3px;
    padding: 6px 15px 18px;
  }
  
  @media (max-width: 991px) {
    .form-label {
      max-width: 100%;
      padding-right: 20px;
      white-space: initial;
    }
  }
  
  .name-fields {
    display: flex;
    margin-top: 30px;
    gap: 17px;
    white-space: nowrap;
  }
  
  @media (max-width: 991px) {
    .name-fields {
      max-width: 100%;
      flex-wrap: wrap;
      white-space: initial;
    }
  }
  
  .form-input {
    font-family: Inter, sans-serif;
    align-items: start;
    border: 1px solid rgba(209, 209, 209, 1);
    background-color: #fff;
    justify-content: center;
    padding: 15px;
  }
  
  @media (max-width: 991px) {
    .form-input {
      max-width: 100%;
      padding-right: 20px;
      white-space: initial;
    }
  }
  
  .form-textarea {
    font-family: Inter, sans-serif;
    align-items: start;
    border: 1px solid rgba(209, 209, 209, 1);
    background-color: #fff;
    margin-top: 30px;
    justify-content: center;
    padding: 15px;
    min-height: 120px;
  }
  
  @media (max-width: 991px) {
    .form-textarea {
      max-width: 100%;
      padding: 15px 20px;
    }
  }
  
  .contact-info {
    border-radius: 20px;
    background-color: var(--2, #daf0d0);
    display: flex;
    flex-direction: column;
    align-self: stretch;
    align-items: start;
    font-size: 24px;
    color: #000;
    font-weight: 400;
    width: 100%;
    margin: auto 0 auto -5px;
    padding: 40px 28px;
  }
  
  @media (max-width: 991px) {
    .contact-info {
      max-width: 100%;
      margin-top: 40px;
      padding: 40px 20px;
    }
  }
  
  .info-title {
    font: 40px Inter, sans-serif;
  }
  
  .info-item {
    display: flex;
    margin-top: 36px;
    gap: 20px;
    justify-content: space-between;
    padding: 2px;
    background: none;
    border: none;
    cursor: pointer;
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
    justify-content: center;
    border-radius: 10px;
    border: 1px solid rgba(0, 0, 0, 1);
    background-color: #fff;
    align-self: center;
    color: #000;
    white-space: nowrap;
    margin: 8px 0;
    padding: 8px 41px 12px;
    font: 400 24px Inter, sans-serif;
    cursor: pointer;
  }
  
  @media (max-width: 991px) {
    .submit-button {
      white-space: initial;
      padding: 8px 20px 12px;
    }
  }
  
  .visually-hidden {
    position: absolute;
    width: 1px;
    height: 1px;
    padding: 0;
    margin: -1px;
    overflow: hidden;
    clip: rect(0, 0, 0, 0);
    white-space: nowrap;
    border: 0;
  }
  </style>