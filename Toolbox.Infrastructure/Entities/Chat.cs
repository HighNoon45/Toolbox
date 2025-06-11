using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Infrastructure.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int ResponseId { get; set; }
        public Response Response { get; set; }
    }
}
