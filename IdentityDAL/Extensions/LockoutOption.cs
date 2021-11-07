using System;

namespace IgorMoura.IdentityDAL.Extensions
{
    public class LockoutOption
    {
        public bool AllowedForNewUsers { get; set; }
        public TimeSpan DefaultLockoutTimeSpan { get; set; }
        public int MaxFailedAccessAttempts { get; set; }
    }
}
