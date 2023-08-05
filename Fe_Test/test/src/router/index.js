import Vue from "vue";
import VueRouter from "vue-router";
import HomeView from "../views/HomeView.vue";
import Phattu from "../components/PhatTuComponent.vue";
import Chua from "../components/ChuaComponent.vue";
import Daotrang from "../components/DaoTrangComponent.vue";
import Dondangky from "../components/DonDangKyComponent.vue";
import Dangnhap from "../components/DangNhapComponent.vue";
import Dangky from "../components/DangKyComponent.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: HomeView,
    children: [
      {
        path: "/phat-tu",
        name: "phattu",
        component: Phattu,
      },
      {
        path: "/chua",
        name: "chua",
        component: Chua,
      },
      {
        path: "/dao-trang",
        name: "daotrang",
        component: Daotrang,
      },
      {
        path: "/don-dang-ky",
        name: "dondangky",
        component: Dondangky,
      },
    ],
  },
  {
    path: "/login",
    name: "dangnhap",
    component: Dangnhap,
  },
  {
    path: "/dang-ky",
    name: "dangky",
    component: Dangky,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
