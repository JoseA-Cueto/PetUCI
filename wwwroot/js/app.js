import { createApp } from "vue";
import { createRouter, createWebHistory } from "vue-router";
import HelloWorld from "./HelloWorld.vue";
import HomePage from "../../Views/Vue/HomePage.vue";
import navBar from "../../Views/Vue/navBar.vue";
import footBar from "../../Views/Vue/footBar.vue";
import petPage from "../../Views/Vue/petPage.vue";
import productPage from "../../Views/Vue/productPage.vue";

const app = createApp({
    components:{
        'hello-world': HelloWorld,
        'home-page': HomePage,
        'nav-bar': navBar,
        'foot-bar': footBar,
        'pet-page': petPage,
        'product-page': productPage
    }
});
// Configura Vue Router
const router = createRouter({
    history: createWebHistory(),
    routes: [
      { path: '/', component: HomePage },
      { path: '/pet', component: petPage },
      { path: '/product', component: productPage },
    ]
  });
  

app.use(router);

app.mount("#app");

