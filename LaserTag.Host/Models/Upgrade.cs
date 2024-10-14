using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Models
{
    public class Upgrade
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Cost { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<UpgradeAttribute> Attributes { get; set; } = new List<UpgradeAttribute>();  
    }
}
