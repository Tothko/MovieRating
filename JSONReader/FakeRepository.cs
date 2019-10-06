using System;
using System.Collections.Generic;
using System.Text;
using MovieRating.Core.Entities.Entities;

namespace MovieRating.Infrastructure.JSONReader
{
    public class FakeRepository : IRepository
    {
        private List<Review> Reviews;

        public FakeRepository()
        {
            Reviews = new List<Review>();
        }
        public void Add(Review review)
        {
            Reviews.Add(review);
        }

        public List<Review> Get()
        {
            return Reviews;
        }
    }
}
