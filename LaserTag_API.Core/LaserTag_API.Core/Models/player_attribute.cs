using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class player_attribute
    {
        public int? id {  get; set; }
        public int? player_id { get; set; }
        public int? attribute_id { get; set; }
        public string value { get; set; }    
    }
}
