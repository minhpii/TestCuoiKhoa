<template>
  <div class="layout">
    <v-container>
      <v-breadcrumbs :items="breads">
        <template v-slot:divider>
          <v-icon>mdi-chevron-right</v-icon>
        </template>
      </v-breadcrumbs>
      <h5 class="text-h5">Quản lý đạo tràng</h5>
      <v-card class="mt-5 mb-5">
        <v-card-title>
          <p class="font-weight-regular mb-0">Tìm kiếm đạo tràng</p>
          <v-spacer></v-spacer>
          <v-btn fab small color="green" @click="timKiemDaoTrangs">
            <v-icon color="white">mdi-magnify</v-icon>
          </v-btn>
        </v-card-title>
        <v-card-actions>
          <v-row>
            <v-col cols="3">
              <label>Nơi tổ chức</label>
              <v-text-field
                v-model="searchNoiToChuc"
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
          <v-data-table :headers="headers" :items="daoTrangs">
            <template v-slot:top>
              <v-toolbar flat>
                <v-spacer></v-spacer>
                <template>
                  <v-btn color="primary" dark class="mb-2" @click="addDaoTrang">
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
                            <label>Nơi tổ chức</label>
                            <v-text-field
                              solo
                              hide-details
                              dense
                              v-model="editDaoTrang.noiToChuc"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Thời gian tổ chức</label>
                            <v-text-field
                              type="datetime-local"
                              solo
                              hide-details
                              dense
                              v-model="editDaoTrang.thoiGianToChuc"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Người trụ trì</label>
                            <v-text-field
                              type="number"
                              solo
                              hide-details
                              dense
                              v-model="editDaoTrang.nguoiTruTri"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="12">
                            <label>Nội dung</label>
                            <v-textarea
                              solo
                              hide-details
                              v-model="editDaoTrang.noiDung"
                            ></v-textarea>
                          </v-col>
                          <v-col cols="3">
                            <v-checkbox
                              label="Đã kết thúc"
                              v-model="editDaoTrang.daKetThuc"
                              color="primary"
                              hide-details
                            ></v-checkbox>
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
        text: "Đạo tràng",
        disabled: false,
        href: "/dao-trang",
      },
    ],
    headers: [
      { text: "#", value: "daoTrangId" },
      { text: "Nơi tổ chức", value: "noiToChuc" },
      { text: "Số thành viên tham gia", value: "soThanhVienThamGia" },
      { text: "Thời gian tổ chức", value: "thoiGianToChuc" },
      { text: "Đã kết thúc", value: "daKetThuc" },
      { text: "", value: "actions", sortable: false },
    ],
    dialog: false,
    dialogDelete: false,
    formTitle: "",
    daoTrangs: [],
    searchNoiToChuc: "",
    editDaoTrang: {
      daoTrangId: null,
      noiToChuc: "",
      noiDung: "",
      daKetThuc: null,
      thoiGianToChuc: null,
    },
  }),
  created() {
    this.getDaoTrangs();
    this.timKiemDaoTrangs();
  },
  methods: {
    getDaoTrangs() {
      axios
        .get("https://localhost:7195/api/DaoTrang/dsdaotrang")
        .then((response) => {
          this.daoTrangs = response.data;
        });
    },
    addDaoTrang() {
      this.formTitle = "Thêm Đạo tràng";
      this.editDaoTrang = {
        noiToChuc: "",
        noiDung: "",
        soThanhVienThamGia: null,
        daKetThuc: null,
        thoiGianToChuc: null,
      };
      this.dialog = true;
    },
    editItem(item) {
      this.formTitle = "Sửa Đạo tràng";
      this.editDaoTrang.daoTrangId = item.daoTrangId;
      this.editDaoTrang.noiToChuc = item.noiToChuc;
      this.editDaoTrang.noiDung = item.noiDung;
      this.editDaoTrang.daKetThuc = item.daKetThuc;
      this.editDaoTrang.thoiGianToChuc = item.thoiGianToChuc;
      this.dialog = true;
    },
    deleteItem(item) {
      this.editDaoTrang.daoTrangId = item.daoTrangId;
      this.dialogDelete = true;
    },
    closeDialog() {
      this.dialog = false;
      this.dialogDelete = false;
    },
    saveItem() {
      if (this.formTitle === "Thêm Đạo tràng") {
        axios
          .post(
            "https://localhost:7195/api/DaoTrang/themDaoTrang",
            this.editDaoTrang,
            {
              headers: {
                Authorization: `Bearer ${JSON.parse(
                  localStorage.getItem("user-info")
                )}`,
              },
            }
          )
          .then((response) => {
            this.editDaoTrang = response.data;
            this.dialog = false;
            this.getDaoTrangs();
          });
      } else if (this.formTitle === "Sửa Đạo tràng") {
        axios
          .put(
            "https://localhost:7195/api/DaoTrang/suaDaoTrang",
            this.editDaoTrang,
            {
              headers: {
                Authorization: `Bearer ${JSON.parse(
                  localStorage.getItem("user-info")
                )}`,
              },
            }
          )
          .then((response) => {
            this.editDaoTrang = response.data;
            this.dialog = false;
            this.getDaoTrangs();
          });
      }
    },
    deleteItemConfirm() {
      axios
        .delete(
          `https://localhost:7195/api/DaoTrang/xoadaotrang?daoTrangId=${this.editDaoTrang.daoTrangId}`,
          {
            headers: {
              Authorization: `Bearer ${JSON.parse(
                localStorage.getItem("user-info")
              )}`,
            },
          }
        )
        .then((response) => {
          this.editDaoTrang = response.data;
          this.dialogDelete = false;
          this.getDaoTrangs();
        });
    },
    timKiemDaoTrangs() {
      axios
        .get(
          `https://localhost:7195/api/DaoTrang/timkiemphantrang?keyword=${this.searchNoiToChuc}`,
          {
            headers: {
              Authorization: `Bearer ${JSON.parse(
                localStorage.getItem("user-info")
              )}`,
            },
          }
        )
        .then((response) => {
          this.daoTrangs = response.data;
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
