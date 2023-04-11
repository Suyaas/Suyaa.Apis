<script setup lang="ts">
import { ref } from 'vue'
import LoginForm from '@/components/LoginForm.vue'
import bgImg from '/login/bg.jpg'
</script>

<template>
    <div class="bg"><img :src="bgImg"></div>
    <LoginForm />
</template>

<style scoped>
.bg {
    width: 100%;
    height: 100%;
    overflow: hidden;
}

.bg img {
    display: block;
    width: 100%;
    min-width: 1920px;
}
</style>