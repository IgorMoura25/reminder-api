using IgorMoura.Util.Models;

namespace IgorMoura.IdentityDAL.DataObjects
{
    public class GetIdentityUserByUserNameRequestModel : DataRequestModel
    {
        public string UserName { get; set; }
    }
}
