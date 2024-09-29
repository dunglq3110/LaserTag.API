using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class hit_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string hit_log_id {  get; set; }
        public player? source_player { get; set; }
        public player? target_player { get; set; } 
        public round round { get; set; }
        public shared_base? hit_type { get; set; }
        public int value { get; set; }
    }
}
