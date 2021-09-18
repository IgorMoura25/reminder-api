using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using IgorMoura.Util.Data;
using IgorMoura.IdentityDAL.Entities;
using IgorMoura.IdentityDAL.DataObjects;

namespace IgorMoura.IdentityDAL.Stores
{
    //TODO: Aplicar Liskov Principle -> Implementar toda a interface sem exceções
    public class UserStore : IUserStore<IdentityUser, string>
    {
        private IDbConnector _connector { get; }

        public UserStore(IDbConnector dbConnector)
        {
            _connector = dbConnector;
        }

        public Task CreateAsync(IdentityUser user)
        {
            var requestModel = new AddIdentityUserRequestModel()
            {
                Name = user.UserName
            };

            var result = _connector.ExecuteAddProcedure<long>("ISP_RMD_ADD_IdentityUser", requestModel);

            return Task.FromResult(result);
        }

        public Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            var requestModel = new GetIdentityUserByUserNameRequestModel()
            {
                UserName = userName
            };

            var response = _connector.ExecuteGetProcedure<GetIdentityUserByUserNameResponseModel>("ISP_RMD_GET_IdentityUserByUserName", requestModel);

            IdentityUser user = null;

            if (response != null)
            {
                user = new IdentityUser()
                {
                    Id = response.UserId.ToString(),
                    UserName = response.UserName
                };
            }

            return Task.FromResult(user);
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
