using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
using System;
using Test.Convert;
using Test.DTO;
using Test.Entity;
using Test.Helper;
using Test.IServices;
using MailKit.Net.Smtp;
using System.Data;

namespace Test.Services
{
    public class PhatTuServices : IPhatTuServices
    {
        private readonly AppDbConText dbConText;
        private readonly PhatTuConverter phatTuConverter;
        public PhatTuServices()
        {
            dbConText = new AppDbConText();
            phatTuConverter = new PhatTuConverter();
        }
        public IQueryable<PhatTuDTO> GetPhanTu()
        {
            var res = dbConText.PhatTus.Where(x => x.IsActive == true).OrderBy(x => x.Ten)
                .Select(x => phatTuConverter.EntityToDTO(x)).AsQueryable();
            return res;
        }
        public ErrorMessage ThemPhatTu(PhatTu phatTu)
        {
            var dsPhatTu = dbConText.PhatTus.AsQueryable();
            foreach (var item in dsPhatTu)
            {
                if (String.Compare(item.Email, phatTu.Email) == 0)
                {
                    return ErrorMessage.EmailDaTonTai;
                }
            }
            phatTu.IsActive = true;
            dbConText.Add(phatTu);
            dbConText.SaveChanges();
            return ErrorMessage.ThanhCong;
        }
        public ErrorMessage SuaPhatTu(PhatTu phatTu)
        {
            var phatTuHienTai = dbConText.PhatTus.FirstOrDefault(x => x.PhatTuId == phatTu.PhatTuId);
            if(phatTuHienTai != null)
            {
                phatTuHienTai.PhatTuId = phatTu.PhatTuId;
                phatTuHienTai.AnhChup = phatTu.AnhChup;
                phatTuHienTai.DaHoanTuc = phatTu.DaHoanTuc;
                phatTuHienTai.Email = phatTu.Email;
                phatTuHienTai.GioiTinh = phatTu.GioiTinh;
                phatTuHienTai.Ho = phatTu.Ho;
                phatTuHienTai.NgayCapNhap = phatTu.NgayCapNhap;
                phatTuHienTai.NgayHoanTuc = phatTu.NgayHoanTuc;
                phatTuHienTai.NgaySinh = phatTu.NgaySinh;
                phatTuHienTai.NgayXuatGia = phatTu.NgayXuatGia;
                phatTuHienTai.PhapDanh = phatTu.PhapDanh;
                phatTuHienTai.SoDienThoai = phatTu.SoDienThoai;
                phatTuHienTai.Ten = phatTu.Ten;
                phatTuHienTai.TenDem = phatTu.TenDem;
                phatTuHienTai.ChuaId = phatTu.ChuaId;
                phatTuHienTai.KieuThanhVienId = phatTu.KieuThanhVienId;
                phatTuHienTai.Role = phatTu.Role;

                dbConText.Update(phatTuHienTai);
                dbConText.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.PhatTuKhongTonTai;
            }
        }
        public ErrorMessage CatNhatTrangThai(int phatTuId)
        {
            var phatTuHienTai = dbConText.PhatTus.FirstOrDefault(x => x.PhatTuId == phatTuId);
            if (phatTuHienTai != null)
            {
                phatTuHienTai.IsActive = false;
                dbConText.Update(phatTuHienTai);
                dbConText.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.PhatTuKhongTonTai;
            }
        }
        public IQueryable<PhatTuDTO> TimKiemPhatTu(string? ten,string? phapDanh,
                                          string? email,int? gioiTinh)
        {
            var check = dbConText.PhatTus.Where(x=> x.IsActive == true).AsQueryable();

            if (!string.IsNullOrEmpty(ten))
            {
                check = check.Where(x => x.Ten.ToLower().Contains(ten.ToLower()));
            }
            if (!string.IsNullOrEmpty(phapDanh))
            {
                check = check.Where(x => x.PhapDanh.ToLower().Contains(phapDanh.ToLower()));
            }
            if (!string.IsNullOrEmpty(email))
            {
                check = check.Where(x => x.Email.ToLower().Contains(email.ToLower()));
            }
            if (gioiTinh.HasValue)
            {
                check = check.Where(x => x.GioiTinh == gioiTinh);
            }
            var query = check.OrderByDescending(x => x.Ten)
              .Select(x => phatTuConverter.EntityToDTO(x)).AsQueryable();
            return query;
        }
        public ErrorMessage DoiMatKhau(string email, string mkcu, string mkmoi)
        {
            var emailHienTai = dbConText.PhatTus.FirstOrDefault(x => x.Email == email);
            if(emailHienTai != null)
            {
                if(emailHienTai.Password == mkcu)
                {
                    emailHienTai.Password = mkmoi;
                    dbConText.Update(emailHienTai);
                    dbConText.SaveChanges();
                    return ErrorMessage.ThanhCong;
                }
                else
                {
                    return ErrorMessage.MatKhauKhongDung;
                }
            }
            else
            {
                return ErrorMessage.EmailKhongTonTai;
            }
        }
        public ErrorMessage GuiMail(string mail)
        {
            var emailHienTai = dbConText.PhatTus.FirstOrDefault(x => x.Email == mail);
            if(emailHienTai != null)
            {
                Random random = new Random();
                string mxt = random.Next(100000, 999999).ToString();

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("minhpii181@gmail.com"));
                email.To.Add(MailboxAddress.Parse(mail));
                email.Subject = "Ma xac rhuc Email cua ban";
                email.Body = new TextPart(TextFormat.Html) { Text = mxt };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("minhpii181@gmail.com", "plhyymcfgqunfgwk");
                smtp.Send(email);
                smtp.Disconnect(true);
                emailHienTai.MaXacThuc = mxt;
                dbConText.Update(emailHienTai);
                dbConText.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.EmailKhongTonTai;
            }
        }
        public ErrorMessage LayLaiMatKhau(string mail, string mxt, string mkmoi)
        {
            var emailHienTai = dbConText.PhatTus.FirstOrDefault(x => x.Email == mail);
            if(emailHienTai != null)
            {
                if(emailHienTai.MaXacThuc == mxt)
                {
                    emailHienTai.Password = mkmoi;
                    dbConText.Update(emailHienTai);
                    dbConText.SaveChanges();
                    return ErrorMessage.ThanhCong;
                }
                else
                {
                    return ErrorMessage.MaXacThucKhongDung;
                }
            }
            else
            {
                return ErrorMessage.EmailKhongTonTai;
            }
        }
    }
}
