import CreatePerson from "@/components/CreatePerson.vue";
import EditPerson from "@/components/EditPerson.vue";
import PersonList from "@/components/PersonList.vue";
import { createRouter, createWebHistory } from "vue-router";

const routes = [
  { path: "/", component: PersonList },
  { path: "/create", component: CreatePerson },
  { path: "/edit/:id", component: EditPerson },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
