using System;
using SQLite;

namespace DirectBeviorRating.Model
{
    public class Focus
    {
        public Focus ()
        {

        }

        public Focus(int pupilIdAsInt)
        {
            PupilId = pupilIdAsInt;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int PupilId { get; set; }
        public string SpecificFocus { get; set; }
        public DateTime Date { get; set; }
    }
}