import { createApp } from "vue";
import HelloWorld from "./HelloWorld.vue";

const app = createApp({
    components:{
        'hello-world': HelloWorld
    }
});
app.mount("#app");

