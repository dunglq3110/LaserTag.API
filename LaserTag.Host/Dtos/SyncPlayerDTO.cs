using LaserTag.Host.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Dtos
{
    public class SyncPlayerDTO
    {
        public string Name { get; set; } = "";
        public string MacGun { get; set; } = "";
        public string MacVest { get; set; } = "";
        public int CurrentHealth { get; set; }
        public int CurrentBullet { get; set; }
        public int CurrentSSketch { get; set; }
        public int CurrentArmor { get; set; }

        public SyncPlayerDTO()
        {

        }
        public SyncPlayerDTO(Player player)
        {
            Name = player.Name;
            MacGun = player.MacGun;
            MacVest = player.MacVest;
            CurrentHealth = player.CurrentHealth;
            CurrentBullet = player.CurrentBullet;
            CurrentSSketch = player.CurrentSSketchBullet;
            CurrentArmor = player.CurrentArmor;
        }
    }
}
