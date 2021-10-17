using System;
using System.Collections.Generic;

namespace IgorMoura.Reminder.Extensions.Exceptions
{
    public class IdentityOperationException : Exception
    {
        public IdentityOperationException() : base("Some errors ocurred while processing the request")
        {
        }

        public readonly string Code = "IdentityOperation";
        public List<IdentityResultError> IdentityResultErrors { get; set; }
    }
}
