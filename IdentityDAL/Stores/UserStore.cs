using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using IgorMoura.Util.Data;
using IdentityDAL.Entities;
using IdentityDAL.DataObjects;

namespace IdentityDAL.Stores
{
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
                UserId = Convert.ToInt64(user.Id),
                Name = user.UserName
            };

            _connector.ExecuteAddProcedure<long>("ISP_RMD_ADD_IdentityUser", requestModel);

            return Task.FromResult(IdentityResult.Success);
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
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
