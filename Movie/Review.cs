using System;

namespace MovieRating.Core.Entities.Entities
{
    public class Review
    {

        public int ID { get; set; }
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public double Grade { get; set; }

        public DateTime Date { get; set; }
    }
}
