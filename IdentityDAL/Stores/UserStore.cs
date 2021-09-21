using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IgorMoura.Util.Data;
using IgorMoura.IdentityDAL.DataObjects;
using System.Threading;

namespace IgorMoura.IdentityDAL.Stores
{
    //TODO: Aplicar Liskov Principle -> Implementar toda a interface sem exceções
    public class UserStore : IUserStore<IdentityUser>, IUserEmailStore<IdentityUser>
    {
        private IDbConnector _connector { get; }

        public UserStore(IDbConnector dbConnector)
        {
            _connector = dbConnector;
        }

        public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.UserName);
        }

        public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.NormalizedUserName = normalizedName.ToUpper();

            return Task.CompletedTask;
        }

        public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var requestModel = new AddIdentityUserRequestModel()
            {
                OperationUserId = user.Id,
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail
            };

            var result = _connector.ExecuteAddProcedure<string>("ISP_RMD_ADD_IdentityUser", requestModel);

            //TODO: Tratar erro corretamente

            return Task.FromResult(IdentityResult.Success);

        }

        public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var requestModel = new GetIdentityUserByNormalizedUserNameRequestModel()
            {
                NormalizedUserName = normalizedUserName
            };

            var response = _connector.ExecuteGetProcedure<GetIdentityUserByNormalizedUserNameResponseModel>("ISP_RMD_GET_IdentityUserByNormalizedUserName", requestModel);

            IdentityUser identityUser = null;

            if (response != null)
            {
                identityUser = new IdentityUser()
                {
                    Id = response.UserId,
                    UserName = response.UserName
                };
            }

            return Task.FromResult(identityUser);
        }

        public void Dispose()
        {
        }

        public Task SetEmailAsync(IdentityUser user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var requestModel = new GetIdentityUserByNormalizedEmailRequestModel()
            {
                NormalizedEmail = normalizedEmail
            };

            var response = _connector.ExecuteGetProcedure<GetIdentityUserByNormalizedEmailResponseModel>("ISP_RMD_GET_IdentityUserByNormalizedEmail", requestModel);

            IdentityUser identityUser = null;

            if (response != null)
            {
                identityUser = new IdentityUser()
                {
                    Id = response.UserId
                };
            }

            return Task.FromResult(identityUser);
        }

        public Task<string> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(IdentityUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.NormalizedEmail = normalizedEmail.ToUpper();

            return Task.CompletedTask;
        }
    }
}
