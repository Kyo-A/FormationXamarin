using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FormationXamForms.Services.SQLite
{
    public interface IDao<T>
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetItemById(int id);
        Task AddItem(T t);
        Task UpdateItem(T t);
        Task DeleteItem(T t);
    }
}
