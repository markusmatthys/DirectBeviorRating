using System;
using System.Threading.Tasks;
using SQLite;
using DirectBeviorRating.Model;
using System.Collections.Generic;

namespace DirectBeviorRating.Data
{
    public class PupilDatabase
    {
        readonly SQLiteAsyncConnection pupilDatabase;

        public PupilDatabase(string dbPath)
        {
            pupilDatabase = new SQLiteAsyncConnection(dbPath);
            pupilDatabase.CreateTableAsync<Pupil>().Wait();
        }

        public Task<List<Pupil>> GetPupilsAsync()
        {
            //Get all pupils.
            return pupilDatabase.Table<Pupil>().ToListAsync();
        }

        public Task<Pupil> GetPupilAsync(int id)
        {
            // Get a specific pupil.
            AsyncTableQuery<Pupil> asyncTableQuery = pupilDatabase.Table<Pupil>();
            return asyncTableQuery
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePupilAsync(Pupil pupil)
        {
            if (pupil.ID != 0)
            {
                // Update an existing pupil.
                return pupilDatabase.UpdateAsync(pupil);
            }
            else
            {
                // Save a new pupil.
                return pupilDatabase.InsertAsync(pupil);
            }
        }

        public Task<int> DeletePupilAsync(Pupil pupil)
        {
            // Delete a pupil.
            return pupilDatabase.DeleteAsync(pupil);
        }
    }
}
