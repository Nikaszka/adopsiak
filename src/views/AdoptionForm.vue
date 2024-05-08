<template>
    <div class="adoption-form-container">
        <h1>Formularz adopcyjny</h1>
        <p>Prosimy o podanie podstawowych danych kontaktowych, 
            które umożliwią nam dalszą komunikację oraz ustalenie 
            szczegółów związanych z procesem adopcji.</p>
    </div>
    <div class="contact-container">
    <div class="contact-form">
      <div class="form-container">
        <form class="contact-form-fields" @submit.prevent="submitForm('contact')">
            <h2 class="form-title">Dane kontaktowe:</h2>
                      
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
              placeholder="Nazwisko*"
              required
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
          <h2 class="form-title">Adres zamieszkania:</h2>
          <div class="form-group">
            <label for="street"></label>
            <input
              type="text"
              id="street"
              v-model="formData.street"
              class="form-input"
              placeholder="Ulica*"
              required
            />
          </div>
          <div class="form-group">
            <label for="number"></label>
            <input
              type="number"
              id="number"
              v-model="formData.number"
              class="form-input"
              placeholder="Numer*"
              required
            />
          </div>
          <div class="form-group">
            <label for="city"></label>
            <input
              type="text"
              id="city"
              v-model="formData.city"
              class="form-input"
              placeholder="Miasto*"
              required
            />
          </div>
          <div class="form-group">
            <label for="province"></label>
            <input
              type="text"
              id="province"
              v-model="formData.province"
              class="form-input"
              placeholder="Województwo*"
              required
            />
          </div>
          <div class="form-group">
            <label for="postalCode"></label>
            <input
              type="text"
              id="postalCode"
              v-model="formData.postalCode"
              class="form-input"
              placeholder="Kod pocztowy*"
              required
              pattern="[0-9]{2}-[0-9]{3}"
              title="Proszę wprowadzić kod pocztowy w formacie XX-XXX"
            />
          </div>
        </form>
      </div>
    </div>

    <div class="contact-info">
        <p>Wybrany zwierzak: </p>
    <div class="animal-card">
        <img :src="animals[index].image" :alt="animals[index].name" class="animal-image"/>
        <h3 class="animal-name">{{ animals[index].name }}</h3>
        <div class="animal-breed">
            <font-awesome-icon icon="paw"/>
            <span class="breed-name">{{ animals[index].breed }}</span>
        </div>
        <div class="animal-gender">
            <font-awesome-icon icon="venus-mars"/>
            <span class="gender-age">{{ animals[index].gender }}, {{ animals[index].age }}</span>
        </div>
        <div class="animal-location">
            <font-awesome-icon icon="location-dot"/>
            <span class="location-address">{{ animals[index].location }}</span>
        </div>
    </div>
</div>
</div>

<div class="contact-form-big">
      <div class="form-container">
        <form class="contact-form-fields" @submit.prevent="submitForm('adoption')">
          <div class="form-group">
            <label for="firstQuestion">
                1. Prosimy o szczegółowy opis środowiska, w którym będzie mieszkał 
                adoptowany pies.Podaj typ mieszkania (np. mieszkanie, dom z ogrodem),
                 liczbę schodów do pokonania, dostępność windy oraz informacje 
                 o najbliższych terenach zielonych(parki, wybiegi dla psów). 
                 Zwróć także uwagę na miejsce, gdzie pies będzie miał swoje 
                 legowisko do spania (np. łóżko w sypialni, kanapa, kojec, 
                 osobne legowisko).
            </label>
            <textarea
              id="firstQuestion"
              v-model="formData.firstQuestion"
              class="form-textarea"
              placeholder="Treść wiadomości*"
              required
            ></textarea>
          </div>
          <div class="form-group">
            <label for="secondQuestion">
                2. Czy miałeś/aś w przeszłości jakieś zwierzęta domowe? Prosimy o 
                krótki opis twoich doświadczeń z poprzednimi zwierzętami. Wymień, 
                skąd trafiły one do twojego domu, jak współżyły z innymi członkami 
                rodziny, czy napotkały jakieś problemy zdrowotne lub behawioralne. 
                Podaj również, jak długo żyły i czy były sterylizowane lub kastrowane. 
                Te informacje pomogą nam zrozumieć twoje doświadczenie w opiece 
                nad zwierzętami oraz przygotowanie do potencjalnych wyzwań związanych 
                z adopcją nowego psa.
            </label>
            <textarea
              id="secondQuestion"
              v-model="formData.secondQuestion"
              class="form-textarea"
              placeholder="Treść wiadomości*"
              required
            ></textarea>
          </div>
          <div class="form-group">
            <label for="secondQuestion">
                3. Czy w Twoim najbliższym otoczeniu znajdują się inne psy, koty, 
                lub jakiekolwiek inne zwierzęta?Opisz, jakie zwierzęta są częścią 
                Twojego codziennego środowiska. Dodatkowo, zastanów się i podaj 
                informacje na temat miejsc, które regularnie odwiedzasz — czy 
                adoptowany pies będzie miał tam możliwość kontaktu z innymi 
                zwierzętami? Te informacje są ważne, aby ocenić, jak pies może 
                reagować na inne zwierzęta i jakie środki należy podjąć, aby 
                zapewnić bezpieczne i harmonijne współistnienie.
            </label>
            <textarea
              id="thirdQuestion"
              v-model="formData.thirdQuestion"
              class="form-textarea"
              placeholder="Treść wiadomości*"
              required
            ></textarea>
          </div>
          <div class="form-group">
            <label for="fourthQuestion">
                4. Czy zdajesz sobie sprawę, że adopcja psa wiąże sięz długoterminowymi 
                zobowiązaniami, w tym opieką nad nim zarówno w zdrowiu, jak i w chorobie? 
                Czy jesteś przygotowany/a na pokrycie potencjalnie wysokich kosztów 
                leczenia psa, gdyby wystąpiła taka potrzeba? Prosimy o przemyślenie 
                i opisanie swojej gotowości do finansowania opieki zdrowotnej dla psa, 
                włączając w to regularne wizyty u weterynarza, szczepienia, ewentualne 
                operacje czy specjalistyczne traktowanie.
            </label>
            <textarea
              id="fourthQuestion"
              v-model="formData.fourthQuestion"
              class="form-textarea"
              placeholder="Treść wiadomości*"
              required
            ></textarea>
          </div>
          <div class="form-group">
            <label>
                <input
                    type="checkbox"
                    v-model="formData.agreeTerms"
                    class="form-checkbox"
                    required
                />
                Oświadczam, że mam świadomość, że przed adopcją należy upewnić się, 
                że u żadnego z domowników nie występuje alergia na sierść lub 
                ślinę zwierzęcia, a jeśli występuje należy adopcję skonsultować 
                z lekarzem.
            </label>
          </div>
          <div class="form-group">
            <label>
                <input
                    type="checkbox"
                    v-model="formData.agreeDatas"
                    class="form-checkbox"
                    required
                />
                Wyrażam zgodę na przetwarzanie danych osobowych przez Schronisko AdoPsiak.
            </label>
          </div>
          <div class="form-group">
            <label>
                <input
                    type="checkbox"
                    v-model="formData.agreeStatus"
                    class="form-checkbox"
                    required
                />
                Akceptuję 
                <a href="https://ciapkowo.pl/wirtualna-adopcja/" target="_blank">regulamin</a>
                i 
                <a href="https://ciapkowo.pl/polityka-prywatnosci/" target="_blank">politykę prywatności</a>
            </label>
          </div>
          <button @click="submitForm" class="submit-button">Wyślij</button>
        </form>
      </div>
    </div>


