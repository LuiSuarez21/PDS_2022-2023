using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMe.Application.Configurations
{
    public class SMTPSettings
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
