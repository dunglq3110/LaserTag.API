using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Helper
{
    public static class StringHelper
    {
        public static bool IsMacAddress(this string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, "^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$");
        }

        
    }
}
