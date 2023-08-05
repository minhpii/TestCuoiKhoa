using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.DTO;
using Test.Entity;
using Test.IServices;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDangKyController : ControllerBase
    {
        IDonDangKyServives _donDangKyServives;
        public DonDangKyController()
        {
            _donDangKyServives = new DonDangKyServices();
        }

        [HttpPost("themdondangky")]
        public IActionResult ThemDonDangKy(DonDangKy donDangKy)
        {
            var res = _donDangKyServives.ThemDonDangKy(donDangKy);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Thanh cong! <3");
            }
            else if (res == Helper.ErrorMessage.PhatTuKhongTonTai)
            {
                return BadRequest("Phat tu khong ton tai!!");
            }
            else if (res == Helper.ErrorMessage.DaoTrangKhongTonTai)
            {
                return BadRequest("Dao trang khong ton tai!!");
            }
            else if (res == Helper.ErrorMessage.PhatTuThamGiaDaoTrangDaTonTai)
            {
                return BadRequest("Ban da dang ky tham gia dao trang nay!!");
            }
            else
            {
                return BadRequest("That bai!!");
            }
        }

        [Authorize(Roles ="admin")]
        [HttpPut("duyetdondangky")]
        public IActionResult DuyetDonDangKy(DonDangKy donDangKy)
        {
            var res = _donDangKyServives.DuyetDonDangKy(donDangKy);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Thanh cong! <3");
            }
            else if (res == Helper.ErrorMessage.PhatTuKhongTonTai)
            {
                return BadRequest("Phat tu khong ton tai!!");
            }
            else if (res == Helper.ErrorMessage.DonDangKyKhongTonTai)
            {
                return BadRequest("Don dang ky khong ton tai!!");
            }
            else if (res == Helper.ErrorMessage.PhatTuThamGiaDaoTrangDaTonTai)
            {
                return BadRequest("Phat tu nay da tham gia dao trang!!");
            }
            else
            {
                return BadRequest("That bai!!");
            }
        }

        [HttpGet("dsdondangky")]
        public IActionResult DsDonDangKy()
        {
            var res = _donDangKyServives.DsDonDangKy();
            return Ok(res);
        }

        [HttpGet("timkiemphantrang")]
        public IActionResult TimKiemPhanTrang(int? trangThai)
        {
            var res = _donDangKyServives.TimKiemPhanTrang(trangThai);
            return Ok(res);
        }
    }
}
