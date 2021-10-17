using System;
using System.Collections.Generic;

namespace IgorMoura.Reminder.Extensions.Exceptions
{
    public class InvalidIdentityOperationException : Exception
    {
        public InvalidIdentityOperationException() : base("Some errors ocurred while processing the request")
        {
        }

        public readonly string Code = "InvalidIdentityOperation";
        public List<IdentityResultError> IdentityResultErrors { get; set; }
    }
}
