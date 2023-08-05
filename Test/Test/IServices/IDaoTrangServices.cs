using Test.Entity;
using Test.Helper;

namespace Test.IServices
{
    public interface IDaoTrangServices
    {
        ErrorMessage ThemDaoTrang(DaoTrang daoTrang);
        ErrorMessage SuaDaoTrang(DaoTrang daoTrang);
        ErrorMessage XoaDaoTrang(int daoTrangId);
        IQueryable<DaoTrang> DsDaoTrang();
        IQueryable<DaoTrang> TimKiemPhanTrang(string? keyword);
    }
}
