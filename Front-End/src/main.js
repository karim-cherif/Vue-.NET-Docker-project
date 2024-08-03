import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";

//native
// axios.defaults.baseURL = "https://localhost:7056";

//containerized
//axios.defaults.baseURL = "http://localhost:5000";

//azure
axios.defaults.baseURL =
  "https://myapp-back.thankfulbush-6e078cc6.northeurope.azurecontainerapps.io";

const app = createApp(App);
app.use(router);
app.mount("#app");
