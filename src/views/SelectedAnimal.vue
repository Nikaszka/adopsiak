<template>
<h1>{{ animals[index].name }}</h1>

</template>
<script setup>
  import { computed, ref } from 'vue'
  import animals from '../animals.js'
  const props = defineProps(['id'])
  const index = computed(() => animals.findIndex(c => c.id == props.id))
  const text = ref("zwierzak")
</script>