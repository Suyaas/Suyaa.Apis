import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router';
import home from '@/views/home.vue';
import login from '@/views/login.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: () => home,
    alias: '/home',
    meta: {
      title: '首页'
    }
  },
  {
    path: '/login',
    name: 'login',
    component: () => login,
    meta: {
      title: '登录页面'
    }
  },
];

const Router = createRouter({
  history: createWebHashHistory(),
  routes
});

export default Router;