using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class attribute
    {
        public int? id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code_name { get; set; }
        public bool is_gun {  get; set; }
    }
}
