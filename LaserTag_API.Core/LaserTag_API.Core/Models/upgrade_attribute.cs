using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class upgrade_attribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int upgrade_id { get; set; }
        public upgrade upgrade { get; set; }
        public int attribute_id { get; set; }
        public attribute attribute { get; set; }
        public int value { get; set; }
    }
}
