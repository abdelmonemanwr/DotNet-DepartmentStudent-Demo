using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task<TEntity?> GetByIdAsync(int id, string keyPropertyName, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includedProperties = null);

        public Task<TEntity?> GetByIdAsync(int id);

        public Task InsertAsync(TEntity entity);

        public Task UpdateAsync(TEntity entity);

        public Task DeleteAsync(int id);

        public Task<int> SaveAsync();
    }
}