using Test.DTO;
using Test.Entity;
using Test.Helper;

namespace Test.IServices
{
    public interface IPhatTuServices
    {
        IQueryable<PhatTuDTO> GetPhanTu();
        IQueryable<PhatTuDTO> TimKiemPhatTu(string? ten,string? phapDanh,
                                         string? email,int? gioiTinh);
        ErrorMessage ThemPhatTu(PhatTu phatTu);
        ErrorMessage SuaPhatTu(PhatTu phatTu);
        ErrorMessage CatNhatTrangThai(int phatTuId);
        ErrorMessage DoiMatKhau(string email,string mkcu,string mkmoi);
        ErrorMessage GuiMail(string mail);
        ErrorMessage LayLaiMatKhau(string mail,string mxt,string mkmoi);
    }
}
