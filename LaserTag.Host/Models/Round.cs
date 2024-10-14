using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Models
{
    public class Round
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public SharedBase Stage { get; set; } = new SharedBase();

        public Round() 
        {
            StartTime = DateTime.Now;
        }

    }
}
