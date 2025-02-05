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
        Task<T> ReadAsync(K key, bool NavigationalProperties = false, bool isReadOnly = true);
        Task<ICollection<T>> ReadAllAsync(bool NavigationalProperties = false, bool isReadOnly = true);
        Task UpdateAsync(T entity, bool NavigationalProperties = false);
        Task DeleteAsync(K key);
    }
}
