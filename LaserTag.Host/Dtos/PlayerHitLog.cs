using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Dtos
{
    public class PlayerHitLog
    {
        public int ShooterId { get; set; }
        public int TargetId { get; set; }
        public int Damage { get; set; }
        public int BulletType { get; set; }
    }
}
