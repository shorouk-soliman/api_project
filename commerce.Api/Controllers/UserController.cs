using commerce.BL.Dtos.User;
using commerce.DAL.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;



namespace commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UserController(IConfiguration configuration,
            UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(Register registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors); // 400, Errors
            }
            //general information 
            var claims = new List<Claim>
            {
               new (ClaimTypes.NameIdentifier, user.Id.ToString()),
               new (ClaimTypes.Name, user.UserName),
               new (ClaimTypes.Email, user.Email),

             };
            await _userManager.AddClaimsAsync(user, claims);

            return NoContent();
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(Login loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return Unauthorized(); 
            }

            bool isAuthenticated = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isAuthenticated)
            {
                return Unauthorized(); // 401
            }

            var userClaims = await _userManager.GetClaimsAsync(user);

            return GenerateToken(userClaims);
        }

       

            private ActionResult<TokenDto> GenerateToken(IEnumerable<Claim> userClaims)
            {   

           
                var secretkey = _configuration.GetValue<string>("SecretKey")!;
             
                var keyInBytes = Encoding.ASCII.GetBytes(secretkey);

                var key = new SymmetricSecurityKey(keyInBytes);
              
                var signingCredentials = new SigningCredentials(key,
                    SecurityAlgorithms.HmacSha256Signature);

                var expiryDateTime = DateTime.Now.AddDays(5);
               
                var jwt = new JwtSecurityToken(
                    claims: userClaims,
                    expires: expiryDateTime,
                    signingCredentials: signingCredentials
                    );

                var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);

                return new TokenDto(jwtAsString, expiryDateTime);
            }
        }
    }

