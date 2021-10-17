using System;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using IgorMoura.Reminder.Api.Utilities;

namespace IgorMoura.Reminder.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        #region Handlers
        #endregion

        #region Constructors
        #endregion

        [HttpPost]
        public IActionResult Authorize()
        {
            //TODO Usar o Identity para autenticação, para saber se pode criar o token ou não

            try
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, "userName"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("token-maior-que-256-bits-guid"));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Reminder.Api",
                    audience: "Postman",
                    claims: claims,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddMinutes(30)
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                var result = new ApiResult<string>(HttpStatusCode.OK, tokenString);

                return StatusCode((int)result.StatusCode, result);


            }
            catch (Exception ex)
            {
                var result = ExceptionHandler.HandleAuthorizationErrors<string>(ex);

                return StatusCode((int)result.StatusCode, result);
            }
        }
    }
}
