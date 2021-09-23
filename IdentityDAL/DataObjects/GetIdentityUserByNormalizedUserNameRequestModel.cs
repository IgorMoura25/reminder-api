using IgorMoura.Util.Models;

namespace IgorMoura.IdentityDAL.DataObjects
{
    public class GetIdentityUserByNormalizedUserNameRequestModel : DataRequestModel
    {
        public string NormalizedUserName { get; set; }
    }
}
