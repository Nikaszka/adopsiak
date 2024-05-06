<template>
  <div class = "selected-animal-container">
    <h1 class="title">{{ animals[index].name }}</h1>
    <div class = "animal-data">
      <div class="animal-photo">
        <img :src="animals[index].image" :alt="animals[index].name" class="animal-image" />
      </div>
      <div class = "animal-desciption">
        <p>{{ description }}</p>
      </div>
    </div>
  </div>
  

</template>
<script setup>
  import { computed, ref } from 'vue'
  import animals from '../animals.js'
  const props = defineProps(['id'])
  const index = computed(() => animals.findIndex(c => c.id == props.id))
  const description = ref("Tutaj spotykasz Królewnę - roczną kicię o zielonych oczach i puszystym  futerku, która weszła do naszego schroniska z uroczym uśmiechem na  pyszczku. Królewna to kwintesencja energii i radości. Zawsze gotowa do  zabawy i szalonych akrobacji, ta malutka kotka sprawi, że twoje dni będą  pełne uśmiechu i miłości. Jej delikatne mruczenie jest jak melodia dla  uszu, a czułe przytulenie potrafi rozgrzać serce każdego. Milusia szuka  kochającego domu, w którym będzie mogła rozwinąć swoje skrzydełka i zaskakiwać swoim urokiem każdego dnia. Czy to ty jesteś tą wyjątkową  osobą, na którą Królewna czeka? Przyjdź i pozwól tej małej kulce futra  wprowadzić więcej radości do twojego życia!")
</script>

<style scoped>
.title{
  text-align: center;
}
.animal-data{
  display: flex;
  margin: 100px;
}
@media (max-width: 991px) {
  .animal-data {
    margin: auto;
  }}

.animal-photo{
  /* flex: 1; */
  margin: 30px;
}
.animal-photo img{
  width: 600px;
  height: auto;
}

.animal-description{
  flex:1;
}
</style>