<template>
 <div class="percent-tax-rate-box">
    <div class="percent-tax-rate-title">Pomóż naszym zwierzakom przekazując 1,5% swojego podatku</div>
    <div class="percent-tax-rate-images">
      <img v-for="(image, index) in images" :key="index" :src="image.src" :alt="image.alt" />
    </div>
    <div class="KRS-info">KRS: 1234567899</div>
  </div>    
</template>
<script setup>
import { reactive} from 'vue';
const images = reactive([{ src: "/kot_syjamski.png", alt: "obrazek" },
                         { src: "/pies1.jpg", alt: "obraz2" },
                         { src: "/pies3.jpg", alt: "obraz3" }]);
</script>

<style scoped>
.percent-tax-rate-box {
  background-color: rgb(176, 212, 159);
  margin-left: 300px;
  margin-right: 300px;
  margin-bottom: 30px;
  align-items: center;
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
  text-align: center;
  padding: 20px;
  font-size: 35px;
}

.KRS-info {
  background-color: rgb(130, 78, 78);
  color: white;
  text-align: center;
  font-size: 25px;
  border-radius: 10px;
  margin-left: 300px;
  margin-right: 300px;
}

@media (max-width: 1200px) {
  .percent-tax-rate-box {
    margin-left: auto;
    margin-right: auto;
    width: 70%;
  }
  .percent-tax-rate-images img {
    width: 120px;
    padding: 5px;
    margin-left: 5px;
  }
  .percent-tax-rate-title {
    text-align: center;
    padding: 20px;
    font-size: 20px;
  }
  .percent-tax-rate-images {
    justify-content: center;
  }
  .KRS-info {
    background-color: rgb(130, 78, 78);
    color: white;
    text-align: center;
    font-size: 20px;
    border-radius: 10px;
    margin-left: 70px;
    margin-right: 70px;
  }
  .image-item {
    width: 90px;
  }
}</style>