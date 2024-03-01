import { createApp } from "vue";
import { createRouter, createWebHistory } from "vue-router";
import HelloWorld from "./HelloWorld.vue";
import HomePage from "../../Views/Vue/HomePage.vue";
import navBar from "../../Views/Vue/navBar.vue";
import footBar from "../../Views/Vue/footBar.vue";


const app = createApp({
    components:{
        'hello-world': HelloWorld,
        'home-page': HomePage,
        'nav-bar': navBar,
        'foot-bar': footBar
    }
});
// Configura Vue Router
const router = createRouter({
    history: createWebHistory(),
    routes: [
      { path: '/', component: HomePage },
    ]
  });
  

app.use(router);

app.mount("#app");

