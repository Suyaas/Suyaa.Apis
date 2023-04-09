<script setup>
import { ref } from 'vue'
import LoginForm from './LoginForm.vue'
import es6Img1 from "../../public/login/bg.jpg"
</script>

<template>
    <div class="bg"><img src="{{es6Img1}}" /></div>
    <LoginForm msg="Vite + Vue" />
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