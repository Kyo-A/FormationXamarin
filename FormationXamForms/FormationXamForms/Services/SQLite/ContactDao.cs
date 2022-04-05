using FormationXamForms.Models;
using FormationXamForms.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FormationXamForms.Services.SQLite
{
    public class ContactDao : IDao<ContactModel>
    {
        private SQLiteAsyncConnection _connection;

        public ContactDao(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<ContactModel>();
        }
        public Task AddItem(ContactModel t)
        {
            return _connection.InsertAsync(t);
        }

        public Task DeleteItem(ContactModel t)
        {
            return _connection.DeleteAsync(t);
        }

        public Task<ContactModel> GetItemById(int id)
        {
            return _connection.FindAsync<ContactModel>(id);
        }

        public async Task<IEnumerable<ContactModel>> GetListAsync()
        {
            return await _connection.Table<ContactModel>().ToListAsync();
        }

        public Task UpdateItem(ContactModel t)
        {
            return _connection.UpdateAsync(t);
        }
    }
}
