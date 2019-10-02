using MovieRating.Core.Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MovieRating.Infrastructure.JSONReader

{
    public class ReviewRepository

    {
        private readonly string JsonPath = @"/../../ratings.json";
        public List<Review> LoadReviews()
        {
            List<Review> Reviews = new List<Review>();
            
                using (StreamReader r = new StreamReader(JsonPath))
                {
                    string json = r.ReadToEnd();
                    Reviews = JsonConvert.DeserializeObject<List<Review>>(json);
                }
            
            return Reviews;
        }
    }
}
