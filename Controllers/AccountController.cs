using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using tawsel.DTO;
using tawsel.Helpers;
using tawsel.models;

namespace tawsel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> usermanger;
        private readonly RoleManager<CustomRole> _roleManager;
        private readonly IConfiguration config;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly tawseel dp;
        private readonly ResponseDto _response;

        public AccountController(UserManager<ApplicationUser> usermanger,RoleManager<CustomRole> roleManager, IConfiguration config, SignInManager<ApplicationUser> _signInManager, tawseel dp)
        {
            this.usermanger = usermanger;
            _roleManager = roleManager;
            this.config = config;
            this._signInManager = _signInManager;
            this.dp = dp;
            _response = new ResponseDto();

        }

        //api/account/register
        [HttpPost("register")]
        [RequestsFilter("insert", "Account")]
        public async Task<IActionResult> Registration(RegisterUserDto userDto)
        {
            if (userDto is null || !ModelState.IsValid)
            {
                _response.IsSuccessfulOperation = false;
                _response.Errors = ModelState.Values.SelectMany(e => e.Errors.Select(error => error.ErrorMessage));
                return BadRequest(_response);
            }

            var userNameExists = await usermanger.FindByNameAsync(userDto.UserName);
            if (userNameExists is not null)
            {
                return BadRequest(new { message = "UserName already Exists" });
            }

            var emailExists = await usermanger.FindByEmailAsync(userDto.Email);
            if (emailExists is not null)
            {
                return BadRequest(new { message = "Email already Exists" });
            }

            ApplicationUser user = new ApplicationUser();
            user.FullName = userDto.Full_Name;
            user.Email = userDto.Email;
            user.UserName = userDto.UserName;
            user.Active = true;

            // add user to Permissions Group
            user.RoleId = userDto.roleId;
            var role =  await _roleManager.FindByIdAsync(userDto.roleId);

            if (role is null)
                return BadRequest(new { messsage = "This Role not Exixts" });

            var result = await usermanger.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
                return BadRequest(new { errors = result.Errors.Select(e => e.Description).ToList() });


            
            await usermanger.AddToRoleAsync(user,role.Name);
            await _signInManager.SignInAsync(user, false);
            return Ok(new { message = "User Created Successfully" });

        }


        //api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto userDto)
        {
            if (userDto is null || !ModelState.IsValid)
            {
                _response.IsSuccessfulOperation = false;
                _response.Errors = ModelState.Values.SelectMany(e => e.Errors.Select(error => error.ErrorMessage));
                return BadRequest(_response);
            }

            ApplicationUser user = await usermanger.FindByEmailAsync(userDto.Email);

            if (user is null)
                return Unauthorized(new { message = "This Email Does not Exists" });

            bool isValidPassword = await usermanger.CheckPasswordAsync(user, userDto.Password);

            if (!isValidPassword)
                return BadRequest(new { message = "UserName or Password is not correct" });

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));


            var roles = await usermanger.GetRolesAsync(user);
            foreach (var itemRole in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, itemRole));
            }


            SecurityKey securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

            SigningCredentials signincred =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: config["JWT:ValidIssuer"],
                audience: config["JWT:ValidAudiance"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signincred
                );


            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                userName = user.UserName,
                userId = user.Id

            }); ;
        }
    }
}
