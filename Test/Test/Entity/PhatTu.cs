using System;

namespace Test.Entity
{
    public class PhatTu
    {
        public int PhatTuId { get; set; }
        public string? AnhChup { get; set; }
        public bool? DaHoanTuc { get; set; }
        public string? Email { get; set; }
        public int? GioiTinh { get; set; }
        public string? Ho { get; set; }
        public DateTime? NgayCapNhap { get; set; }
        public DateTime? NgayHoanTuc { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayXuatGia { get; set; }
        public string? Password { get; set; }
        public string? PhapDanh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Ten { get; set; }
        public string? TenDem { get; set; }
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
        public string? MaXacThuc { get; set; }
        public int? ChuaId { get; set; }
        public Chua? Chua { get; set; }
        public int? KieuThanhVienId { get; set; }
        public KieuThanhVien? KieuThanhVien { get; set; }
        public IEnumerable<DonDangKy>? DonDangKy { get; set; }
        public IEnumerable<PhatTuDaoTrang>? PhatTuDaoTrang { get; set; }
    }
}
