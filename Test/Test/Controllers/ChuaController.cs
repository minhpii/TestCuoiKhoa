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
    public class ChuaController : ControllerBase
    {
        IChuaServices _chuaServices;
        public ChuaController()
        {
            _chuaServices = new ChuaServices();
        }

        [Authorize(Roles ="admin")]
        [HttpPost("themchua")]
        public IActionResult ThemChua(Chua chua)
        {
            var res = _chuaServices.ThemChua(chua);
            if(res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Them thanh cong! <3");
            }
            else
            {
                return BadRequest("Them that bai!!");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("suachua")]
        public IActionResult SuaChua(Chua chua)
        {
            var res = _chuaServices.SuaChua(chua);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Sua thanh cong! <3");
            }
            else if(res == Helper.ErrorMessage.ChuaKhongTonTai)
            {
                return BadRequest("Chua Khong ton tai!!");
            }
            else
            {
                return BadRequest("Sua that bai!!");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("xoachua")]
        public IActionResult XoaChua(int chuaId)
        {
            var res = _chuaServices.XoaChua(chuaId);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Xoa thanh cong! <3");
            }
            else if (res == Helper.ErrorMessage.ChuaKhongTonTai)
            {
                return BadRequest("Chua Khong ton tai!!");
            }
            else
            {
                return BadRequest("Xoa that bai!!");
            }
        }

        [HttpGet("dschua")]
        public IActionResult DsChua()
        {
            var res = _chuaServices.DsChua();
            return Ok(res);
        }

        [HttpGet("timkiemphantrang")]
        public IActionResult TimKiemPhanTrang(string? keyword)
        {
            var res = _chuaServices.TimKiemPhanTrang(keyword);
            return Ok(res);
        }
    }
}
