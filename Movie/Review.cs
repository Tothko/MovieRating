using System;

namespace MovieRating.Core.Entities.Entities
{
    public class Review
    {
        public Review(int Reviewer, int Movie, double Grade, DateTime Date)
        {
            this.Reviewer = Reviewer;
            this.Movie = Movie;
            this.Grade = Grade;
            this.Date = Date;
        }
        public int ID { get; set; }
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public double Grade { get; set; }

        public DateTime Date { get; set; }
    }
}
