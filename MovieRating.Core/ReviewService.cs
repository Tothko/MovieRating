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
            return Reviews
                .Where(r => r.Movie == Movie)
                .Count();
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
            return Reviews
                .Where(r => r.Movie == Movie && r.Grade == Grade)
                .Count();
        }

        public IEnumerable<int> MovieWithMostHighestGradeRate()
        {
            var orderedTop = Reviews
                .Where(r => r.Grade == 5)
                .GroupBy(r => new { MovieId = r.Movie })
                .Select(r => new
                {
                    Id = r.Key.MovieId,
                    Count = r.Count()
                })
                .OrderByDescending(r => r.Count);

            var max = orderedTop.First().Count;

            return orderedTop
                .Where(r => r.Count == max)
                .Select(r => r.Id);
        }

        public IEnumerable<int> ReviewersWithMostReviews()
        {
            var orderedTop = Reviews
                .GroupBy(r => new { Reviewer = r.Reviewer })
                .Select(r => new
                {
                    Reviewer = r.Key.Reviewer,
                    Count = r.Count()
                })
                .OrderByDescending(r => r.Count);

            var max = orderedTop.First().Count;

            return orderedTop
                .Where(r => r.Count == max)
                .Select(r => r.Reviewer);
        }
        
        public IEnumerable<int> TopNMovies(int N)
    
        {
            return Reviews
                .GroupBy(r => new { MovieId = r.Movie })
                .Select(r => new
                {
                    Average = r.Average(p => p.Grade),
                    MovieId = r.Key.MovieId
                })
                .OrderByDescending(r => r.Average)
                .Take(N)
                .Select(x => x.MovieId);  
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
