﻿using IgorMoura.Util.Models;

namespace IgorMoura.IdentityDAL.DataObjects
{
    public class AddIdentityUserRequestModel : AddDataRequestModel
    {
        public string OperationUserId { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
    }
}
