using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormationXamForms.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
