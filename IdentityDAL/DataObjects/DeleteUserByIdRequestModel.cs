using IgorMoura.Util.Models;

namespace IgorMoura.IdentityDAL.DataObjects
{
    public class DeleteUserByIdRequestModel : DeleteDataRequestModel
    {
        public long OperationUserId { get; set; }
    }
}
