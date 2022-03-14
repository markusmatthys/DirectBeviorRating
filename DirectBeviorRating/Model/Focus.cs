using System;
using SQLite;

namespace DirectBeviorRating.Model
{
    public class Focus
    {

        public Focus ()
        {

        }

        public Focus(string pupilIdAsString)
        {
            PupilId = Convert.ToInt32(pupilIdAsString);
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int PupilId { get; set; }
        public string SpecificFocus { get; set; }
        public DateTime Date { get; set; }
        //public string PupilIdAsString { get; }
    }
}