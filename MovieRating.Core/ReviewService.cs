using MovieRating.Core.Entities.Entities;
using MovieRating.Infrastructure.JSONReader;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRating.Core.MovieRating.Core

{
    public class ReviewService
    {

        ReviewRepository Repo;
        List<Review> Reviews;
        public int CountOfUserReviews(int x)
        {
            int ReviewCount = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Reviewer == x)
                {
                    ReviewCount++;
                }

            }
            return ReviewCount;
        }

        public double AvarageReviewOfUser(int x)
        {
            int ReviewCount = 0;
            double TotalReviewValue = 0;
            double AvarageReviewValue = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Reviewer == x)
                {
                    TotalReviewValue += Review.Grade;
                    ReviewCount++;
                }

            }
            if (AvarageReviewValue != 0 && ReviewCount != 0) AvarageReviewValue = TotalReviewValue / ReviewCount;
            return AvarageReviewValue;
        }

        public int CountOfSpecificGradesForMovieByUser(int x, int y)

        {
            int NumberOfReviews = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Reviewer == y && Review.Movie == x)
                {
                    NumberOfReviews++;
                }

            }
            
            return NumberOfReviews;
        }

        public int CountOfMovieReviews(int x)
        {
            int ReviewCount = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Movie == x)
                {
                    ReviewCount++;
                }

            }
            return ReviewCount;
        }

        public double AvarageReviewOfMovie(int x)
        {
            int ReviewCount = 0;
            double TotalReviewValue = 0;
            double AvarageReviewValue = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Movie == x)
                {
                    TotalReviewValue += Review.Grade;
                    ReviewCount++;
                }

            }
            if (AvarageReviewValue != 0 && ReviewCount != 0) AvarageReviewValue = TotalReviewValue / ReviewCount;

            return AvarageReviewValue;
        }

        public int CountOfSpecificGradesForMovie(int x, int y)

        {
            int NumberOfReviews = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Movie == x && Review.Grade == y)
                {
                    NumberOfReviews++;
                }

            }

            return NumberOfReviews;
        }

        public List<int> MovieWithMostHighestGradeRate()
        {

            Dictionary<int, int> Movies = new Dictionary<int, int>();
            
            
            foreach (Review Review in Reviews)
            {
                if(Review.Grade == 5)
                {
                    Movies[Review.Movie]++;
                    
                }

            }

            int max = 0;
            foreach (var pair in Movies)
            {
                if (pair.Value > max)
                    max = pair.Value;
            }
            List<int> MoviesWithMostOfHighestGrade = new List<int>();
            foreach (var pair in Movies)
            {
                if (pair.Value == max)
                    MoviesWithMostOfHighestGrade.Add(pair.Key);
            }
            return MoviesWithMostOfHighestGrade;
        }

        public List<int> ReviewersWithMostReviews()
        {

            Dictionary<int, int> ReviewersReviews = new Dictionary<int, int>();


            foreach (Review Review in Reviews)
            {

                    ReviewersReviews[Review.Reviewer]++;
                

            }

            int max = 0;
            foreach (var pair in ReviewersReviews)
            {
                if (pair.Value > max)
                    max = pair.Value;
            }
            List<int> ReviewersWithMostReviews = new List<int>();
            foreach (var pair in ReviewersReviews)
            {
                if (pair.Value == max)
                    ReviewersWithMostReviews.Add(pair.Key);
            }
            return ReviewersWithMostReviews;
        }

        public List<int> TopNMovies(int N)
        {

            List<int> TopNMovies = new List<int>();
            Dictionary<int, double> ReviewsAvarageGrade = new Dictionary<int, double>();

            foreach (Review Review in Reviews)
            {

                ReviewsAvarageGrade[Review.Movie] = AvarageReviewOfMovie(Review.Movie);

        

            }

            var ordered = ReviewsAvarageGrade.OrderBy((i => i.Value));
          

            for (int i = 0; (i < N) && (i < ordered.Count()); i++)
            {

                TopNMovies.Add(ordered.ElementAt(i).Key);
            }


            return TopNMovies;
        }





        public ReviewService(ReviewRepository repo)
        {
            Repo = repo;
            Reviews = Repo.Get();
        }
    }
}
