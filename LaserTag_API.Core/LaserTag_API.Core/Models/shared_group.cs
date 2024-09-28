using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class shared_group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string group_id { get; set; }
        public string group_name1 { get; set; }    
        public string group_name2 { get; set; }
        public string group_name3 { get; set; }
        public string group_name4 { get; set; }
        public string group_name5 { get; set; }
        public string description { get; set; }
    }
}
