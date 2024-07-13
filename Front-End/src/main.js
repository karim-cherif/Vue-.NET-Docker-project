import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";

// axios.defaults.baseURL = "https://localhost:7056";

axios.defaults.baseURL = "http://localhost:5000";

const app = createApp(App);
app.use(router);
app.mount("#app");
