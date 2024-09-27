using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class hit_log
    {
        public int? hit_log_id {  get; set; }
        public int? source_player_id { get; set; }
        public int? target_player_id { get; set; } 
        public int? round_id { get; set; }
        public string hit_type_id { get; set; }
        public int? value { get; set; }
    }
}
