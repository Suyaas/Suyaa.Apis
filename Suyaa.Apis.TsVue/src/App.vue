<script setup lang="ts">
import { count } from 'console';
import { create } from 'domain';
import HelloWorld from './components/HelloWorld.vue'
import Router from './router';

Router.push({
  path: "/home"
});
</script>

<template>
  <RouterView></RouterView>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}

.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}

.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
