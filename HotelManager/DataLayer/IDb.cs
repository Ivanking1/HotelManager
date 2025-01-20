using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDb<T, K>
    {
        Task CreateAsync(T entity);
        Task<T> ReadAsync(K key);
        Task<ICollection<T>> ReadAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(K key);
    }
}
