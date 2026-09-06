using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using CourierPackage_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourierPackage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService  _emailService;
        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,ITokenService tokenService,IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateUser([FromBody] UserRegisterRequestDto user)
        {
            var userNameExists = await _userManager.FindByNameAsync(user.UserName);



            if (userNameExists == null)
            {
                var userOb = new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    NickName = user.NickName,
                    PhoneNumber = user.PhoneNumber,
                    CreatedBy = user.TrnUser,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = user.TrnUser,
                    IsActive = true
                };

                var success = await _userManager.CreateAsync(userOb, user.Password);

                var createdUser = await _userManager.FindByNameAsync(user.UserName);

                var roleExists =
                await _roleManager.RoleExistsAsync(user.RoleName);

                if (!roleExists)
                {
                    return NotFound(new
                    {
                        message = "Role does not exist."
                    });
                }

                var alreadyInRole =
                await _userManager.IsInRoleAsync(
                    createdUser,
                    user.RoleName
                );

                if (alreadyInRole)
                {
                    return BadRequest(new
                    {
                        message =
                            "User already has this role."
                    });
                }

                var roleAssign = await _userManager.AddToRoleAsync(
                    createdUser,
                    user.RoleName
                );

                if (success.Errors.Count() == 0)
                {
                    return Ok(new { message = "User account has been created successfully. !!!" });
                }
                else
                {
                    return BadRequest(new { message = success.Errors.FirstOrDefault()?.Description.ToString() });
                }
            }
            else
            {
                return BadRequest(new { message = "User Name Already exists ..Try Different User Name.!" });
            }
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> UserLogIn([FromBody] UserLoginRequestDto user)
        {
            var userExists = await _userManager.FindByNameAsync(user.UserName);

            if (userExists == null)
            {
                return BadRequest(new
                {
                    message = "User name does not exist. Please try again."
                });
            }

            if (!userExists.IsActive) 
            {
                return BadRequest(new
                {
                    message = "User account is in deactive . Please contact IT Team."
                });
            }

            var isPasswordValid = await _userManager
                .CheckPasswordAsync(userExists, user.PassWord);

            if (!isPasswordValid)
            {
                return BadRequest(new
                {
                    message = "Invalid password. Please try again."
                });
            }

            var roles = await _userManager.GetRolesAsync(userExists);

            var tokenResult = await _tokenService
                .GenerateAccessToken(userExists.Id, roles);

            //await _emailService.SendEmailAsync("shehanvindika429@gmail.com","Test Mail","Check Karagannane");

            if (!tokenResult.success)
            {
                return BadRequest(new
                {
                    message = "Access token generation failed."
                });
            }

            var expireDate = DateTime.Now.AddHours(10);

            var refreshTokenResult = await _tokenService
                .UpdateRefreshToken(
                    userExists.Id,
                    expireDate,
                    userExists.Id);

            return Ok(new
            {
                accessToken = tokenResult.AccessToken
            });
        }

        [Authorize]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequestDto user)
        {
            var userExist = await _userManager.FindByNameAsync(user.UserName);

            if (userExist == null) 
            {
                return NotFound( new { message = "User Name not exists !!!."});
            }

            userExist.PhoneNumber = user.PhoneNumber;
            userExist.UserName = user.UserName;
            userExist.NickName = user.NickName;
            userExist.Email = user.Email;
            userExist.UpdatedBy = user.TrnUser;
            userExist.UpdatedDate = DateTime.Now;

            await _userManager.UpdateAsync(userExist);

            return Ok(new
            {
                message = "User has been updated successfully."
            });

        }

        [Authorize]
        [HttpPatch]
        [Route("Active")]
        public async Task<IActionResult> UserActivation(string userName)
        {
            var userExist = await _userManager.FindByNameAsync(userName);

            if (userExist == null)
            {
                return NotFound(new { message = "User Name not exists !!!." });
            }

            userExist.IsActive = true;

            await _userManager.UpdateAsync(userExist);

            return Ok(new
            {
                message = "User has been activated successfully."
            });
        }

        [Authorize]
        [HttpPatch]
        [Route("Deactive")]
        public async Task<IActionResult> UserDeactivation(string userName)
        {
            var userExist = await _userManager.FindByNameAsync(userName);

            if (userExist == null)
            {
                return NotFound(new { message = "User Name not exists !!!." });
            }

            userExist.IsActive = false;

            await _userManager.UpdateAsync(userExist);

            return Ok(new
            {
                message = "User has been deactivated successfully."
            });
        }

        //[Authorize]
        //[HttpPatch]
        //[Route("ResetPassword")]
        //public async Task<IActionResult> UserPasswordReset(string userName)
        //{
        //    var user = await _userManager.FindByNameAsync(userName);

        //    if (user == null)
        //    {
        //        return NotFound(new { message = "User not found." });
        //    }

        //    var result = await _userManager.ChangePasswordAsync(
        //        user,
        //        user.PasswordHash,
        //        "Test@123"
        //    );

        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(new
        //        {
        //            errors = result.Errors.Select(e => e.Description)
        //        });
        //    }

        //    return Ok(new
        //    {
        //        message = "Password reset successfully."
        //    });
        //}

        [Authorize]
        [HttpPatch]
        [Route("ChangePassword")]
        public async Task<IActionResult> UserPasswordChange(
    [FromBody] ChangePasswordRequestDto request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return NotFound(new
                {
                    message = "User not found."
                });
            }

            var result = await _userManager.ChangePasswordAsync(
                user,
                request.CurrentPassword,
                request.NewPassword
            );

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    errors = result.Errors.Select(e => e.Description)
                });
            }

            return Ok(new
            {
                message = "Password changed successfully."
            });
        }

        [Authorize]
        [HttpPatch]
        [Route("GenerateAccessToken")]
        public async Task<IActionResult> GenerateAccessToken(string userName)
        {
            var userExist = await _userManager.FindByNameAsync(userName);

            if (userExist == null)
            {
                return NotFound(new { message = "User Name not exists !!!." });
            }

            

            if (!userExist.IsActive)
            {
                return BadRequest(new
                {
                    message = "User account is in deactive . Please contact IT Team."
                });
            }

            var result = await _tokenService.IsExpireRefreshToken(userExist.Id);

            if (result)
            {
                return NotFound(new { message = "The Refresh token is expired !!!." });
            }

           

            var roles = await _userManager.GetRolesAsync(userExist);

            var tokenResult = await _tokenService
                .GenerateAccessToken(userExist.Id, roles);

            if (!tokenResult.success)
            {
                return BadRequest(new
                {
                    message = "Access token generation failed."
                });
            }

            var expireDate = DateTime.Now.AddHours(10);

            var refreshTokenResult = await _tokenService
                .UpdateRefreshToken(
                    userExist.Id,
                    expireDate,
                    userExist.Id);

            return Ok(new
            {
                accessToken = tokenResult.AccessToken
            });
        }

        //[Authorize]
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users =  _userManager.Users.ToList();

            var result = new List<object>();

            foreach (var user in users)
            {
                var roles = await _userManager
                    .GetRolesAsync(user);

                result.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    user.NickName,
                    Roles = roles
                });
            }

            return Ok(new
            {
                data = result
            });
        }
    }
}