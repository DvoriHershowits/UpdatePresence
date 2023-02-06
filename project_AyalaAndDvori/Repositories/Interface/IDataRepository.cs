using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IDataRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetDataByIdAsync(int id);
        Task<T> AddDataAsync(T entity);
        Task<T> UpdateDataAsync(T entity);
        Task DeleteDataAsync(int id);
    }
}
