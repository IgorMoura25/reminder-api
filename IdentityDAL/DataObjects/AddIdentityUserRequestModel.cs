using System;
using IgorMoura.Util.Models;

namespace IgorMoura.IdentityDAL.DataObjects
{
    public class AddIdentityUserRequestModel : AddDataRequestModel
    {
        public Guid? OperationUserId { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
