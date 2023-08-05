using Test.DTO;
using Test.Entity;

namespace Test.Convert
{
    public class PhatTuConverter
    {
        public PhatTuDTO EntityToDTO(PhatTu phatTu)
        {
            return new PhatTuDTO
            {
                PhatTuId = phatTu.PhatTuId,
                AnhChup = phatTu.AnhChup,
                SoDienThoai = phatTu.SoDienThoai,
                DaHoanTuc = phatTu.DaHoanTuc,
                Email = phatTu.Email,
                GioiTinh = phatTu.GioiTinh,
                Ten = phatTu.Ten,
                PhapDanh = phatTu.PhapDanh,
                NgayCapNhap = phatTu.NgayCapNhap,
                NgayHoanTuc = phatTu.NgayHoanTuc,
                NgaySinh = phatTu.NgaySinh,
                NgayXuatGia = phatTu.NgayXuatGia,
                IsActive = phatTu.IsActive,
            };
        }

    }
}
