using LaserTag_API.Core.Data;
using LaserTag_API.Core.Interfaces;
using LaserTag_API.Core.Interfaces.IRepositories;
using LaserTag_API.Core.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IPlayerRepository _playerRepository;
        private readonly IAttributeRepository _attributeRepository;
        private readonly IConfigRepository _configRepository;
        private readonly IHitLogRepository _hitLogRepository;
        private readonly IShootLogRepository _shootLogRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly ISharedGroupRepository _sharedGroupRepository;
        private readonly ISharedBaseRepository _sharedBaseRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IPlayerRepository PlayerRepository => _playerRepository  ?? new PlayerRepository(_appDbContext);
        public IAttributeRepository AttributeRepository => _attributeRepository ?? new AttributeRepository(_appDbContext);
        public IConfigRepository ConfigRepository => _configRepository ?? new ConfigRepository(_appDbContext);
        public IHitLogRepository HitLogRepository => _hitLogRepository ?? new HitLogRepository(_appDbContext);
        public IShootLogRepository ShootLogRepository => _shootLogRepository ?? new ShootLogRepository(_appDbContext);
        public IRoundRepository RoundRepository => _roundRepository ?? new RoundRepository(_appDbContext);
        public IMatchRepository MatchRepository => _matchRepository ?? new MatchRepository(_appDbContext);
        public ISharedBaseRepository SharedBaseRepository => _sharedBaseRepository ?? new SharedBaseRepository(_appDbContext);
        public ISharedGroupRepository SharedGroupRepository => _sharedGroupRepository ?? new SharedGroupRepository(_appDbContext);

        public void SaveChangesLasertag()
        {
            _appDbContext.SaveChanges();
        }

        public async Task SaveChangesAsyncLasertag()
        {
            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            //DbUpdateConcurrencyException
            catch (DbUpdateException ex)
            {
                var message = ex.Message;
                var a = 1;
            }
        }
        protected virtual void Dispose(bool disposing)
        {

        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~UnitOfWork()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            //Do not change this code.Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
