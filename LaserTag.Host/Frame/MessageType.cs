using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Frame
{
    public enum MessageType
    {
        Request = 0,
        Response = 1,
        Success = 2,
        Error = 3,
        Info = 4,
        Log = 5 
    }
}
