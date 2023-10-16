using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMe.Application.Configurations
{
    public interface IApplicationSettings
    {
        public SQLSettings SQLSettings { get; set; }
        public SMTPSettings SMTPSettings { get; set; }
    }
}
