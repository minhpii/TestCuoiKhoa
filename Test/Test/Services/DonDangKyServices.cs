using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using Test.Entity;
using Test.Helper;
using Test.IServices;

namespace Test.Services
{
    public class DonDangKyServices : IDonDangKyServives
    {
        private readonly AppDbConText dbConText;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DonDangKyServices()
        {
            dbConText = new AppDbConText();
            _httpContextAccessor = new HttpContextAccessor();
        }
        private void CatNhatThanhVien(int daoTrangId)
        {
            var daoTrangHienTai = dbConText.DaoTrangs.FirstOrDefault(x => x.DaoTrangId == daoTrangId);
            if (daoTrangHienTai != null)
            {
                daoTrangHienTai.SoThanhVienThamGia = dbConText.DonDangKys.Count(x => x.DaoTrangId == daoTrangHienTai.DaoTrangId);
                dbConText.Update(daoTrangHienTai);
                dbConText.SaveChanges();
            }
        }
        public ErrorMessage ThemDonDangKy(DonDangKy donDangKy)
        {
            if (!dbConText.DaoTrangs.Any(x => x.DaoTrangId == donDangKy.DaoTrangId))
            {
                return ErrorMessage.DaoTrangKhongTonTai;
            }
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("PhatTuId").Value);
            var dsDonDangKy = dbConText.DonDangKys.AsQueryable();
            foreach (var item in dsDonDangKy)
            {
                if (item.DaoTrangId == donDangKy.DaoTrangId && item.PhatTuId == userId)
                {
                    return ErrorMessage.PhatTuThamGiaDaoTrangDaTonTai;
                }
            }
            if (userId != null)
            {
                donDangKy.TrangThaiDon = 0;
                donDangKy.PhatTuId = userId;
                donDangKy.NgayGuiDon = DateTime.Now;
                dbConText.Add(donDangKy);
                dbConText.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.PhatTuKhongTonTai;
            }
        }
        public ErrorMessage DuyetDonDangKy(DonDangKy donDangKy)
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("PhatTuId").Value);
            if (userId != null)
            {
                var donDangKyHienTai = dbConText.DonDangKys.FirstOrDefault(x => x.DonDangKyId == donDangKy.DonDangKyId);
                if (donDangKyHienTai != null)
                {
                    donDangKyHienTai.DonDangKyId = donDangKy.DonDangKyId;
                    donDangKyHienTai.NgayXuLy = DateTime.Now;
                    donDangKyHienTai.NguoiXuLy = userId;
                    donDangKyHienTai.TrangThaiDon = 1;
                    CatNhatThanhVien(donDangKyHienTai.DaoTrangId);
                    dbConText.Update(donDangKyHienTai);
                    dbConText.SaveChanges();
                    return ErrorMessage.ThanhCong;
                }
                else
                {
                    return ErrorMessage.DonDangKyKhongTonTai;
                }
            }
            else
            {
                return ErrorMessage.PhatTuKhongTonTai;
            }
        }
        public IQueryable<DonDangKy> DsDonDangKy()
        {
            var dsDonDangKy = dbConText.DonDangKys.AsQueryable();
            return dsDonDangKy;
        }
        public IQueryable<DonDangKy> TimKiemPhanTrang(int? trangThai)
        {
            var query = dbConText.DonDangKys.AsQueryable();
            if (trangThai.HasValue)
            {
                query = query.Where(x => x.TrangThaiDon == trangThai);
            }
            return query;
        }
    }
}
