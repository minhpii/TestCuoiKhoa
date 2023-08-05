<template>
  <div>
    <v-navigation-drawer app v-model="drawer">
      <v-list rounded>
        <v-list-item to="/" color="red">
          <v-list-item-icon>
            <v-icon>mdi-home</v-icon>
          </v-list-item-icon>

          <v-list-item-title> Bảng tin </v-list-item-title>
        </v-list-item>
        <v-list-group
          v-for="item in items"
          :key="item.title"
          v-model="item.active"
          :prepend-icon="item.icon"
          no-action
          color="red"
        >
          <template v-slot:activator>
            <v-list-item-content>
              <v-list-item-title v-text="item.title"></v-list-item-title>
            </v-list-item-content>
          </template>

          <v-list-item
            v-for="child in item.childs"
            :key="child.title"
            :to="child.route"
          >
            <v-list-item-content>
              <v-list-item-title v-text="child.title"></v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list-group>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar app height="60" flat>
      <v-app-bar-nav-icon
        @click="drawer = !drawer"
        color="red"
      ></v-app-bar-nav-icon>
      <v-img
        src="../assets/logo_new.png"
        max-height="60"
        max-width="120px"
        cover
      ></v-img>

      <v-spacer></v-spacer>

      <v-toolbar-title class="me-3">user</v-toolbar-title>
      <v-btn fab small color="#ccc" class="me-2">
        <v-icon color="red">mdi-television</v-icon>
      </v-btn>

      <v-btn fab small color="#ccc" class="me-2">
        <v-icon color="red">mdi-message</v-icon>
      </v-btn>

      <v-btn fab small color="#ccc">
        <v-icon color="red" dark @click="logout">mdi-chevron-down</v-icon>
      </v-btn>
    </v-app-bar>
  </div>
</template>

<script>
export default {
  data() {
    return {
      drawer: null,
      items: [
        {
          title: "Phật tử",
          icon: "mdi-account-circle",
          active: false,
          childs: [{ title: "Quản lý phật tử", route: "/phat-tu" }],
        },
        {
          title: "Chùa",
          icon: "mdi-bank-plus",
          active: false,
          childs: [{ title: "Quản lý chùa", route: "/chua" }],
        },
        {
          title: "Đạo tràng",
          icon: "mdi-calendar-check",
          active: false,
          childs: [{ title: "Quản lý đạo tràng", route: "/dao-trang" }],
        },
        {
          title: "Đơn đăng ký",
          icon: "mdi-format-list-bulleted-square",
          active: false,
          childs: [{ title: "Quản lý đơn đăng ký", route: "/don-dang-ky" }],
        },
      ],
    };
  },
  mounted() {
    let user = localStorage.getItem("user-info");
    if (!user) {
      this.$router.push("/login");
    }
  },
  methods: {
    logout() {
      localStorage.clear();
      this.$router.push("/login");
    },
  },
};
</script>
