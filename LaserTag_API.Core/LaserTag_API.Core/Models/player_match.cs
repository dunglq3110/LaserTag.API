using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class player_match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int player_match_id {  get; set; }
        public int player_id { get; set; }
        public player player { get; set; }
        public int match_id { get; set; }
        public match match { get; set; }
        public int team_id { get; set; }
    }
}
