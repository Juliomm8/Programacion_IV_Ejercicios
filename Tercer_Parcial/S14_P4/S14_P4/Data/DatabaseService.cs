using S14_P4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S14_P4.Data
{
    public class DatabaseService
    {
        public readonly SQLiteAsyncConnection _db;
        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Medicamento>().Wait();
        }
        public Task<List<Medicamento>> GetMedicamentosAsync() =>
            _db.Table<Medicamento>().ToListAsync();

        public Task<int> SaveMedicamentosAsync(Medicamento med) =>
            med.Id != 0 ? _db.UpdateAsync(med) : _db.InsertAsync(med);

        public Task<int> DeleteMedicamentoAsync(Medicamento med)=>
            _db.DeleteAsync(med);

    }
}
