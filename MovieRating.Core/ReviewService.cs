using MovieRating.Core.Entities.Entities;
using MovieRating.Infrastructure.JSONReader;
using System;
using System.Collections.Generic;

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

        public int MovieWithMostHighestGradeRate()
            // Continue here
        {
            int movie = 0;
            
            foreach (Review Review in Reviews)
            {
                

            }

            return movie;
        }





        public ReviewService(ReviewRepository repo)
        {
            Repo = repo;
            Reviews = Repo.LoadReviews();
        }
    }
}
