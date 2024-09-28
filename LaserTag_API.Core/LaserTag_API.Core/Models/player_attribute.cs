using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class player_attribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {  get; set; }
        public int player_id { get; set; }
        public player player { get; set; }
        public int attribute_id { get; set; }
        public attribute attribute { get; set; }
        public string value { get; set; }    
    }
}
