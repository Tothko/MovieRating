using System;

namespace MovieRating.Core.Entities.Entities
{
    public class Movie
    {
        public int ID { get; set; }
        public double Grade { get; set; }
        public int NumberOfReviews { get; set; }
        public string Name { get; set; }
    }
}
