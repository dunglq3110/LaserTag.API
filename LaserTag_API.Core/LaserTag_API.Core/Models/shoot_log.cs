using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class shoot_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shoot_log_id { get; set; }
        public int player_id { get; set; }
        public player player { get; set; }
        public int round_id { get; set; }
        public round round { get; set; }
        public DateTime date { get; set; }
    }
}
