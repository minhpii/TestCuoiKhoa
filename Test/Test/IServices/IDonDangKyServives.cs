using Test.Entity;
using Test.Helper;

namespace Test.IServices
{
    public interface IDonDangKyServives
    {
        ErrorMessage ThemDonDangKy(DonDangKy donDangKy);
        ErrorMessage DuyetDonDangKy(DonDangKy donDangKy);
        IQueryable<DonDangKy> DsDonDangKy();
        IQueryable<DonDangKy> TimKiemPhanTrang(int? trangThai);
    }
}
