using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Infrastructure.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Prompt { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public Chat Chat { get; set; }
    }
}
