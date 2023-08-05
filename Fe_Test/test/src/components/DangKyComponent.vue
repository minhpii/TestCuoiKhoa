<template>
  <div class="layout d-flex align-center">
    <v-container>
      <v-row justify="center">
        <v-col cols="6">
          <v-card>
            <v-container>
              <h5 class="text-h5 pb-5 text-center">Đăng ký</h5>
              <v-row>
                <v-col cols="4">
                  <label for="">Họ:</label>
                  <v-text-field
                    v-model="addPhatTu.ho"
                    type="text"
                    label="..."
                    hide-details
                    solo
                    dense
                  ></v-text-field>
                </v-col>
                <v-col cols="4">
                  <label for="">Tên:</label>
                  <v-text-field
                    v-model="addPhatTu.ten"
                    type="text"
                    label="..."
                    hide-details
                    solo
                    dense
                  ></v-text-field>
                </v-col>
                <v-col cols="4">
                  <label for="">Giới tính</label>
                  <v-select
                    :items="selectGioiTinh"
                    item-text="name"
                    item-value="value"
                    v-model="addPhatTu.gioiTinh"
                    dense
                    solo
                    hide-details
                  ></v-select>
                </v-col>
                <v-col cols="12">
                  <label for="">Pháp danh:</label>
                  <v-text-field
                    v-model="addPhatTu.phapDanh"
                    type="text"
                    label="..."
                    hide-details
                    solo
                    dense
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <label for="">Số điện thoại:</label>
                  <v-text-field
                    v-model="addPhatTu.soDienThoai"
                    type="text"
                    label="..."
                    hide-details
                    solo
                    dense
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <label for="">Email:</label>
                  <v-text-field
                    v-model="addPhatTu.email"
                    type="text"
                    label="..."
                    hide-details
                    solo
                    dense
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <label for="">Mật khẩu:</label>
                  <v-text-field
                    v-model="addPhatTu.password"
                    :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                    :type="show1 ? 'text' : 'password'"
                    label="..."
                    hide-details
                    solo
                    dense
                    @click:append="show1 = !show1"
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-btn block color="primary" class="mb-3" @click="dangKy">
                    Đăng ký
                  </v-btn>
                  <span class="text-caption">
                    Quay lại?
                    <router-link to="/login">Đăng nhập</router-link>
                  </span>
                </v-col>
              </v-row>
            </v-container>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      show1: false,
      selectGioiTinh: [
        { name: "nam", value: 0 },
        { name: "nữ", value: 1 },
      ],
      addPhatTu: {
        ho: "",
        ten: "",
        gioiTinh: "",
        phapDanh: "",
        soDienThoai: "",
        email: "",
        password: "",
      },
    };
  },
  watch: {},
  methods: {
    dangKy() {
      axios
        .post("https://localhost:7195/api/PhatTu/themphattu", this.addPhatTu)
        .then((response) => {
          this.addPhatTu = response.data;
        });
    },
  },
};
</script>

<style scoped>
.layout {
  height: 100%;
}
</style>
