using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Models
{
    public class ShootLog
    {
        public int Id { get; set; }
        public Player Shooter { get; set; }
        public Round Round { get; set; }
        public DateTime Time { get; set; }
    }
}
