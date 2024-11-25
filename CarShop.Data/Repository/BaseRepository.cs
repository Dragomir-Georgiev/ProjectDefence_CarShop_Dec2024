using CarShop.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Repository
{
    public class BaseRepository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TType> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TType>();
        }

        public TType GetById(TId id)
        {
            TType entity = _dbSet
                .Find(id);

            return entity;
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            TType entity = await _dbSet
                .FindAsync(id);

            return entity;
        }

        public TType FirstOrDefault(Func<TType, bool> predicate)
        {
            TType entity = _dbSet
                .FirstOrDefault(predicate);

            return entity;
        }

        public async Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate)
        {
            TType entity = await _dbSet
                .FirstOrDefaultAsync(predicate);

            return entity;
        }

        public IEnumerable<TType> GetAll()
        {
            return _dbSet.ToArray();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await _dbSet.ToArrayAsync();
        }

        public IQueryable<TType> GetAllAttached()
        {
            return _dbSet.AsQueryable();
        }

        public void Add(TType item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(TType item)
        {
            await _dbSet.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public void AddRange(TType[] items)
        {
            _dbSet.AddRange(items);
            _dbContext.SaveChanges();
        }

        public async Task AddRangeAsync(TType[] items)
        {
            await _dbSet.AddRangeAsync(items);
            await _dbContext.SaveChangesAsync();
        }

        public bool Delete(TType entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TType entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public bool Update(TType item)
        {
            try
            {
                _dbSet.Attach(item);
                _dbContext.Entry(item).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TType item)
        {
            try
            {
                _dbSet.Attach(item);
                _dbContext.Entry(item).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
