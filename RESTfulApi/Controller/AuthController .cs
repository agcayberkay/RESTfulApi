using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RESTfulApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Kullanıcı adı ve şifre sağlanmalıdır.");
            }

            // Sabit kullanıcı adı ve şifre ile doğrulama
            if (userName == "admin" && password == "password")
            {
                var token = GenerateToken(userName);
                return Ok(new { token });
            }
            else
            {
                return Unauthorized("Geçersiz kullanıcı adı veya şifre.");
            }
        }

        private string GenerateToken(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName), "Kullanıcı adı ve şifre boş olamaz.");
            }

            // Token oluşturma işlemi
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourMuchLongerSecretKeyThatIsAtLeast32Chars"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, userName),
    };

            var token = new JwtSecurityToken(
                issuer: "yourIssuer",
                audience: "yourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet("secure-data")]
        public IActionResult GetSecureData()
        {
            return Ok("Bu veri sadece doğrulanmış kullanıcılar için!");
        }
    }
}
