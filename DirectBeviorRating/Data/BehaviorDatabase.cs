using System;
using System.Threading.Tasks;
using SQLite;
using DirectBeviorRating.Model;
using System.Collections.Generic;

namespace DirectBeviorRating.Data
{
    public class BehaviorDatabase
    {
        readonly SQLiteAsyncConnection database;

        public BehaviorDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Pupil>().Wait();
        }

        public Task<List<Pupil>> GetPupilsAsync()
        {
            //Get all pupils.
            return database.Table<Pupil>().ToListAsync();
        }

        public Task<Pupil> GetPupilAsync(int id)
        {
            // Get a specific pupil.
            return database.Table<Pupil>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePupilAsync(Pupil pupil)
        {
            if (pupil.ID != 0)
            {
                // Update an existing pupil.
                return database.UpdateAsync(pupil);
            }
            else
            {
                // Save a new pupil.
                return database.InsertAsync(pupil);
            }
        }

        public Task<int> DeletePupilAsync(Pupil pupil)
        {
            // Delete a pupil.
            return database.DeleteAsync(pupil);
        }
    }
}
