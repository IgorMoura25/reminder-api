using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IgorMoura.Util.Data;
using IgorMoura.IdentityDAL.DataObjects;

namespace IgorMoura.IdentityDAL.Stores
{
    public class UserStore : IUserStore<IdentityUser>, IUserEmailStore<IdentityUser>, IUserPasswordStore<IdentityUser>
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
            cancellationToken.ThrowIfCancellationRequested();

            user.UserName = userName;

            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.NormalizedUserName);
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
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                PasswordHash = user.PasswordHash,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            var result = _connector.ExecuteAddProcedure<long>("ISP_RMD_ADD_IdentityUser", requestModel);

            if (result <= 0)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError() { Code = "InternalErrorAddingUser", Description = "An error ocurred while adding the user" }));
            }

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var requestModel = new UpdateIdentityUserByIdRequestModel()
            {
                OperationUserId = Convert.ToInt64(user.Id),
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                PasswordHash = user.PasswordHash,
                EmailConfirmed = user.EmailConfirmed
            };

            var result = _connector.ExecuteUpdateProcedure("ISP_RMD_UPD_IdentityUserById", requestModel);

            if (result <= 0)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError() { Code = "InternalErrorUpdatingUser", Description = "An error ocurred while updating the user" }));
            }

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var requestModel = new DeleteUserByIdRequestModel()
            {
                OperationUserId = Convert.ToInt64(user.Id)
            };

            var result = _connector.ExecuteDeleteProcedure("ISP_RMD_DEL_UserById", requestModel);

            if (result <= 0)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError() { Code = "InternalErrorDeletingUser", Description = "An error ocurred while deleting the user" }));
            }

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var requestModel = new GetIdentityUserByIdRequestModel()
            {
                OperationUserId = Convert.ToInt64(userId)
            };

            var response = _connector.ExecuteGetProcedure<GetIdentityUserByIdResponseModel>("ISP_RMD_GET_IdentityUserById", requestModel);

            IdentityUser identityUser = null;

            if (response != null)
            {
                identityUser = new IdentityUser()
                {
                    Id = response.UserId.ToString(),
                    UserName = response.UserName,
                    Email = response.Email,
                    NormalizedUserName = response.NormalizedUserName,
                    NormalizedEmail = response.NormalizedEmail,
                    PasswordHash = response.PasswordHash,
                    EmailConfirmed = response.EmailConfirmed
                };
            }

            return Task.FromResult(identityUser);
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
                    Id = response.UserId.ToString(),
                    UserName = response.UserName,
                    Email = response.Email,
                    NormalizedUserName = response.NormalizedUserName,
                    NormalizedEmail = response.NormalizedEmail,
                    PasswordHash = response.PasswordHash,
                    EmailConfirmed = response.EmailConfirmed
                };
            }

            return Task.FromResult(identityUser);
        }

        public Task SetEmailAsync(IdentityUser user, string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.Email = email;

            return Task.CompletedTask;
        }

        public Task<string> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.EmailConfirmed = confirmed;

            return Task.CompletedTask;
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
                    Id = response.UserId.ToString()
                };
            }

            return Task.FromResult(identityUser);
        }

        public Task<string> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.NormalizedEmail);
        }

        public Task SetNormalizedEmailAsync(IdentityUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.NormalizedEmail = normalizedEmail.ToUpper();

            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.PasswordHash = passwordHash;

            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash) && !string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public void Dispose()
        {
        }
    }
}
