using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Infrastructure.Entities
{
    public class Response
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ResponseText { get; set; }
        public bool Done { get; set; }
        public string Context { get; set; }
        public long TotalDuration { get; set; }
        public int PromptEvalCount { get; set; }
        public long PromptEvalDuration { get; set; }
        public int EvalCount { get; set; }
        public long EvalDuration { get; set; }

        // Navigation property
        public Chat Chat { get; set; }
    }
}
