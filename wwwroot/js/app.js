import { createApp } from "vue";
import { createRouter, createWebHistory } from "vue-router";
import HelloWorld from "./HelloWorld.vue";
import HomePage from "../../Views/Vue/HomePage.vue";
import navBar from "../../Views/Vue/navBar.vue";
import footBar from "../../Views/Vue/footBar.vue";
import petPage from "../../Views/Vue/petPage.vue";
import productPage from "../../Views/Vue/productPage.vue";
import logInPage from "../../Views/Vue/logInPage.vue";
import enfermedades from "../../Views/Vue/enfermedades.vue";
import adminPage from "../../Views/Vue/adminPage.vue";
import adminPetsPage from "../../Views/Vue/adminPetsPage.vue";
import adminProductPage from "../../Views/Vue/adminProductPage.vue"
import adminDiseasePage from "../../Views/Vue/adminDiseasePage.vue"
import workingOnPage from "../../Views/Vue/workingOnPage.vue"

const app = createApp({
    components:{
        'hello-world': HelloWorld,
        'home-page': HomePage,
        'nav-bar': navBar,
        'foot-bar': footBar,
        'pet-page': petPage,
        'product-page': productPage,
        'log-in-page': logInPage,
        'enfermedades': enfermedades,
        'admin-page' : adminPage,
        'admin-pet-page' : adminPetsPage,
        'admin-product-page' : adminProductPage,
        'admin-disease-page': adminDiseasePage,
        'working-on-page': workingOnPage
    }
});
// Configura Vue Router
const router = createRouter({
    history: createWebHistory(),
    routes: [
      { path: '/', component: HomePage },
      { path: '/pet', component: petPage },
      { path: '/product', component: productPage },
      { path: '/login', component: logInPage },
      { path: '/enfe', component: enfermedades },
      { path: '/admin', component: adminPage },
    ]
  });
  

app.use(router);

app.mount("#app");

