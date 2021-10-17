using IgorMoura.Util.Models;

namespace IgorMoura.IdentityDAL.DataObjects
{
    public class GetIdentityUserByIdRequestModel : GetDataRequestModel
    {
        public long OperationUserId { get; set; }
    }
}
