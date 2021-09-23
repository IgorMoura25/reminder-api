using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Api.Controllers
{
    //TODO: Retornar um json padrão com status, data, mensagem de erro
    //TODO: Implementar testes de unidade para todas as funcionalidades antes de escalar
    //TODO: Implementar .envs na API e na UTIL antes de escalar
    //TODO: Implementar CI/CD completo
    //TODO: Quebrar AdminController em partials para User, etc...
    //TODO: Retornar erros corretos NoContent, BadRequest, Unauthorized, ServerError, etc

    [ApiController]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        #region Handlers
        private IUserHandler _userHandler { get; }
        #endregion

        #region Constructors
        public AdminController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }
        #endregion

        [HttpPost]
        [Route("user")]
        public async Task<string> AddUserAsync([FromBody] UserEntity user)
        {
            return await _userHandler.AddUserAsync(user);
        }

        [HttpPost]
        [Route("user/confirmation")]
        public async Task<bool> ConfirmUserEmailAsync([FromBody] EmailConfirmationEntity user)
        {
            return await _userHandler.ConfirmUserEmailAsync(user);
        }
    }
}
