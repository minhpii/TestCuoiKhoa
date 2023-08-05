<template>
  <div class="layout">
    <v-container>
      <v-breadcrumbs :items="breads" drak>
        <template v-slot:divider>
          <v-icon>mdi-chevron-right</v-icon>
        </template>
      </v-breadcrumbs>
      <h5 class="text-h5">Quản lý phật tử</h5>
      <v-card class="mt-5 mb-5">
        <v-card-title>
          <p class="font-weight-regular mb-0">Tìm kiếm phật tử</p>
          <v-spacer></v-spacer>
          <v-btn fab small color="green" @click="timKiemPhatTus">
            <v-icon color="white">mdi-magnify</v-icon>
          </v-btn>
        </v-card-title>
        <v-card-actions>
          <v-row>
            <v-col cols="3">
              <label for="">Tên</label>
              <v-text-field
                v-model="searchTen"
                type="text"
                dense
                solo
                hide-details
              ></v-text-field>
            </v-col>
            <v-col cols="3">
              <label for="">Pháp danh</label>
              <v-text-field
                v-model="searchPhapDanh"
                type="text"
                dense
                solo
                hide-details
              ></v-text-field>
            </v-col>
            <v-col cols="3">
              <label for="">Email</label>
              <v-text-field
                v-model="searchEmail"
                type="text"
                dense
                solo
                hide-details
              ></v-text-field>
            </v-col>
            <v-col cols="3">
              <label for="">Giới tính</label>
              <v-select
                :items="selectGioiTinh"
                item-text="name"
                item-value="value"
                v-model="searchGioiTinh"
                dense
                solo
                hide-details
              ></v-select>
            </v-col>
            <v-col cols="3" class="mb-5">
              <label for="">Trạng thái phật tử</label>
              <v-select
                :items="selectTrangThaiPhatTu"
                item-text="name"
                item-value="value"
                v-model="searchTrangThaiPhatTu"
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
          <v-data-table :headers="headers" :items="phatTus">
            <template v-slot:[`item.shows`]="{ item }">
              <v-btn
                fab
                small
                color="green"
                class="mr-3"
                @click="showPhatTu(item)"
              >
                <v-icon color="white">mdi-account</v-icon>
              </v-btn>
            </template>
            <template v-slot:[`item.actions`]="{ item }">
              <v-btn
                fab
                small
                color="green"
                class="mr-3"
                @click="catNhat(item)"
              >
                <v-icon small color="white">mdi-pencil</v-icon>
              </v-btn>
              <v-btn fab small color="red" @click="catNhatTrangThai(item)">
                <v-icon small color="white">mdi-pencil</v-icon>
              </v-btn>
            </template>
            <template v-slot:top>
              <v-toolbar flat>
                <v-dialog v-model="dialogTrangThai" max-width="800px">
                  <v-card>
                    <v-card-title>
                      <span class="text-h5">Cật nhật trạng thái</span>
                    </v-card-title>

                    <v-card-text>
                      <v-container>
                        <v-row>
                          <v-col cols="3">
                            <v-checkbox
                              label="IsActive"
                              v-model="editPhatTu.isActive"
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
                      <v-btn
                        color="blue darken-1"
                        text
                        @click="updateTrangThai"
                      >
                        Lưu
                      </v-btn>
                    </v-card-actions>
                  </v-card>
                </v-dialog>
                <v-dialog v-model="dialog" max-width="800px">
                  <v-card>
                    <v-card-title>
                      <span class="text-h5">{{ formTitle }}</span>
                    </v-card-title>

                    <v-card-text>
                      <v-container>
                        <v-row>
                          <v-col cols="12">
                            <label>Ảnh đại diện người dùng</label>
                            <v-text-field
                              type="file"
                              solo
                              hide-details
                              dense
                              v-model="editPhatTu.anhChup"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Họ tên</label>
                            <v-text-field
                              solo
                              hide-details
                              dense
                              v-model="editPhatTu.ten"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Pháp danh</label>
                            <v-text-field
                              solo
                              hide-details
                              dense
                              v-model="editPhatTu.phapDanh"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Email</label>
                            <v-text-field
                              solo
                              hide-details
                              dense
                              v-model="editPhatTu.email"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Số điện thoại</label>
                            <v-text-field
                              solo
                              hide-details
                              dense
                              v-model="editPhatTu.soDienThoai"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Ngày sinh</label>
                            <v-text-field
                              type="datetime-local"
                              solo
                              hide-details
                              dense
                              v-model="editPhatTu.ngaySinh"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="6">
                            <label>Ngày xuất gia</label>
                            <v-text-field
                              type="datetime-local"
                              solo
                              hide-details
                              dense
                              v-model="editPhatTu.ngayXuatGia"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <label>Giới tính</label>
                            <v-select
                              :items="selectGioiTinh"
                              item-text="name"
                              item-value="value"
                              v-model="editPhatTu.gioiTinh"
                              dense
                              solo
                              hide-details
                            ></v-select>
                          </v-col>
                          <v-col cols="4">
                            <label>Hoàn tục</label>
                            <v-select
                              :items="selectHoanTuc"
                              item-text="name"
                              item-value="value"
                              v-model="editPhatTu.daHoanTuc"
                              dense
                              solo
                              hide-details
                            ></v-select>
                          </v-col>
                          <v-col cols="4">
                            <label>Ngày hoàn tục</label>
                            <v-text-field
                              type="datetime-local"
                              solo
                              hide-details
                              dense
                              v-model="editPhatTu.ngayHoanTuc"
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
export default {
  data: () => ({
    breads: [
      {
        text: "Home",
        disabled: false,
        href: "/",
      },
      {
        text: "Phật tử",
        disabled: false,
        href: "/phat-tu",
      },
    ],
    headers: [
      { text: "", value: "shows", sortable: false },
      { text: "Phật tử", value: "phatTu" },
      { text: "Ngày xuất gia", value: "ngayXuatGia" },
      { text: "Số điện thoại", value: "soDienThoai" },
      {
        text: "Số buổi đạo tràng đã tham gia",
        value: "soBuoiDaoTrangDaThamGia",
      },
      { text: "Thao tác", value: "actions", sortable: false },
    ],
    searchTen: "",
    searchPhapDanh: "",
    searchEmail: "",
    searchGioiTinh: "",
    searchTrangThaiPhatTu: null,
    selectGioiTinh: [
      { name: "nam", value: 0 },
      { name: "nữ", value: 1 },
    ],
    selectHoanTuc: [
      { name: "đã hoàn tục", value: 0 },
      { name: "chưa hoàn tục", value: 1 },
    ],
    selectTrangThaiPhatTu: [
      { name: "active", value: true },
      { name: "unactive", value: false },
    ],
    dialogTrangThai: false,
    phatTus: [],
    editPhatTu: {
      phatTuId: null,
      anhChup: "",
      ten: "",
      phapDanh: "",
      email: "",
      soDienThoai: "",
      ngaySinh: null,
      ngayXuatGia: null,
      gioiTinh: "",
      daHoanTuc: "",
      ngayHoanTuc: null,
      isActive: null,
    },
    formTitle: "",
    dialog: false,
  }),
  created() {
    this.getPhatTus();
    this.timKiemPhatTus();
  },
  methods: {
    getPhatTus() {
      axios
        .get("https://localhost:7195/api/PhatTu/danhsachphattu")
        .then((response) => {
          this.phatTus = response.data;
        });
    },
    timKiemPhatTus() {
      axios
        .get(
          `https://localhost:7195/api/PhatTu/timkiemphattu?ten=${this.searchTen}&phapDanh=${this.searchPhapDanh}&email=${this.searchEmail}&gioiTinh=${this.searchGioiTinh}`,
          {
            headers: {
              Authorization: `Bearer ${JSON.parse(
                localStorage.getItem("user-info")
              )}`,
            },
          }
        )
        .then((response) => {
          this.phatTus = response.data;
        });
    },
    catNhatTrangThai(item) {
      this.editPhatTu.phatTuId = item.phatTuId;
      this.editPhatTu.isActive = item.isActive;
      this.dialogTrangThai = true;
    },
    closeDialog() {
      this.dialogTrangThai = false;
      this.dialog = false;
    },
    updateTrangThai() {
      axios
        .put(
          `https://localhost:7195/api/PhatTu/catnhattrangthai?phatTuId=${this.editPhatTu.phatTuId}`,
          {
            headers: {
              Authorization: `Bearer ${JSON.parse(
                localStorage.getItem("user-info")
              )}`,
            },
          }
        )
        .then((response) => {
          this.editPhatTu = response.data;
          this.dialogTrangThai = false;
          this.getPhatTus();
        });
    },
    catNhat(item) {
      this.editPhatTu.formTitle = "Sửa phật tử";
      this.editPhatTu.phatTuId = item.phatTuId;
      this.editPhatTu.anhChup = item.anhChup;
      this.editPhatTu.ten = item.ten;
      this.editPhatTu.phapDanh = item.phapDanh;
      this.editPhatTu.email = item.email;
      this.editPhatTu.soDienThoai = item.soDienThoai;
      this.editPhatTu.ngayXuatGia = item.ngayXuatGia;
      this.editPhatTu.gioiTinh = item.gioiTinh;
      this.editPhatTu.ngaySinh = item.ngaySinh;
      this.editPhatTu.daHoanTuc = item.daHoanTuc;
      this.editPhatTu.ngayHoanTuc = item.ngayHoanTuc;
      this.dialog = true;
    },
    saveItem() {
      axios
        .put("https://localhost:7195/api/PhatTu/suaphattu", this.editPhatTu, {
          headers: {
            Authorization: `Bearer ${JSON.parse(
              localStorage.getItem("user-info")
            )}`,
          },
        })
        .then((response) => {
          this.editPhatTu = response.data;
          this.dialog = false;
          this.getPhatTus();
        });
    },
    showPhatTu(item) {
      this.editPhatTu.formTitle = "Thông tin phật tử";
      this.editPhatTu.phatTuId = item.phatTuId;
      this.editPhatTu.anhChup = item.anhChup;
      this.editPhatTu.ten = item.ten;
      this.editPhatTu.phapDanh = item.phapDanh;
      this.editPhatTu.email = item.email;
      this.editPhatTu.soDienThoai = item.soDienThoai;
      this.editPhatTu.ngayXuatGia = item.ngayXuatGia;
      this.editPhatTu.gioiTinh = item.gioiTinh;
      this.editPhatTu.ngaySinh = item.ngaySinh;
      this.editPhatTu.daHoanTuc = item.daHoanTuc;
      this.editPhatTu.ngayHoanTuc = item.ngayHoanTuc;
      this.dialog = true;
    },
  },
};
</script>

<style scoped>
.layout {
  background-color: bisque;
}
</style>
