using IgorMoura.Util.Models;

namespace IgorMoura.IdentityDAL.DataObjects
{
    public class GetIdentityUserByNormalizedUserNameRequestModel : GetDataRequestModel
    {
        public string NormalizedUserName { get; set; }
    }
}
