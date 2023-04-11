import { createApp } from 'vue'
import './style.css'
import App from './App.vue'

// 输出环境变量
console.log(import.meta.env.MODE);

// 挂载应用
createApp(App).mount('#app')
