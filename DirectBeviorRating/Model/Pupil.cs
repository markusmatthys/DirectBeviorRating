using System;
using SQLite;

namespace DirectBeviorRating.Model
{
    public class Pupil
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
