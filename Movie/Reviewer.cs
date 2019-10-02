using System;

namespace MovieRating.Core.Entities.Entities
{
    public class Reviewer

    {
        public int ID { get; set; }
        public int NumberOfReviews { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
    }
}
