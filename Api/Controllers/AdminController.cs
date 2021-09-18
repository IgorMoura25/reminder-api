using Microsoft.AspNetCore.Mvc;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Api.Controllers
{
    //TODO: Retornar um json padrão com status, data, mensagem de erro
    //TODO: Implementar testes de unidade para todas as funcionalidades antes de escalar
    //TODO: Implementar .envs na API e na UTIL antes de escalar
    //TODO: Implementar CI/CD completo
    [ApiController]
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
        [Route("admin/user")]
        public long AddUser([FromBody] UserEntity user)
        {
            return _userHandler.AddUser(user);
        }
    }
}
