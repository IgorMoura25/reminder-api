using Microsoft.AspNet.Identity;

namespace IgorMoura.IdentityDAL.Entities
{
    public class IdentityUser : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
