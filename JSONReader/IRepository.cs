using MovieRating.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Infrastructure.JSONReader
{
    interface IRepository

    {
        void Add(Review review);
        List<Review> Get();



    }
}
