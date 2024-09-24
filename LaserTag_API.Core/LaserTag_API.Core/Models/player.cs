using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string mac_gun { get; set; }
        public string mac_vest { get; set; }
        public int current_health { get; set; }
        public int current_bullet { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal balance { get; set; }
    }
}
