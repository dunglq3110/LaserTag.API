using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MacGun { get; set; } = string.Empty;
        public string MacVest { get; set; } = string.Empty;
        public int CurrentHealth { get; set; }
        public int CurrentBullet { get; set; }
        public int Credit { get; set; } = 1000;

        // A player can have multiple attributes
        public List<PlayerAttribute> PlayerAttributes { get; set; } = new List<PlayerAttribute>();

        // Add an attribute to the player
        public void AddAttribute(GameAttribute attribute, int value)
        {
            PlayerAttributes.Add(new PlayerAttribute
            {
                Player = this,
                GameAttribute = attribute,
                Value = value
            });
        }

        // Get the value of a specific attribute by its code name
        public int? GetAttributeValue(string codeName)
        {
            var attr = PlayerAttributes.FirstOrDefault(pa => pa.GameAttribute.CodeName == codeName);
            return attr?.Value;
        }

        // Update the value of a specific attribute
        public void SetAttributeValue(string codeName, int newValue)
        {
            var attr = PlayerAttributes.FirstOrDefault(pa => pa.GameAttribute.CodeName == codeName);
            if (attr != null)
            {
                attr.Value = newValue;
            }
        }

        // Get all attributes with their values
        public List<PlayerAttribute> GetAllAttributes()
        {
            return PlayerAttributes;
        }
    }

}
