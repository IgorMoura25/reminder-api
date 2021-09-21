using IgorMoura.Util.Models;

namespace IgorMoura.IdentityDAL.DataObjects
{
    public class GetIdentityUserByNormalizedEmailRequestModel : GetDataRequestModel
    {
        public string NormalizedEmail { get; set; }
    }
}
