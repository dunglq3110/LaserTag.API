using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Models
{
    public class HitLog
    {
        public int Id { get; set; }
        public Player Shooter { get; set; }
        public Player Target { get; set; }
        public Round Round { get; set; }
        public HitType HitType { get; set; } 
        public int Damage { get; set; }
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return $"Shooter: {Shooter.Name}, Target: {Target.Name}, Damage: {Damage}, Time: {Time}"
        }
    }

    public enum HitType
    {
        Normal = 0,
        Healing = 1,
        SSketch = 2,
    }

   
}
