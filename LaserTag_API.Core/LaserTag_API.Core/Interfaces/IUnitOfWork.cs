using LaserTag_API.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository PlayerRepository { get; }
        IAttributeRepository AttributeRepository { get; }
        IConfigRepository ConfigRepository { get; }




        void SaveChangesLasertag();
        Task SaveChangesAsyncLasertag();
    }
}
