using IdentityProject.Models.AuthVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SingIn([FromForm] SignUpVM signUpVM)
        {
            var email = await _userManager.FindByEmailAsync(signUpVM.Email);

            if (email == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = signUpVM.UserName,
                    Email = signUpVM.Email,
                    PhoneNumber = signUpVM.PhoneNumber,
                };
                var result = await _userManager.CreateAsync(user, signUpVM.Password);
            }

            return Ok(signUpVM);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromForm] SignInVM signIn)
        {

            var user = await _userManager.FindByEmailAsync(signIn.Email);

            if (user == null)
            {
                return BadRequest("User with this email not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, signIn.Password, false, false);
            if (result.Succeeded)
            {

                var users = await _userManager.FindByEmailAsync(signIn.Email);
                var token = createToken(users);

                return Ok(token);

            }
            return BadRequest("Invalid login attempt.");
        }

        [HttpGet]
        public string createToken(IdentityUser users)
        {
            var claims = new List<Claim>
           {
               new Claim(ClaimTypes.NameIdentifier, users.UserName),
               new Claim(ClaimTypes.Email,users.Email)
           };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fhsfhooiogfhbggkgjgjffhmgmumfj,gg,g,jfjmhrytfhkj"));
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                expires: DateTime.Now.AddDays(1),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }

    }

}
    
