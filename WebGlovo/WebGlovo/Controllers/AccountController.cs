using Core.Constants;
using Core.Interfaces;
using Core.Mapper;
using Core.Models.Account;
using Core.Services;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebGlovo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController(IJwtTokenService jwtTokenService,
        IAccountService accountService,
        IImageService imageService,
        UserMapper userMapper,
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
            var existingUser = await userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest(new
                {
                    status = 400,
                    isValid = false,
                    errors = new { Email = "Користувач з такою поштою вже існує" }
                });
            }

            var user = userMapper.RegisterToUser(model);

            //var user = new UserEntity
            //{
            //    Email = model.Email,
            //    UserName = model.Email,
            //    FirstName = model.FirstName,
            //    LastName = model.LastName
            //};

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

        [HttpPost]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequestModel model)
        {
            string result = await accountService.LoginByGoogle(model.Token);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest(new
                {
                    Status = 400,
                    IsValid = false,
                    Errors = new { Email = "Помилка реєстрації" }
                });
            }
            return Ok(new
            {
                Token = result
            });
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            bool res = await accountService.ForgotPasswordAsync(model);
            if (res)
                return Ok();
            else
                return BadRequest(new
                {
                    Status = 400,
                    IsValid = false,
                    Errors = new { Email = "Користувача з такою поштою не існує" }
                });
        }

        [HttpGet]
        public async Task<IActionResult> ValidateResetToken([FromQuery] ValidateResetTokenModel model)
        {
            bool res = await accountService.ValidateResetTokenAsync(model);
            return Ok(new { IsValid = res });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            await accountService.ResetPasswordAsync(model);
            return Ok();
        }

    }
}
