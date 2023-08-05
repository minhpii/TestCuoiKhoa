using Test.Entity;
using Test.Helper;
using Test.IServices;

namespace Test.Services
{
    public class ChuaServices : IChuaServices
    {
        private readonly AppDbConText dbConText;
        public ChuaServices()
        {
            dbConText = new AppDbConText();
        }
        public ErrorMessage ThemChua(Chua chua)
        {
            chua.CapNhap = DateTime.Now;
            dbConText.Add(chua);
            dbConText.SaveChanges();
            return ErrorMessage.ThanhCong;
        }
        public ErrorMessage SuaChua(Chua chua)
        {
            var chuaHienTai = dbConText.Chuas.FirstOrDefault(x => x.ChuaId == chua.ChuaId);
            if(chuaHienTai != null)
            {
                chuaHienTai.ChuaId = chua.ChuaId;
                chuaHienTai.CapNhap = DateTime.Now;
                chuaHienTai.DiaChi = chua.DiaChi;
                chuaHienTai.NgayThanhLap = chua.NgayThanhLap;
                chuaHienTai.TenChua = chua.TenChua;
                chuaHienTai.TruTri = chua.TruTri;
                dbConText.Update(chuaHienTai);
                dbConText.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ChuaKhongTonTai;
            }
        }
        public ErrorMessage XoaChua(int chuaId)
        {
            var chuaHienTai = dbConText.Chuas.FirstOrDefault(x => x.ChuaId == chuaId);
            if(chuaHienTai != null)
            {
                dbConText.Remove(chuaHienTai);
                dbConText.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ChuaKhongTonTai;
            }
        }
        public IQueryable<Chua> TimKiemPhanTrang(string? keyword)
        {
            var query = dbConText.Chuas.AsQueryable();
            if(!String.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.TenChua.ToLower().Contains(keyword.ToLower()));
            }
            return query;
        }
        public IQueryable<Chua> DsChua()
        {
            var query = dbConText.Chuas.AsQueryable();
            return query;
        }
    }
}
