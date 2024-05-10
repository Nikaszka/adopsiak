<template>
  <div>
    <div class="adoption-process">
      <h1 class="welcome-heading">Witaj!</h1>
      <p class="intro-text">
        Jeśli zastanawiasz się nad adopcją czworonożnego przyjaciela, jesteś we właściwym miejscu. Poniżej znajdziesz wszystkie niezbędne informacje dotyczące procesu adopcji w naszym schronisku.
      </p>
    </div>
    
    <div class="section-container">
      <div v-for="(step, index) in steps" :key="index" class="step-container">
        <div class="step-content">
          <div class="step-image" v-if="isDesktop">
            <img :src="step.imageUrl" :alt="step.alt" class="step-img" />
          </div>
          <div class="step-description">
            <h2 class="step-heading">{{ step.title }}</h2>
            <p class="step-text">{{ step.description }}</p>
          </div>
        </div>
      </div>
    </div>

    <div class="section-container">
      <div class="adoption-container">
        <div class="step-content">
          <div class="step-image" >
            <img src="/stroller.png" alt="Wypełnij formularz adopcyjny" class="step-img" />
          </div>
          <div class="step-description">
            <h2 class="adoption-title">Adopcja młodych zwierząt</h2>
            <p class="step-text">
        Wyznacz termin odbioru nowego przyjaciela i przygotuj się na radosne powitanie w domu! Zapewniamy Cię, że to początek niezwykłej przygody pełnej miłości i przyjaźni.
      </p>
          </div>
        </div>
      </div>
    </div>
    
    <div class="adoption-refusal">
      <h2 class="mission-statement">
        Nie wahaj się, dołącz do naszej misji i daj bezdomnym zwierzakom szansę na nowe, kochające domy!
      </h2>
      <div class="refusal-info">
        <img src="/caution-sign.png" alt="Odmowa adopcji" class="refusal-icon" />
        <h3 class="percent-tax-rate-title">Odmowa adopcji</h3>
      </div>
      <div class="adoption-process">
        <p class="intro-text">
          Każdy musi liczyć się z tym, że może dostać odmowę adopcji konkretnego zwierzęcia. Zwierzęta to żywe istoty, które mają konkretne charaktery i predyspozycje. Nie każdy dom jest odpowiedni dla każdego zwierzęcia.
        </p>
      </div>
    </div>
  </div>
  
</template>

<script>
export default {
  data() {
    return {
      steps: [
        {
          title: "Krok 1: Przeglądaj zwierzaki",
          description: "Rozpocznij swoją przygodę od przeglądania galerii zdjęć i opisów naszych wspaniałych podopiecznych. Każde zwierzę ma swoją własną historię i charakter, więc z pewnością znajdziesz kogoś, kto poruszy Twoje serce.",
          imageUrl: "/finding.png",
          alt: "Przeglądaj zwierzaki"
        },
        {
          title: "Krok 2: Wypełnij formularz adopcyjny",
          description: "Gdy już znalazłeś zwierzaka, który przyciągnął Twoją uwagę, wypełnij nasz formularz adopcyjny online. Podziel się z nami informacjami na temat Twojego domu, stylu życia i oczekiwań wobec nowego przyjaciela. Im więcej informacji, tym łatwiej dopasujemy zwierzaka do Twoich potrzeb.",
          imageUrl: "/document.png",
          alt: "Wypełnij formularz adopcyjny"
        },
        {
            title: "Krok 3: Rozmowa telefoniczna",
            description: "Po złożeniu formularza, nasz zespół skontaktuje się z Tobą telefonicznie, aby omówić Twoje preferencje oraz odpowiedzieć na wszelkie pytania związane z adopcją. To również doskonała okazja do omówienia szczegółów dotyczących opieki nad zwierzakiem.",
            imageUrl: "/phone.png",
            alt: " Rozmowa telefoniczna"
          },
          {
            title: "Krok 4: Spotkanie z zwierzakiem",
            description: "Umów się na spotkanie z wybranym zwierzakiem, aby lepiej się poznać i upewnić, czy to idealny towarzysz dla Ciebie. To także świetna okazja, aby zobaczyć, jak zwierzak reaguje na Ciebie i swoje nowe otoczenie.",
            imageUrl: "/play-with-pet.png",
            alt: "Spotkanie z zwierzakiem"
          },
          {
            title: "Krok 5: Podpisanie umowy adopcyjnej",
            description: "Jeśli po spotkaniu zdecydujesz się na adopcję, podpiszemy umowę adopcyjną, która określa warunki adopcji oraz zobowiązania obu stron. Ta formalność zapewnia, że zarówno Ty, jak i zwierzak, dostaniecie odpowiednią opiekę i wsparcie.",
            imageUrl: "/contract.png",
            alt: "Podpisanie umowy adopcyjnej"
          },
          {
            title: "Krok 6: Odbierz nowego przyjaciela",
            description: "Wyznacz termin odbioru nowego przyjaciela i przygotuj się na radosne powitanie w domu! Zapewniamy Cię, że to początek niezwykłej przygody pełnej miłości i przyjaźni.",
            imageUrl: "/adopt.png",
            alt: "Odbierz nowego przyjaciela"
          }
      ],
      isDesktop: true
    };
  },
  mounted() {
    this.isDesktop = window.innerWidth >= 768;
    window.addEventListener("resize", this.handleResize);
  },
  methods: {
    handleResize() {
      this.isDesktop = window.innerWidth >= 768;
    }
  },
  beforeDestroy() {
    window.removeEventListener("resize", this.handleResize);
  }
};
</script>

<style scoped>
.adoption-process {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.welcome-heading {
  color: #7fc160;
  font: 800 40px Inter, sans-serif;
  margin-bottom: 20px;
}

.intro-text {
  color: #000;
  text-align: center;
  font: 400 24px Inter, sans-serif;
}

.section-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 50px;
}

.step-container {
  display: flex;
  border-radius: 20px;
  background-color: #f7f7f7;
  width: 70%;
  padding: 30px;
  margin-bottom: 30px;
}

.step-content {
  display: flex;
  width: 100%;
}

.step-image {
  flex: 1;
  display: flex;
  justify-content: center;
  align-items: center;
}

.step-img {
  max-width: 100%;
  height: auto;
}

.step-description {
  flex: 2;
  display: flex;
  flex-direction: column;
  padding-left: 20px;
}

.step-heading {
  color: #7fc160;
  font-weight: 700;
  font-size: 32px;
  margin-bottom: 15px;
}

.step-text {
  color: #000;
  font: 400 20px Inter, sans-serif;
  text-align: justify;
}

.adoption-container {
  border-radius: 20px;
  background-color: #daf0d0;
  width: 70%;
  padding: 30px;
  display: flex;
  margin-bottom: 30px;
}

.adoption-title {
  color: #7fc160;
  font: 700 30px Inter, sans-serif;
  text-align: center;
  margin-bottom: 20px;
}

.adoption-refusal {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 50px;
}

.mission-statement {
  color: #7fc160;
  font-family: Inter, sans-serif;
  font-weight: 500;
  text-align: center;
  margin-bottom: 30px;
}

.refusal-info {
  display: flex;
  align-items: center;
  gap: 20px;
  margin-bottom: 20px;
}

.refusal-icon {
  width: 50px;
  height: auto;
}

@media (max-width: 768px) {
  .step-image {
    display: none;
  }
  .adoption-process {
  margin: 5px;
  }
}
</style>
