using Microsoft.AspNet.Identity;

namespace IdentityDAL.Entities
{
    public class IdentityUser : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
