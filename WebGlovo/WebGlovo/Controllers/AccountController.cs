using Core.Constants;
using Core.Interfaces;
using Core.Models.Account;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebGlovo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController(IJwtTokenService jwtTokenService,
        IImageService imageService,
        UserManager<UserEntity> userManager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            //this.Request
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = await jwtTokenService.CreateTokenAsync(user);
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid email or password");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {
            var user = new UserEntity
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            user.Image = await imageService.SaveImageAsync(model.ImageFile!);

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.User);
                var token = await jwtTokenService.CreateTokenAsync(user);
                return Ok(new
                {
                    Token = token
                });
            }
            else
            {
                return BadRequest(new
                {
                    status = 400,
                    isValid = false,
                    errors = "Registration failed"
                });
            }

        }        
    }
}
