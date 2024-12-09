using LaserTag_API.Core.Data;
using LaserTag_API.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LaserTag_API.Core.Models;

namespace LaserTag_API.Core.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _db;

        public BaseRepository(AppDbContext con)
        {
            _db = con;
        }

        public async Task<T> DeleteAsync(string id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
                await _db.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db.Set<T>();
            if (include != null)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db.Set<T>().Where(filter);
            if (include != null)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            // Check if the entity is of type 'round' and handle related entities
            if (entity is round roundEntity)
            {
                if (roundEntity.match != null)
                {
                    // Attach the existing match to the context so EF knows it's not new
                    var existingMatch = await _db.Matches.FindAsync(roundEntity.match.id);
                    if (existingMatch != null)
                    {
                        roundEntity.match = existingMatch;
                    }
                }
            }

            if (entity is hit_log hitlogEntity)
            {
                if (hitlogEntity.source_player != null)
                {
                    // Attach the existing match to the context so EF knows it's not new
                    var existingPlayer = await _db.Players.FindAsync(hitlogEntity.source_player.id);
                    if (existingPlayer != null)
                    {
                        hitlogEntity.source_player = existingPlayer;
                    }
                }
                if (hitlogEntity.target_player != null)
                {
                    // Attach the existing match to the context so EF knows it's not new
                    var existingPlayer = await _db.Players.FindAsync(hitlogEntity.target_player.id);
                    if (existingPlayer != null)
                    {
                        hitlogEntity.target_player = existingPlayer;
                    }
                }
                if (hitlogEntity.round != null)
                {
                    // Attach the existing match to the context so EF knows it's not new
                    var existingRound = await _db.Rounds.FindAsync(hitlogEntity.round.round_id);
                    if (existingRound != null)
                    {
                        hitlogEntity.round = existingRound;
                    }
                }

            }

            if (entity is shoot_log shootlogEntity)
            {
                if (shootlogEntity.player != null)
                {
                    // Attach the existing match to the context so EF knows it's not new
                    var existingPlayer = await _db.Players.FindAsync(shootlogEntity.player.id);
                    if (existingPlayer != null)
                    {
                        shootlogEntity.player = existingPlayer;
                    }
                }

                if (shootlogEntity.round != null)
                {
                    // Attach the existing match to the context so EF knows it's not new
                    var existingRound = await _db.Rounds.FindAsync(shootlogEntity.round.round_id);
                    if (existingRound != null)
                    {
                        shootlogEntity.round = existingRound;
                    }
                }

            }


            await _db.Set<T>().AddAsync(entity);
            return entity;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
