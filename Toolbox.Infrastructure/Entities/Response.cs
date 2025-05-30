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
        public string model { get; set; }
        public string created_at { get; set; }
        public string response { get; set; }
        public string done { get; set; }
        public string context { get; set; }
        public string total_duration { get; set; }
        public string prompt_eval_count { get; set; }
        public string prompt_eval_duration { get; set; }
        public string eval_count { get; set; }
        public string eval_duration { get; set; }
    }
}
