using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Repositories
{
    public interface IRepository<T> where T: class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> GetByIdAsync(Guid id);

        public void AddAsync(T entity);

        public void UpdateAsync(T entity);
        public void DeleteAsync(T id);

    }
}
