using MovieRating.Core.Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MovieRating.Infrastructure.JSONReader

{
    public class ReviewRepository : IRepository

    {
        List<Review> Reviews;
        public ReviewRepository()
            :this(@"/../../ratings.json")
        {

        }

        public ReviewRepository(String jsonPath)
        {
            JsonPath = jsonPath;
            Reviews = new List<Review>();
            LoadJason();
        }

        private readonly string JsonPath;

        public void Add(Review review)
        {
            Reviews.Add(review);
        }

        public List<Review> Get()
        {
            return Reviews;
        }

        private void LoadJason()
        {
            
            
                using (StreamReader r = new StreamReader(JsonPath))
                {
                    string json = r.ReadToEnd();
                    Reviews = JsonConvert.DeserializeObject<List<Review>>(json);
                }
            
            
        }
    }
}
