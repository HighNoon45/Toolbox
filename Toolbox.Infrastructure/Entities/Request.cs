using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Infrastructure.Entities
{
    public class Request
    {
        //stream false must be set to send end return json objects
        public int Id { get; set; }
        public string model { get; set; }
        public string prompt { get; set; }
    }
}
