using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Entity;
using Test.IServices;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaoTrangController : ControllerBase
    {
        private readonly IDaoTrangServices _daoTrangServices;
        public DaoTrangController()
        {
            _daoTrangServices = new DaoTrangServices();
        }

        [Authorize(Roles = "admin")]
        [HttpPost("themdaotrang")]
        public IActionResult ThemDaoTrang(DaoTrang daoTrang)
        {
            var res = _daoTrangServices.ThemDaoTrang(daoTrang);
            if(res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Thanh cong! <3");
            }
            else
            {
                return BadRequest("Them that bai!!");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("suadaotrang")]
        public IActionResult SuaDaoTrang(DaoTrang daoTrang)
        {
            var res = _daoTrangServices.SuaDaoTrang(daoTrang);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Thanh cong! <3");
            }
            else if(res == Helper.ErrorMessage.DaoTrangKhongTonTai)
            {
                return BadRequest("Dao trang khong ton tai!!");
            }
            else
            {
                return BadRequest("Sua that bai!!");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("xoadaotrang")]
        public IActionResult XoaDaoTrang(int daoTrangId)
        {
            var res = _daoTrangServices.XoaDaoTrang(daoTrangId);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Thanh cong! <3");
            }
            else if (res == Helper.ErrorMessage.DaoTrangKhongTonTai)
            {
                return BadRequest("Dao trang khong ton tai!!");
            }
            else
            {
                return BadRequest("Xoa that bai!!");
            }
        }

        [HttpGet("dsdaotrang")]
        public IActionResult DsDaoTrang()
        {
            var res = _daoTrangServices.DsDaoTrang();
            return Ok(res);
        }

        [HttpGet("timkiemphantrang")]
        public IActionResult TimKiemPhanTrang(string? keyword)
        {
            var res = _daoTrangServices.TimKiemPhanTrang(keyword);
            return Ok(res);
        }
    }
}
