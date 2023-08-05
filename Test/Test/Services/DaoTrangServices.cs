using Test.Entity;
using Test.Helper;
using Test.IServices;

namespace Test.Services
{
    public class DaoTrangServices : IDaoTrangServices
    {
        private readonly AppDbConText dbConText;
        public DaoTrangServices()
        {
            dbConText = new AppDbConText();
        }
        public ErrorMessage ThemDaoTrang(DaoTrang daoTrang)
        {
            daoTrang.SoThanhVienThamGia = 0;
            dbConText.DaoTrangs.Add(daoTrang);
            dbConText.SaveChanges();
            return ErrorMessage.ThanhCong;
        }
        public ErrorMessage SuaDaoTrang(DaoTrang daoTrang)
        {
            var daoTrangHienTai = dbConText.DaoTrangs.FirstOrDefault(x => x.DaoTrangId == daoTrang.DaoTrangId);
            if(daoTrangHienTai != null)
            {
                daoTrangHienTai.DaoTrangId = daoTrang.DaoTrangId;
                daoTrangHienTai.DaKetThuc = daoTrang.DaKetThuc;
                daoTrangHienTai.NoiDung = daoTrang.NoiDung;
                daoTrangHienTai.NoiToChuc = daoTrang.NoiToChuc;
                daoTrangHienTai.ThoiGianToChuc = daoTrang.ThoiGianToChuc;
                daoTrangHienTai.NguoiTruTri = daoTrang.NguoiTruTri;
                dbConText.Update(daoTrangHienTai);
                dbConText.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.DaoTrangKhongTonTai;
            }
        }
        public ErrorMessage XoaDaoTrang(int daoTrangId)
        {
            var daoTrangHienTai = dbConText.DaoTrangs.FirstOrDefault(x => x.DaoTrangId == daoTrangId);
            if(daoTrangHienTai != null)
            {
                dbConText.Remove(daoTrangHienTai);
                dbConText.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.DaoTrangKhongTonTai;
            }
        }
        public IQueryable<DaoTrang> DsDaoTrang()
        {
            var res = dbConText.DaoTrangs.AsQueryable();
            return res;
        }
        public IQueryable<DaoTrang> TimKiemPhanTrang(string? keyword)
        {
            var query = dbConText.DaoTrangs.AsQueryable();
            if (!String.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.NoiToChuc.ToLower().Contains(keyword.ToLower()));
            }
            return query;
        }
    }
}
