using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class round
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string round_id { get; set; }
        public DateTime date { get; set; }
        public shared_base? round_stage { get; set; }
        public match match { get; set; }
    }
}
