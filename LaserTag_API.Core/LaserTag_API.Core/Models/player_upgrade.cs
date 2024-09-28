using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class player_upgrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int player_upgrade_id {  get; set; }
        public int player_match_id { get; set; }
        public player_match player_match { get; set; }
        public int upgrade_id { get; set; }
        public upgrade upgrade {  get; set; }
    }
}
