<template>
  <div class="layout">
    <v-container>
      <v-breadcrumbs :items="breads">
        <template v-slot:divider>
          <v-icon>mdi-chevron-right</v-icon>
        </template>
      </v-breadcrumbs>
      <h5 class="text-h5">Quản lý đơn đăng ký</h5>
      <v-card class="mt-5 mb-5">
        <v-card-title>
          <p class="font-weight-regular mb-0">Tìm kiếm đơn đăng ký</p>
          <v-spacer></v-spacer>
          <v-btn fab small color="green" @click="timKiem">
            <v-icon color="white">mdi-magnify</v-icon>
          </v-btn>
        </v-card-title>
        <v-card-actions>
          <v-row>
            <v-col cols="3" class="mb-5">
              <label for="">Trạng thái đơn</label>
              <v-select
                v-model="searhTrangThai"
                :items="selectTrangThai"
                item-text="name"
                item-value="value"
                dense
                solo
                hide-details
              ></v-select>
            </v-col>
          </v-row>
        </v-card-actions>
      </v-card>
      <v-card>
        <v-container>
          <v-data-table :headers="headers" :items="donDangKys">
            <template v-slot:[`item.actions`]="{ item }">
              <v-btn
                fab
                small
                color="green"
                class="mr-3"
                @click="duyetDon(item)"
              >
                <v-icon small color="white">mdi-check-all</v-icon>
              </v-btn>
            </template>
            <template v-slot:top>
              <v-toolbar flat>
                <v-spacer></v-spacer>
                <template>
                  <v-btn
                    color="primary"
                    dark
                    class="mb-2"
                    @click="addDonDangKy"
                  >
                    Thêm
                  </v-btn>
                </template>
                <v-dialog v-model="dialog" max-width="800px">
                  <v-card>
                    <v-card-title>
                      <span class="text-h5">Thêm đơn đăng ký</span>
                    </v-card-title>

                    <v-card-text>
                      <v-container>
                        <v-row>
                          <v-col cols="6">
                            <label for="">Đạo tràng</label>
                            <v-select
                              :items="daoTrangs"
                              v-model="editdonDangKy.daoTrangId"
                              dense
                              solo
                              hide-details
                            ></v-select>
                          </v-col>
                        </v-row>
                      </v-container>
                    </v-card-text>

                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-btn color="red darken-1" text @click="closeDialog">
                        Hủy
                      </v-btn>
                      <v-btn color="blue darken-1" text @click="saveItem">
                        Lưu
                      </v-btn>
                    </v-card-actions>
                  </v-card>
                </v-dialog>
                <v-dialog v-model="dialogDuyet" max-width="500px">
                  <v-card>
                    <v-card-title class="text-h5">Duyệt đơn này?</v-card-title>
                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-btn color="red darken-1" text @click="closeDialog"
                        >Cancel</v-btn
                      >
                      <v-btn color="blue darken-1" text @click="duyetItem"
                        >OK</v-btn
                      >
                      <v-spacer></v-spacer>
                    </v-card-actions>
                  </v-card>
                </v-dialog>
              </v-toolbar>
            </template>
          </v-data-table>
        </v-container>
      </v-card>
    </v-container>
  </div>
</template>

<script>
import axios from "axios";
//import jwt_decode from "jwt-decode";
export default {
  data: () => ({
    breads: [
      {
        text: "Home",
        disabled: false,
        href: "/",
      },
      {
        text: "Đơn đăng ký",
        disabled: false,
        href: "/don-dang-ky",
      },
    ],
    headers: [
      { text: "#", value: "donDangKyId" },
      { text: "Đạo tràng", value: "daoTrangId" },
      { text: "Phật tử", value: "phatTuId" },
      { text: "Người xử lý", value: "nguoiXuLy" },
      { text: "Trạng thái đơn", value: "trangThaiDon" },
      { text: "Thao tác", value: "actions", sortable: false },
    ],
    dialog: false,
    donDangKys: [],
    editdonDangKy: {
      donDangKyId: null,
      phatTuId: null,
      daoTrangId: null,
      trangThaiDon: null,
    },
    daoTrangs: [],
    selectTrangThai: [
      { name: "đã duyệt", value: 1 },
      { name: "chưa duyệt", value: 0 },
    ],
    dialogDuyet: false,
    searhTrangThai: "",
  }),
  created() {
    this.getDsDonDangKys();
    this.getDaoTrangs();
  },
  methods: {
    getDsDonDangKys() {
      axios
        .get("https://localhost:7195/api/DonDangKy/dsDonDangKy")
        .then((response) => {
          this.donDangKys = response.data;
        });
    },
    addDonDangKy() {
      this.editdonDangKy = {
        phatTuId: null,
        daoTrangId: null,
      };
      this.dialog = true;
    },
    getDaoTrangs() {
      axios
        .get("https://localhost:7195/api/DaoTrang/dsdaotrang")
        .then((response) => {
          response.data.forEach((element) => {
            this.daoTrangs.push(element.daoTrangId);
          });
        });
    },
    closeDialog() {
      this.dialog = false;
      this.dialogDuyet = false;
    },
    saveItem() {
      axios
        .post(
          "https://localhost:7195/api/DonDangKy/themdondangky",
          this.editdonDangKy
        )
        .then((response) => {
          this.editdonDangKy = response.data;
          this.dialog = false;
          this.getDsDonDangKys();
        });
    },
    duyetDon(item) {
      this.editdonDangKy.donDangKyId = item.donDangKyId;
      this.editdonDangKy.daoTrangId = item.daoTrangId;
      this.editdonDangKy.phatTuId = item.phatTuId;
      this.dialogDuyet = true;
    },
    duyetItem() {
      axios
        .put(
          "https://localhost:7195/api/DonDangKy/duyetdondangky",
          this.editdonDangKy,
          {
            headers: {
              Authorization: `Bearer ${JSON.parse(
                localStorage.getItem("user-info")
              )}`,
            },
          }
        )
        .then((response) => {
          this.editdonDangKy = response.data;
          this.dialogDuyet = false;
          this.getDsDonDangKys();
        });
    },
    timKiem() {
      axios
        .get(
          `https://localhost:7195/api/DonDangKy/timkiemphantrang?trangThai=${this.searhTrangThai}`
        )
        .then((response) => {
          this.donDangKys = response.data;
        });
    },
  },
};
</script>

<style scoped>
.layout {
  background-color: bisque;
}
</style>
