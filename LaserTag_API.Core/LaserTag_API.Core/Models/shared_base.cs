using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Models
{
    public class shared_base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string base_id { get; set; }
        public string group_id { get; set; }
        public shared_group shared_Group { get; set; }
        public string base_name1 { get; set; }
        public string base_name2 { get; set; }
        public string base_name3 { get; set; }
        public string base_name4 { get; set; }
        public string base_name5 { get; set; }
        public int sort {  get; set; }
        public string description { get; set; }
    }
}
