using MovieRating.Core.Entities.Entities;
using MovieRating.Infrastructure.JSONReader;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRating.Core.MovieRating.Core

{
    public class ReviewService
    {

        IRepository Repo;
        List<Review> Reviews;
        public int CountOfUserReviews(int Reviewer)
        {
            int ReviewCount = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Reviewer == Reviewer)
                {
                    ReviewCount++;
                }

            }
            return ReviewCount;
        }

        public double AvarageReviewOfUser(int Reviewer)
        {
            int ReviewCount = 0;
            double TotalReviewValue = 0;
            double AvarageReviewValue = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Reviewer == Reviewer)
                {
                    TotalReviewValue += Review.Grade;
                    ReviewCount++;
                }

            }
            if (ReviewCount != 0) AvarageReviewValue = TotalReviewValue / ReviewCount;
            return AvarageReviewValue;
        }

        public int CountOfSpecificGradesForMovieByUser(int Reviewer, int Grade)

        {
            int NumberOfReviews = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Reviewer == Reviewer && Review.Grade == Grade)
                {
                    NumberOfReviews++;
                }

            }

            return NumberOfReviews;
        }

        public int CountOfMovieReviews(int Movie)
        {
            int ReviewCount = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Movie == Movie)
                {
                    ReviewCount++;
                }

            }
            return ReviewCount;
        }

        public double AvarageReviewOfMovie(int Movie)
        {
            int ReviewCount = 0;
            double TotalReviewValue = 0;
            double AvarageReviewValue = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Movie == Movie)
                {
                    TotalReviewValue += Review.Grade;
                    ReviewCount++;
                }

            }
            if (ReviewCount != 0) AvarageReviewValue = TotalReviewValue / ReviewCount;

            return AvarageReviewValue;
        }

        public int CountOfSpecificGradesForMovie(int Movie, int Grade)

        {
            int NumberOfReviews = 0;
            foreach (Review Review in Reviews)
            {
                if (Review.Movie == Movie && Review.Grade == Grade)
                {
                    NumberOfReviews++;
                }

            }

            return NumberOfReviews;
        }

        public List<int> MovieWithMostHighestGradeRate()
        {

            Dictionary<int, double> Movies = new Dictionary<int, double>();


            foreach (Review Review in Reviews)
            {
                if (Review.Grade == 5)
                {
                    if (!Movies.ContainsKey(Review.Movie))
                    {
                        Movies.Add(Review.Movie, Review.Grade);
                    }

                }

            }

            double max = 0;
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

                if (!ReviewersReviews.ContainsKey(Review.Reviewer)){
                    ReviewersReviews.Add(Review.Reviewer, CountOfUserReviews(Review.Reviewer));
                }

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

        public List<Review> MoviesOfReviewerSortedByRateThenDate(int Reviewer)
        {
            List<Review> MoviesOfReviewerSortedByRateThenDate = new List<Review>();
            foreach (Review Review in Reviews)
            {
                if (Review.Reviewer == Reviewer) MoviesOfReviewerSortedByRateThenDate.Add(Review);
            }
            Reviews.OrderByDescending(a => a.Grade).ThenByDescending(a => a.Date);
            return MoviesOfReviewerSortedByRateThenDate;
        }

        public List<Review> ReviewersOfMovieSortedByRateThenDate(int Movie)
        {
            List<Review> MoviesOfReviewerSortedByRateThenDate = new List<Review>();
            foreach (Review Review in Reviews)
            {
                if (Review.Movie == Movie) MoviesOfReviewerSortedByRateThenDate.Add(Review);
            }
            Reviews.OrderByDescending(a => a.Grade).ThenByDescending(a => a.Date);
            return MoviesOfReviewerSortedByRateThenDate;
        }



        public ReviewService(IRepository repo)
        {
            Repo = repo;
            Reviews = Repo.Get();
        }
    }
}