</template>

<script setup>
  import { computed, ref } from 'vue'
  const props = defineProps(['id'])
  const index = computed(() => animals.findIndex(c => c.id == props.id))

</script>

<script>

const formData = ref({
    firstName: "",
    lastName: "",
    phone: "",
    email: "",
    street: "",
    number: "",
    city: "",
    province: "",
    postalCode: "",
    firstQuestion: "",
    secondQuestion: "",
    thirdQuestion: "",
    fourthQuestion: "",
    agreeTerms: "",
    agreeDatas: "",
    agreeStatus: "",
})

function submitForm() {
        if (allFieldsFilled()) {
            console.log("Form submitted:", formData.value);
            // Zresetuj pola formularzy po wysłaniu
            Object.keys(formData.value).forEach(key => {
                formData.value[key] = ""
            })
        } else {
            alert("Proszę uzupełnić wszystkie pola formularza.")
        }
    }

    function allFieldsFilled() {
        // Sprawdź, czy wszystkie pola są uzupełnione
        return Object.values(formData.value).every(value => value !== "")
    }
</script>

<style scoped>
.adoption-form-container {
    text-align: center;
    padding-bottom: 20px;
}
.animal-card {
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25);
  background-color: #fdfafa;
  display: flex;
  width: 100%;
  flex-grow: 1;
  padding-bottom: 9px;
  flex-direction: column;
  font-size: 16px;
  color: #000;
  font-weight: 600;
  text-align: center;
  margin: 0 auto;
  margin-top: 40px;
  max-width: calc(100% - 30px);
}

.animal-image {
  aspect-ratio: 1.82;
  object-fit: cover;
  object-position: center;
  width: 100%;
  z-index: 10;
  margin-top: -11px;
}

.animal-name {
  margin-top: 20px;
  font: italic 32px Inter, sans-serif;
}

.animal-breed,
.animal-gender,
.animal-location {
  display: flex;
  gap: 20px;
  white-space: nowrap;
  margin-top: 7px;
  margin-left: 7px;
}

.breed-name,
.gender-age,
.location-address {
  font-family: Inter, sans-serif;
  font-style: italic;
  flex-grow: 1;
  flex-basis: auto;
  margin: auto 0;
}

/* Formularze */
.contact-container {
  display: flex;
  gap: 20px;
  align-items: flex-start;
  justify-content: center; 
}

.contact-form {
    width: 50%;
}

.contact-form-big {
    max-width: 75%;
    padding-top: 30px;
    margin: 0 auto;
}


.contact-info {
  border-radius: 20px;
  background-color: #daf0d0;
  font-size: 24px;
  color: #000;
  font-weight: 400;
  padding: 20px 10px;
  text-align: center;
  max-width: 20%;
}

.form-title {
  color: #000;
  font: 400 40px Inter, sans-serif;
  margin: 0; 
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
  width: 100%; 
}

.form-input,
.form-textarea {
  font-family: Inter, sans-serif;
  align-items: start;
  border: 1px solid rgba(209, 209, 209, 1);
  background-color: #fff;
  padding: 15px;
  width: calc(100% - 30px); /* Ustawienie szerokości pól formularza */
}

.contact-form-fields {
  border-radius: 20px;
  background-color: #f0f0f0;
  padding: 20px;
  text-align: center;
}


@media (max-width: 768px) {
  .contact-container {
    flex-direction: column;
    align-items: center;
    margin: 0 30px;
  }

  .contact-form {
    width: 100%;
    max-width: 400px;
    margin: 0 auto;
  }

  .contact-info {
    width: 100%;
    max-width: 300px; 
    margin: 0 auto; 
  }

}
</style>
