<template>
  <div class="layout d-flex align-center">
    <v-container>
      <v-row justify="center">
        <v-col cols="6">
          <v-card>
            <v-container>
              <h5 class="text-h5 pb-5 text-center">Đăng nhập</h5>
              <label for="">Email:</label>
              <v-text-field
                v-model="addLogin.email"
                class="mb-3"
                type="text"
                label="..."
                hide-details
                solo
                dense
              ></v-text-field>
              <label for="">Mật khẩu:</label>
              <v-text-field
                v-model="addLogin.password"
                :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                :type="show1 ? 'text' : 'password'"
                label="..."
                hide-details
                solo
                dense
                @click:append="show1 = !show1"
              ></v-text-field>
              <v-btn block color="primary" class="mt-5 mb-5" @click="login">
                Đăng nhập
              </v-btn>
              <p>
                <router-link to="/quen-mat-khau">Quên mật khẩu?</router-link>
              </p>
              <span class="text-caption">
                Nếu bạn chưa có tài khoản?
                <router-link to="/dang-ky">Đăng ký</router-link>
              </span>
            </v-container>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import axios from "axios";
// import jwt_decode from "jwt-decode";
export default {
  data() {
    return {
      show1: false,
      addLogin: {
        email: "",
        password: "",
      },
    };
  },
  methods: {
    login() {
      axios
        .post("https://localhost:7195/api/PhatTu/login", this.addLogin)
        .then((response) => {
          localStorage.setItem("user-info", JSON.stringify(response.data));
          this.$router.push("/");
        })
        .catch((err) => {
          alert(err.response.data);
        });
    },
  },
  mounted() {
    let user = localStorage.getItem("user-info");
    if (user) {
      this.$router.push("/");
    }
  },
};
</script>

<style scoped>
.layout {
  height: 100%;
}
</style>
