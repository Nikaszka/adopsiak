<template>
  <div class="percent-tax-rate-box">
    <div class="percent-tax-rate-title">Pomóż naszym zwierzakom przekazując 1,5% swojego podatku</div>
    <div class="percent-tax-rate-images">
      <img v-for="(image, index) in images" :key="index" :src="image.src" :alt="image.alt" />
    </div>
    <div class="KRS-info">KRS: 1234567899</div>
  </div>

  <div class="animal-adoption">
    <h2 class="section-title">Zwierzaki do adopcji</h2>
    <div class="animal-grid">
      <div v-for="(animal, index) in animals" :key="index" class="animal-column">
        <div class="animal-card">
          <img :src="animal.image" :alt="animal.name" class="animal-image" />
          <h3 class="animal-name">{{ animal.name }}</h3>
          <div class="animal-breed">
            <font-awesome-icon icon="paw" />
            <span class="breed-name">{{ animal.breed }}</span>
          </div>
          <div class="animal-gender">
            <font-awesome-icon icon="venus-mars" />
            <span class="gender-age">{{ animal.gender }}, {{ animal.age }}</span>
          </div>
          <div class="animal-location">
            <font-awesome-icon icon="location-dot"/>
            <span class="location-address">{{ animal.location }}</span>
          </div>
        </div>
      </div>
    </div>
    <button class="more-animals-btn">Więcej zwierzaków</button>
  </div>

  <div class="stats-container">
    <div class="stats-wrapper">
      <div class="percent-tax-rate-title">AdoPsiak w liczbach</div>
        <div class="stats-row">
          <div v-for="(stat, index) in stats" :key="index" class="stats-item">
            <font-awesome-icon :icon="stat.icon" size="2xl" style="color: #ffffff;" />
            <p class="stats-value">{{ stat.value }}</p>
            <p class="stats-label">{{ stat.label }}</p>
          </div>
        </div>
      </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
      images: [
        { src: "/kot_syjamski.png", alt: "obrazek" },
        { src: "/pies1.jpg", alt: "obraz2" },
        { src: "/pies3.jpg", alt: "obraz3" }
      ],
      animals: [
        { name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg" },
        { name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png" },
        { name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg" },
        { name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg" }
      ],
      stats: [
        { icon: "heart", value: "321", label: "zwierząt do adopcji" },
        { icon: "hand-holding-dollar", value: "258 035,25 zł", label: "zebranych środków w ramach wsparcia" },
        { icon: "house", value: "1231", label: "zwierząt znalazło swój dom" }
      ]
    };
  }
};
</script>