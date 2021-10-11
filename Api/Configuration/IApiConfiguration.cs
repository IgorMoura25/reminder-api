using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgorMoura.Reminder.Api.Configuration
{
    public interface IApiConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
