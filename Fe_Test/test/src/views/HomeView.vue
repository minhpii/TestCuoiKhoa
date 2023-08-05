<template>
  <v-app>
    <NavbarComponent></NavbarComponent>
    <router-view />
  </v-app>
</template>

<script>
import NavbarComponent from "@/components/NavbarComponent.vue";
export default {
  components: {
    NavbarComponent,
  },
  data() {
    return {};
  },
};
</script>
<style>
th,
td {
  border: 1px solid #ccc;
}
ul.v-breadcrumbs.theme--light {
  padding: 0;
}
</style>
