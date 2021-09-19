using IgorMoura.Util.Models;

namespace IgorMoura.IdentityDAL.DataObjects
{
    public class AddIdentityUserRequestModel : AddDataRequestModel
    {
        public string OperationUserId { get; set; }
        public string UserName { get; set; }
    }
}
