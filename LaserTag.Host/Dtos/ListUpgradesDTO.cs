using LaserTag.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Dtos
{
    public class ListUpgradesDTO
    {
        public int Credit { get; set; }
        public List<Upgrade> Upgrades { get; set; }  = new List<Upgrade>();
    }
}
