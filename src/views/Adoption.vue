<template>


    <div class="adoption-process">
        <h1 class="welcome-heading">Witaj!</h1>
        <p class="intro-text">
            Jeśli zastanawiasz się nad adopcją czworonożnego przyjaciela, jesteś we właściwym miejscu. Poniżej
            znajdziesz wszystkie niezbędne informacje dotyczące procesu adopcji w naszym schronisku.
        </p>
    </div>
    <div class="section-container">
        <div v-for="(step, index) in steps" :key="index" class="section-container">
            <div class="step-container">
                <div class="step-image">
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
            <div class="step-image">
                <img src="/stroller.png" alt="Wypełnij formularz adopcyjny" class="step-img" />
            </div>
            <div class="step-description">
                <h2 class="adoption-title">Adopcja młodych zwierząt</h2>
                <p class="step-text">
                    Wyznacz termin odbioru nowego przyjaciela i przygotuj się na radosne powitanie w domu! Zapewniamy
                    Cię, że to początek niezwykłej przygody pełnej miłości i przyjaźni.
                </p>
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
                Każdy musi liczyć się z tym, że może dostać odmowę adopcji konkretnego zwierzęcia. Zwierzęta to żywe
                istoty,
                które mają konkretne charaktery i predyspozycje. Nie każdy dom jest odpowiedni dla każdego zwierzęcia.
            </p>
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
            ]
        };
    }
};
</script>


<style scoped>
/* ********* */
/* ADOPCJA */
/* ********* */

.adoption-container {
    border-radius: 20px;
    background-color: var(--2, #daf0d0);
    padding: 20px;
    width: 70%;
    padding: 30px;
    display: flex;
    margin: auto;
}

.adoption-title {
    color: var(--1, #7fc160);
    text-align: center;
    font: 700 30px Inter, sans-serif;
}

@media (max-width: 991px) {
    .adoption-title {
        max-width: 100%;
    }
}

.adoption-process {
    display: flex;
    flex-direction: column;
    padding: 0 20px;
    margin-left: 300px;
    margin-right: 300px;
}

.welcome-heading {
    color: #7fc160;
    align-self: center;
    font: 800 40px Inter, sans-serif;
}

.intro-text {
    color: #000;
    text-align: center;
    align-self: center;
    margin-top: 25px;
    font: 400 24px Inter, sans-serif;
}

@media (max-width: 991px) {
    .intro-text {
        max-width: 100%;
    }
}

.section-container {
    padding: 15px;
}

.step-container {
    border-radius: 20px;
    background-color: #f7f7f7;
    width: 70%;
    padding: 30px;
    display: flex;
    margin: auto;
}



@media (max-width: 991px) {
    .step-container {
        max-width: 100%;
    }
}

.step-content {
    gap: 20px;
    display: flex;
}

@media (max-width: 991px) {
    .step-content {
        flex-direction: column;
        align-items: stretch;
        gap: 0px;
    }
}

.step-image {
    display: flex;
    flex-direction: column;
    line-height: normal;
    width: 22%;
    margin-left: 0px;
}

@media (max-width: 991px) {
    .step-image {
        width: 100%;
    }
}

.step-img {
    aspect-ratio: 1.14;
    object-fit: cover;
    object-position: center;
    width: 200px;
    max-width: 100%;
    flex-grow: 1;
}

@media (max-width: 991px) {
    .step-img {
        margin-top: 40px;
    }
}

.step-description {
    display: flex;
    flex-direction: column;
    line-height: normal;
    width: 78%;
    margin-left: 20px;
    margin-right: 20px;
}

@media (max-width: 991px) {
    .step-description {
        width: 100%;
    }
}

.step-heading {
    font-weight: 700;
    font-size: 32px;
    color: #7fc160;
}

.step-text {
    color: #000;
    text-align: justify;
    align-self: stretch;
    margin: auto 0;
    font: 400 24px Inter, sans-serif;
}

@media (max-width: 991px) {
    .step-text {
        max-width: 100%;
        margin-top: 40px;
    }
}

.adoption-refusal {
    display: flex;
    flex-direction: column;
    font-size: 30px;
    font-weight: 400;
    padding: 0 20px;
}

.mission-statement {
    color: var(--1, #7fc160);
    text-align: center;
    font-family: Inter, sans-serif;
    font-weight: 500;
    align-self: center;
    margin-left: 300px;
    margin-right: 300px;
}

@media (max-width: 991px) {
    .mission-statement {
        max-width: 100%;
    }
}

.refusal-info {
    align-self: start;
    display: flex;
    margin-top: 26px;
    gap: 20px;
    color: var(--Text-2, #000);

}

.refusal-icon {
    object-position: center;
    margin-left: 300px;
}
</style>