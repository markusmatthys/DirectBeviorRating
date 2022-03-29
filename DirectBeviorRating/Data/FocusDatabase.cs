using System;
using SQLite;
using DirectBeviorRating.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DirectBeviorRating.Data
{
    public class FocusDatabase
    {
        readonly SQLiteAsyncConnection focusDatabase;

        public FocusDatabase(string dbPath)
        {
            focusDatabase = new SQLiteAsyncConnection(dbPath);
            focusDatabase.CreateTableAsync<Focus>().Wait();
        }
        
        public async Task<List<Focus>> GetFocusesAsync(int pupilId)
        {
            //Get all Focus from a specific pupil.
            string pupilIdAsString = pupilId.ToString();
            
            //var listFocus = new { listFocus = new List<Focus> () };
            //List<Focus> allFoci = await focusDatabase.Table<Focus>().ToListAsync();


            //return focusDatabase.QueryAsync<Focus>("SELECT * FROM [Focus] = pupilIdAsString");
            return await focusDatabase.Table<Focus>().Where(i => i.PupilId == pupilId).ToListAsync();
            //return focusDatabase.Table<Focus>().Where(i => i.PupilId == pupilId);
            //return await focusDatabase.Table<Focus>().ToListAsync();
            //return await focusDatabase.Table<Focus>().ToListAsync();
        }



        public Task<int> SaveFocusAsync(Focus focus)
        {
            if (focus.ID != 0)
            {
                // Update an existing focus.
                return focusDatabase.UpdateAsync(focus);
            }
            else
            {
                // Save a new focus.
                return focusDatabase.InsertAsync(focus);
            }
        }
    }
}
