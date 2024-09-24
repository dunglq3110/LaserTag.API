using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class config
    {
        public int? config_id { get; set; }
        public string name { get; set; }
        public string code_name { get; set; }
        public string config_type_id { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public string value4 { get; set; }
        public string value5 { get; set; }
        public string description { get; set; }

    }
}
