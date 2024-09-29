using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class upgrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }
    }
}
