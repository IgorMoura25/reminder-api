using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using IgorMoura.Reminder.Auth.Configuration;
using IgorMoura.Reminder.Auth.Utilities;
using IgorMoura.Reminder.Models.DataObjects.Auth;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace IgorMoura.Reminder.Auth.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        #region Handlers
        private IAuthHandler _authHandler { get; }
        private IAuthConfiguration _authConfiguration { get; }
        #endregion

        #region Constructors
        public AuthController(IAuthHandler authHandler, IAuthConfiguration authConfiguration)
        {
            _authHandler = authHandler;
            _authConfiguration = authConfiguration;
        }
        #endregion

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AuthorizeAsync([FromBody] AuthorizeApiRequestModel model)
        {
            var response = await _authHandler.SignInAsync(new SignInEntity()
            {
                UserName = model.UserName,
                Password = model.Password
            });

            if (!response.Succeeded)
            {
                var errors = ErrorHandler.HandleAuthorizationErrors<string>(response.Result);

                return StatusCode((int)errors.StatusCode, errors);
            }

            var token = GenerateToken(model);

            var result = new AuthResult<string>(HttpStatusCode.OK, token);

            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost]
        [Route("password-redefinition-token")]
        public async Task<IActionResult> GeneratePasswordRedefinitionTokenAsync([FromBody] GeneratePasswordRedefinitionTokenApiRequestModel model)
        {
            var response = await _authHandler.GeneratePasswordRedefinitionTokenAsync(new PasswordRedefinitionTokenEntity()
            {
                Email = model.Email
            });

            if (!response.Succeeded)
            {
                var errors = ErrorHandler.HandleAuthorizationErrors<string>(response.Result);

                return StatusCode((int)errors.StatusCode, errors);
            }

            var result = new AuthResult<bool>(HttpStatusCode.OK, true);

            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordEntity model)
        {
            var response = await _authHandler.ResetPasswordAsync(model);

            if (!response.Succeeded)
            {
                var errors = ErrorHandler.HandleAuthorizationErrors<bool>(response.Result);

                return StatusCode((int)errors.StatusCode, errors);
            }

            var result = new AuthResult<bool>(HttpStatusCode.OK, response.Data);

            return StatusCode((int)result.StatusCode, result);
        }

        private string GenerateToken(AuthorizeApiRequestModel model)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_authConfiguration.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Reminder.Auth",
                audience: "Reminder.Api",
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(30)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
