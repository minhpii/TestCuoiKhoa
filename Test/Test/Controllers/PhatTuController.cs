using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test.DTO;
using Test.Entity;
using Test.IServices;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhatTuController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly AppDbConText dbConText;
        IPhatTuServices _phatTuServices;
        public PhatTuController(IConfiguration configuration)
        {
            _phatTuServices = new PhatTuServices();
            _configuration = configuration;
            dbConText = new AppDbConText();
        }
        private string GenerateTocken(PhatTu phatTu)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("phatTuId", phatTu.PhatTuId.ToString()),
                new Claim("Email", phatTu.Email),
                new Claim(ClaimTypes.Role, phatTu.Role),
            };
            var sercuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(sercuritykey, SecurityAlgorithms.HmacSha256);

            var tocken = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(tocken);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] JObject request)
        {

            var phatTu = dbConText.PhatTus.FirstOrDefault(x => x.Email == request["email"].Value<string>());

            if (phatTu == null)
            {
                return BadRequest("Email khong ton tai!");
            }
            else
            {
                if (phatTu.Password == request["password"].Value<string>())
                {
                    string tocken = GenerateTocken(phatTu);
                    return Ok(tocken);
                }
                else
                {
                    return BadRequest("Mat khau khong dung!");
                }
            }
        }

        [HttpPost("themphattu")]
        public IActionResult ThemPhatTu(PhatTu phatTu)
        {
            var res = _phatTuServices.ThemPhatTu(phatTu);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                phatTu.Role = "member";
                return Ok("Them thanh cong! <3");
            }
            else if (res == Helper.ErrorMessage.EmailDaTonTai)
            {
                return Ok("Email da ton tai!!");
            }
            else
            {
                return BadRequest("Sua that bai!!");
            }
        }

        [HttpGet("danhsachphattu")]
        public IActionResult GetPhatTu()
        {
            var check = _phatTuServices.GetPhanTu();
            return Ok(check);
        }

        [Authorize(Roles ="admin")]
        [HttpGet("timkiemphattu")]
        public IActionResult TimKiemPhatTu(string? ten,string? phapDanh,
                                          string? email, int? gioiTinh)
        {
            var res = _phatTuServices.TimKiemPhatTu(ten, phapDanh, email, gioiTinh);
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("suaphattu")]
        public IActionResult SuaPhatTu(PhatTu phatTu)
        {
            var res = _phatTuServices.SuaPhatTu(phatTu);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Sua thanh cong! <3");
            }
            else if (res == Helper.ErrorMessage.EmailDaTonTai)
            {
                return Ok("Email da ton tai!!");
            }
            else if (res == Helper.ErrorMessage.PhatTuKhongTonTai)
            {
                return Ok("Phat tu khong ton tai!!");
            }
            else
            {
                return BadRequest("Sua that bai!!");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("catnhattrangthai")]
        public IActionResult CatnhatTrangThai(int phatTuId)
        {
            var res = _phatTuServices.CatNhatTrangThai(phatTuId);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Cat nhat thanh cong! <3");
            }
            else if (res == Helper.ErrorMessage.PhatTuKhongTonTai)
            {
                return Ok("Phat tu khong ton tai!!");
            }
            else
            {
                return BadRequest("Cat nhat that bai!!");
            }
        }

        [HttpPost("doimatkhau")]
        public IActionResult DoiMatKhau(string email, string mkcu, string mkmoi)
        {
            var res = _phatTuServices.DoiMatKhau(email, mkcu,mkmoi);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Doi mat khau thanh cong! <3");
            }
            else if (res == Helper.ErrorMessage.EmailKhongTonTai)
            {
                return Ok("Email khong ton tai!!");
            }
            else if (res == Helper.ErrorMessage.MatKhauKhongDung)
            {
                return Ok("Mat khau cu khong dung!!");
            }
            else
            {
                return BadRequest("Doi mat khau that bai!!");
            }
        }

        [HttpPost("guimaxacthuc")]
        public IActionResult GuiMail(string mail)
        {
            var res = _phatTuServices.GuiMail(mail);
            if (res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Gui thanh cong! <3");
            }
            else
            {
                return BadRequest("Email khong ton tai!!");
            }
        }

        [HttpPost("laylaimatkhau")]
        public IActionResult LayLaiMatKhau(string mail,string mxt, string mkmoi)
        {
            var res = _phatTuServices.LayLaiMatKhau(mail, mxt, mkmoi);
            if(res == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Thanh cong! <3");
            }
            else if(res == Helper.ErrorMessage.EmailKhongTonTai)
            {
                return BadRequest("Email khong ton tai!!");
            }
            else if (res == Helper.ErrorMessage.MaXacThucKhongDung)
            {
                return BadRequest("Ma xac thuc khong dung!!");
            }
            else
            {
                return BadRequest("That bai!!");
            }
        }
    }
}
