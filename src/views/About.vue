<template>
    <main class="animal-shelter">
        <header class="welcome-message">
            Witajcie w naszym wirtualnym schronisku dla zwierząt!
        </header>
        <section class="about">
            <img src="/happyDog.jpg"
                alt="Zdjęcie zwierząt w schronisku" class="about-image" />
            <p class="about-text">
                Nasza strona powstała z pasji i zobowiązania do zapewnienia lepszej przyszłości dla bezdomnych zwierząt.
                Naszym celem jest umożliwienie łatwego dostępu do adopcji psiaków, kotków i innych zwierząt
                potrzebujących domu.
            </p>
        </section>
        <section class="about">
            <p class="about-text">
                Dzięki naszej platformie, możesz przeglądać galerię zdjęć naszych podopiecznych i dowiedzieć się więcej
                o ich historiach. Możesz wybrać swojego nowego przyjaciela i złożyć wniosek o adopcję, aby dać mu szansę
                na szczęśliwe życie w kochającym domu. Istnieje również możliwość wsparcia naszej działalności poprzez
                darowizny. Każda wpłata pomaga nam zapewnić opiekę weterynaryjną, wyżywienie i inne potrzeby naszych
                podopiecznych.
                <br />
            </p>
            <img src="/WomanWithLaptop.jpg"
                alt="Zdjęcie zwierzaka czekającego na adopcję" class="about-image" />
        </section>
        <section class="about">
            <img src="/childrenWithAnimals.jpg"
                alt="Zdjęcie szczęśliwego zwierzaka po adopcji" class="about-image" />
            <p class="about-text">
                Nasza strona nie tylko ułatwia proces adopcji, ale również promuje świadomość i odpowiedzialność wobec
                zwierząt. Działamy z pasją i zaangażowaniem, aby każde zwierzę znalazło dom, gdzie będzie kochane i
                szanowane.
            </p>
        </section>
        <footer class="call-to-action">
            <br />
            Dołącz do naszej społeczności i pomóż nam tworzyć lepsze życie dla bezdomnych zwierząt!
        </footer>
    </main>
</template>

<style scoped>
.animal-shelter {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 20px;
    padding: 30px 74px;
    background-color: #fff;
    color: #000;
    font-size: 24px;
    font-weight: 400;
    text-align: center;
}

@media (max-width: 991px) {
    .animal-shelter {
        padding: 0 20px;
    }
}

.welcome-message {
    color: #7fc160;
    background-color: #fff;
    font: 600 40px Inter, sans-serif;
    margin-top: -20px;
}

.about {
    display: flex;
    justify-content: center;
    gap: 20px;
    margin-top: 32px;
    margin-left: 100px;
    margin-right: 100px;
}

@media (max-width: 991px) {
    .about {
        flex-wrap: wrap;
    }
}


.about-image {
    width: 260px;
    max-width: 100%;
    object-fit: auto;
    object-position: center;
    border-radius: 30px;
}

.about-image {
    aspect-ratio: 1.01;
}

.about-text {
    font-family: Inter, sans-serif;
    margin: auto 0;
}

.call-to-action {
    color: #f00;
    background-color: #fff;
    font: 200 35px Inter, sans-serif;
}
</style>