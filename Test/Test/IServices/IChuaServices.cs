using Test.Entity;
using Test.Helper;

namespace Test.IServices
{
    public interface IChuaServices
    {
        ErrorMessage ThemChua(Chua chua);
        ErrorMessage SuaChua(Chua chua);
        ErrorMessage XoaChua(int chuaId);
        IQueryable<Chua> DsChua();
        IQueryable<Chua> TimKiemPhanTrang(string? keyword);
    }
}
