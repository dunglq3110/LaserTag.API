﻿using LaserTag_API.Core.Interfaces.IRepositories;
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
        IHitLogRepository HitLogRepository { get; }
        IShootLogRepository ShootLogRepository { get; }
        IRoundRepository RoundRepository { get; }
        ISharedBaseRepository SharedBaseRepository { get; }
        ISharedGroupRepository SharedGroupRepository { get; }

        IMatchRepository MatchRepository { get; }
        void SaveChangesLasertag();
        Task SaveChangesAsyncLasertag();
    }
}
