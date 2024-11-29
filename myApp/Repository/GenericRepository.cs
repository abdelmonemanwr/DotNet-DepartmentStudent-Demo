using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myApp.Models;

namespace myApp.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private ITIContext dbContext { get; }
        public GenericRepository(ITIContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }


        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetByIdAsync(int id, string keyPropertyName, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includedProperties = null)
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>();
            if (includedProperties != null)
                query = includedProperties(query);

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, keyPropertyName) == id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task AttachAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            TEntity? entity = await dbContext.Set<TEntity>().FindAsync(id);
            dbContext.Set<TEntity>().Remove(entity!);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

    }
}