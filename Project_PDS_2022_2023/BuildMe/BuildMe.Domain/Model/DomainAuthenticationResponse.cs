using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BuildMe.Domain.Model
{
    public class DomainAuthenticationResponse
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
