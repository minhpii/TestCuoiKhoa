<template>
  <div class="layout">
    <v-container>
      <v-breadcrumbs :items="breads">
        <template v-slot:divider>
          <v-icon>mdi-chevron-right</v-icon>
        </template>
      </v-breadcrumbs>
      <h5 class="text-h5">Quản lý chùa</h5>
      <v-card class="mt-5 mb-5">
        <v-card-title>
          <p class="font-weight-regular mb-0">Tìm kiếm chùa</p>
          <v-spacer></v-spacer>
          <v-btn fab small color="green" @click="timKiemChuas">
            <v-icon color="white">mdi-magnify</v-icon>
          </v-btn>
        </v-card-title>
        <v-card-actions>
          <v-row>
            <v-col cols="3">
              <label>Tên chùa</label>
              <v-text-field
                v-model="searchTenChua"
                type="text"
                dense
                solo
                hide-details
              ></v-text-field>
            </v-col>
          </v-row>
        </v-card-actions>
      </v-card>
      <v-card>
        <v-container>
          <v-data-table :headers="headers" :items="chuas">
            <template v-slot:top>
              <v-toolbar flat>
                <v-spacer></v-spacer>
                <template>
                  <v-btn color="primary" dark class="mb-2" @click="addChua">
                    Thêm
                  </v-btn>
                </template>
                <v-dialog v-model="dialog" max-width="800px">
                  <v-card>
                    <v-card-title>
                      <span class="text-h5">{{ formTitle }}</span>
                    </v-card-title>

                    <v-card-text>
                      <v-container>
                        <v-row>
                          <v-col cols="6">
                            <label>Tên chùa</label>
                            <v-text-field
                              solo
                              hide-details
                              dense
                              v-model="editChua.tenChua"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Địa chỉ</label>
                            <v-text-field
                              solo
                              hide-details
                              dense
                              v-model="editChua.diaChi"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Ngày thành lập</label>
                            <v-text-field
                              type="datetime-local"
                              solo
                              hide-details
                              dense
                              v-model="editChua.ngayThanhLap"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Trụ trì</label>
                            <v-text-field
                              type="number"
                              solo
                              hide-details
                              dense
                              v-model="editChua.truTri"
                            ></v-text-field>
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
                <v-dialog v-model="dialogDelete" max-width="500px">
                  <v-card>
                    <v-card-title class="text-h5"
                      >Bạn có chắc bạn muốn xóa mục này?</v-card-title
                    >
                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-btn color="red darken-1" text @click="closeDialog"
                        >Cancel</v-btn
                      >
                      <v-btn
                        color="blue darken-1"
                        text
                        @click="deleteItemConfirm"
                        >OK</v-btn
                      >
                      <v-spacer></v-spacer>
                    </v-card-actions>
                  </v-card>
                </v-dialog>
              </v-toolbar>
            </template>
            <template v-slot:[`item.actions`]="{ item }">
              <v-btn
                fab
                small
                color="green"
                class="mr-3"
                @click="editItem(item)"
              >
                <v-icon small color="white">mdi-pencil</v-icon>
              </v-btn>
              <v-btn
                fab
                small
                color="red"
                class="mr-3"
                @click="deleteItem(item)"
              >
                <v-icon small color="white">mdi-delete</v-icon>
              </v-btn>
            </template>
          </v-data-table>
        </v-container>
      </v-card>
    </v-container>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data: () => ({
    breads: [
      {
        text: "Home",
        disabled: false,
        href: "/",
      },
      {
        text: "Chùa",
        disabled: false,
        href: "/chua",
      },
    ],
    headers: [
      { text: "#", value: "chuaId" },
      { text: "Tên chùa ", value: "tenChua" },
      { text: "Địa chỉ", value: "diaChi" },
      { text: "Ngày thành lập", value: "ngayThanhLap" },
      { text: "Thao tác", value: "actions", sortable: false },
    ],
    dialog: false,
    dialogDelete: false,
    formTitle: "",
    chuas: [],
    searchTenChua: "",
    editChua: {
      chuaId: null,
      tenChua: "",
      diaChi: "",
      ngayThanhLap: null,
      truTri: null,
    },
  }),
  created() {
    this.getChuas();
    this.timKiemChuas();
  },

  methods: {
    getChuas() {
      axios.get("https://localhost:7195/api/Chua/dschua").then((response) => {
        this.chuas = response.data;
      });
    },
    addChua() {
      this.formTitle = "Thêm Chùa";
      this.editChua = {
        tenChua: "",
        diaChi: "",
        ngayThanhLap: null,
        truTri: null,
      };
      this.dialog = true;
    },
    editItem(item) {
      this.formTitle = "Sửa Chùa";
      this.editChua.chuaId = item.chuaId;
      this.editChua.tenChua = item.tenChua;
      this.editChua.diaChi = item.diaChi;
      this.editChua.ngayThanhLap = item.ngayThanhLap;
      this.editChua.truTri = item.truTri;
      this.dialog = true;
    },
    deleteItem(item) {
      this.editChua.chuaId = item.chuaId;
      this.dialogDelete = true;
    },
    closeDialog() {
      this.dialog = false;
      this.dialogDelete = false;
    },
    saveItem() {
      if (this.formTitle === "Thêm Chùa") {
        axios
          .post("https://localhost:7195/api/Chua/themchua", this.editChua, {
            headers: {
              Authorization: `Bearer ${JSON.parse(
                localStorage.getItem("user-info")
              )}`,
            },
          })
          .then((response) => {
            this.editChua = response.data;
            this.dialog = false;
            this.getChuas();
          });
      } else if (this.formTitle === "Sửa Chùa") {
        axios
          .put("https://localhost:7195/api/Chua/suachua", this.editChua, {
            headers: {
              Authorization: `Bearer ${JSON.parse(
                localStorage.getItem("user-info")
              )}`,
            },
          })
          .then((response) => {
            this.editChua = response.data;
            this.dialog = false;
            this.getChuas();
          });
      }
    },
    deleteItemConfirm() {
      axios
        .delete(
          `https://localhost:7195/api/Chua/xoachua?chuaId=${this.editChua.chuaId}`,
          {
            headers: {
              Authorization: `Bearer ${JSON.parse(
                localStorage.getItem("user-info")
              )}`,
            },
          }
        )
        .then((response) => {
          this.editChua = response.data;
          this.dialogDelete = false;
          this.getChuas();
        });
    },
    timKiemChuas() {
      axios
        .get(
          `https://localhost:7195/api/Chua/timkiemphantrang?keyword=${this.searchTenChua}`,
          {
            headers: {
              Authorization: `Bearer ${JSON.parse(
                localStorage.getItem("user-info")
              )}`,
            },
          }
        )
        .then((response) => {
          this.chuas = response.data;
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
