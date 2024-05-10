<template>
  <!-- <div class="percent-tax-rate-box">
    <div class="percent-tax-rate-title">Pomóż naszym zwierzakom przekazując 1,5% swojego podatku</div>
    <div class="percent-tax-rate-images">
      <img v-for="(image, index) in images" :key="index" :src="image.src" :alt="image.alt" class="image-item" />
    </div>
    <div class="KRS-info">KRS: 1234567899</div>
  </div> -->
  <PercentTax></PercentTax>

  <section class="donation-items">
    <h2 class="donation-items__title">Dary rzeczowe, które przyjmuje schronisko:</h2>

    <div class="donation-items__dog-food">
      <div class="donation-items__image-wrapper">
        <img src="/dogFood.png" alt="Dog food" class="donation-items__image" />
      </div>
      <div class="donation-items__content">
        <p class="donation-items__description">
          Karma dla psów:<br />
          <ul>
            <li>karma z dużą zawartością mięsa (sucha i mokra)</li>
            <li>karma specjalistyczna weterynaryjna dla psów sucha i mokra</li>
            <li>karma mokra dla psów seniorów</li>
          </ul>
        </p>
      </div>
    </div>

    <div class="donation-items__cat-food">
      <div class="donation-items__image-wrapper">
        <img src="/catFood.png" alt="Cat food" class="donation-items__image" />
      </div>
      <div class="donation-items__content">
        <p class="donation-items__description">
          Karma dla kotów:<br />
          <ul>
            <li>mokra karma dla kotów z zawartością mięsa</li>
            <li>karma specjalistyczna weterynaryjna dla kotów mokra</li>
          </ul>
        </p>
      </div>
    </div>

    <div class="donation-items__other">
      <div class="donation-items__image-wrapper">
        <img src="/bed.png" alt="Other items" class="donation-items__image" />
      </div>
      <div class="donation-items__content">
        <p class="donation-items__description">
          <ul>
            <li>podkłady higieniczne</li>
            <li>smakołyki</li>
            <li>gryzaki naturalne np. żwacze wołowe, kurze łapki, suszone skóry, i różne inne</li>
          </ul>
        </p>
      </div>
      <div class="donation-items__content">
        <p class="donation-items__description">
          <ul>
            <li>koce</li>
            <li>duże poszewki i prześcieradła</li>
            <li>duże ręczniki</li>
            <li>zabawki dla kotów i psów</li>
            <li>kołdry</li>
          </ul>
        </p>
      </div>
    </div>

  </section>
</template>

<script setup>
import PercentTax from '../components/PercentTax.vue';

// export default {
//   data() {
//     return {
//       images: [
//         { src: "/kot_syjamski.png", alt: "obrazek" },
//         { src: "/pies1.jpg", alt: "obraz2" },
//         { src: "/pies3.jpg", alt: "obraz3" }
//       ]
//     };
//   }
// };
</script>

<style scoped>

ul {
  list-style-type: disc;
}

.percent-tax-rate-box {
  background-color: rgb(176, 212, 159);
  margin: 0 300px 30px;
  border-radius: 10px;
  padding-bottom: 15px;
  text-align: center;
}

.percent-tax-rate-images {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}

.percent-tax-rate-images img {
  width: 240px;
  padding: 15px;
}

.percent-tax-rate-title {
  padding: 20px;
  font-size: 35px;
}

.KRS-info {
  background-color: rgb(130, 78, 78);
  color: white;
  text-align: center;
  font-size: 25px;
  border-radius: 10px;
  margin: 0 300px;
}

@media (max-width: 1200px) {
  .percent-tax-rate-box {
    margin: 0 auto;
    width: 70%;
  }
  .percent-tax-rate-images img {
    width: 120px;
    padding: 5px;
    margin-left: 5px;
  }
  .percent-tax-rate-title {
    font-size: 20px;
  }
  .KRS-info {
    font-size: 20px;
    margin: 0 70px;
  }
}

/* Donation Items */
.donation-items {
  border-radius: 20px;
  background-color: #7fc160;
  display: flex;
  flex-direction: column;
  padding: 8px 35px 28px;
  margin: 0 300px 30px;
}

@media (max-width: 991px) {
  .donation-items {
    max-width: 100%;
    padding: 0 20px;
    margin: 10px 20px 10px;
    display: flex;
    align-items: center;
  }
}

.donation-items__title {
  color: #fff;
  text-align: center;
  align-self: center;
  font: 400 40px Inter, sans-serif;
}

@media (max-width: 991px) {
  .donation-items__title {
    max-width: 100%;
  }
}

.donation-items__dog-food,
.donation-items__cat-food,
.donation-items__other {
  display: flex;
  gap: 20px;
  margin-top: 20px;

  @media (max-width: 991px) {
    flex-direction: column;
    align-items: stretch;
    gap: 0;
    max-width: 100%;
    align-items: center;
  }
}

.donation-items__image-wrapper {
  width: 20%;

  @media (max-width: 991px) {
    width: 100%;
    align-items: center;
    text-align: center;
  }
}

.donation-items__image {
  aspect-ratio: 1;
  max-width: 100%;
  object-fit: auto;
  object-position: center;
  width: 168px;

  @media (max-width: 991px) {
    margin-top: 24px;
    align-items: center;
  }
}

.donation-items__content {
  color: #fff;
  width: 80%;

  @media (max-width: 991px) {
    width: 100%;
    align-items: center;
  }
}

.donation-items__description {
  text-align: justify;
  font: 400 24px Inter, sans-serif;

  @media (max-width: 991px) {
    margin-top: 24px;
    max-width: 100%;
  }
}

.donation-items__cat-food {
  align-self: center;
  margin-top: 19px;
  max-width: 731px;
  width: 100%;

  @media (max-width: 991px) {
    max-width: 100%;
  }
}

.donation-items__other {
  margin-top: 51px;

  @media (max-width: 991px) {
    margin-top: 40px;
    max-width: 100%;
  }
}
</style>
