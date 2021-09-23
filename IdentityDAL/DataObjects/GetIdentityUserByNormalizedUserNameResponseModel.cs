namespace IgorMoura.IdentityDAL.DataObjects
{
    public class GetIdentityUserByNormalizedUserNameResponseModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public bool IsActive { get; set; }
        public string PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
