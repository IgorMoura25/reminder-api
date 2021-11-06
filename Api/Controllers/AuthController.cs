using System;
using System.Net;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using IgorMoura.Reminder.Api.Utilities;
using IgorMoura.Reminder.Models.DataObjects.Auth;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.Api.Configuration;

namespace IgorMoura.Reminder.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        #region Handlers
        private IAuthHandler _authHandler { get; }
        private IApiConfiguration _apiConfiguration { get; }
        #endregion

        #region Constructors
        public AuthController(IAuthHandler authHandler, IApiConfiguration apiConfiguration)
        {
            _authHandler = authHandler;
            _apiConfiguration = apiConfiguration;
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

            var result = new ApiResult<string>(HttpStatusCode.OK, token);

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
                new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_apiConfiguration.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Reminder.Api",
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(30)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
