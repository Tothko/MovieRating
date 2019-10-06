using MovieRating.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Infrastructure.JSONReader
{
    public interface IRepository

    {
        void Add(Review review);
        List<Review> Get();



    }
}
