using MovieRating.Infrastructure.JSONReader;
using MovieRating.Core.Entities.Entities;
using System;
using Xunit;
using MovieRating.Core.MovieRating.Core;
using System.Collections.Generic;

namespace MovieRating.UnitTests.XUnitTest
{
    public class UnitTest1
    {
        
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 2)]
        [InlineData(3, 0)]

        public void TestCountOfUserReviews(int ReviewerID, int expected)
        {
            IRepository repo = new FakeRepository();
            repo.Add(new Review(1, 1, 5, System.DateTime.Now));
            repo.Add(new Review(1, 2, 5, System.DateTime.Now));
            repo.Add(new Review(2, 3, 5, System.DateTime.Now));
            repo.Add(new Review(2, 1, 5, System.DateTime.Now));
            repo.Add(new Review(1, 2, 5, System.DateTime.Now));
            ReviewService RS = new ReviewService(repo);
            Assert.Equal(expected, RS.CountOfUserReviews(ReviewerID));
        }
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 3.5)]
        [InlineData(3, 0)]
        public void TestAvarageReviewOfUser(int ReviewerID, double expected)
        {
            IRepository repo = new FakeRepository();
            repo.Add(new Review(1, 2, 1, System.DateTime.Now));
            repo.Add(new Review(1, 2, 3, System.DateTime.Now));
            repo.Add(new Review(2, 3, 2, System.DateTime.Now));
            repo.Add(new Review(2, 1, 5, System.DateTime.Now));
            repo.Add(new Review(1, 2, 5, System.DateTime.Now));
            ReviewService RS = new ReviewService(repo);
            Assert.Equal(expected, RS.AvarageReviewOfUser(ReviewerID));
        }
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(4, 0)]
        public void CountOfMovieReviews(int MovieID, double expected)
        {
            IRepository repo = new FakeRepository();
            repo.Add(new Review(1, 2, 1, System.DateTime.Now));
            repo.Add(new Review(1, 2, 3, System.DateTime.Now));
            repo.Add(new Review(2, 3, 2, System.DateTime.Now));
            repo.Add(new Review(2, 1, 5, System.DateTime.Now));
            repo.Add(new Review(1, 2, 5, System.DateTime.Now));
            ReviewService RS = new ReviewService(repo);
            Assert.Equal(expected, RS.CountOfMovieReviews(MovieID));
        }

        [Theory]
        [InlineData(1 , 5)]
        [InlineData(2, 3)]
        [InlineData(0, 0)]
        public void TestAvarageReviewOfMovie(int MovieID, double expected)
        {
            IRepository repo = new FakeRepository();
            repo.Add(new Review(1, 2, 1, System.DateTime.Now));
            repo.Add(new Review(4, 2, 3, System.DateTime.Now));
            repo.Add(new Review(2, 3, 2, System.DateTime.Now));
            repo.Add(new Review(2, 1, 5, System.DateTime.Now));
            repo.Add(new Review(3, 2, 5, System.DateTime.Now));
            ReviewService RS = new ReviewService(repo);
            Assert.Equal(expected, RS.AvarageReviewOfMovie(MovieID));
        }
        [Theory]
        [InlineData(1, 5, 1)]
        [InlineData(2, 5, 2)]
        [InlineData(4, 5, 0)]
        [InlineData(2, 3, 0)]
        public void TestCountOfSpecificGradesForMovie(int Movie, int Grade, int expected)
        {
            IRepository repo = new FakeRepository();
            repo.Add(new Review(1, 2, 1, System.DateTime.Now));
            repo.Add(new Review(1, 2, 5, System.DateTime.Now));
            repo.Add(new Review(2, 3, 2, System.DateTime.Now));
            repo.Add(new Review(2, 1, 5, System.DateTime.Now));
            repo.Add(new Review(3, 2, 5, System.DateTime.Now));
            ReviewService RS = new ReviewService(repo);
            Assert.Equal(expected, RS.CountOfSpecificGradesForMovie(Movie, Grade));

        }
   

        [Theory]
        [InlineData(1, 5, 1)]
        [InlineData(2, 2, 2)]
        [InlineData(3, 2, 0)]
        [InlineData(1, 4, 0)]
        public void TestCountOfSpecificGradesForMovieByUser(int Reviewer, int Grade,int expected)
        {
            IRepository repo = new FakeRepository();
            repo.Add(new Review(1, 2, 1, System.DateTime.Now));
            repo.Add(new Review(1, 2, 3, System.DateTime.Now));
            repo.Add(new Review(2, 3, 2, System.DateTime.Now));
            repo.Add(new Review(2, 1, 2, System.DateTime.Now));
            repo.Add(new Review(1, 2, 5, System.DateTime.Now));
            ReviewService RS = new ReviewService(repo);
            Assert.Equal(expected, RS.CountOfSpecificGradesForMovieByUser(Reviewer, Grade));

        }

        // List
        [Fact]

        public void TestMovieWithMostHighestGradeRate()
        {
            Review Review1 = new Review(1, 6, 1, System.DateTime.Now);
            Review Review2 = new Review(1, 2, 3, System.DateTime.Now);
            Review Review3 = new Review(2, 3, 2, System.DateTime.Now);
            Review Review4 = new Review(2, 1, 5, System.DateTime.Now);
            Review Review5 = new Review(1, 4, 5, System.DateTime.Now);
            List<int> expected = new List<int>();
            expected.Add(1);
            expected.Add(4);
            IRepository repo = new FakeRepository();
            repo.Add(Review1);
            repo.Add(Review2);
            repo.Add(Review3);
            repo.Add(Review4);
            repo.Add(Review5);
            ReviewService RS = new ReviewService(repo);
            Assert.Equal(expected, RS.MovieWithMostHighestGradeRate());
        }
        // List
        [Fact]
        public void TestReviewersWithMostReviews()
        {
            List<int> expected = new List<int>();
            expected.Add(1);
            IRepository repo = new FakeRepository();
            repo.Add(new Review(1, 2, 1, System.DateTime.Now));
            repo.Add(new Review(1, 6, 3, System.DateTime.Now));
            repo.Add(new Review(2, 3, 2, System.DateTime.Now));
            repo.Add(new Review(2, 1, 5, System.DateTime.Now));
            repo.Add(new Review(1, 4, 5, System.DateTime.Now));
            ReviewService RS = new ReviewService(repo);
            Assert.Equal(expected, RS.ReviewersWithMostReviews());
        }
        [Fact]
        public void TestTopNMovies()
        {
            Review Review1 = new Review(1, 2, 1, System.DateTime.Now);
            Review Review2 = new Review(1, 6, 3, System.DateTime.Now);
            Review Review3 = new Review(2, 3, 2, System.DateTime.Now);
            Review Review4 = new Review(2, 1, 5, System.DateTime.Now);
            Review Review5 = new Review(1, 4, 5, System.DateTime.Now);
            List<int> expected = new List<int>();
            expected.Add(Review1.Movie);
            expected.Add(Review2.Movie);
            expected.Add(Review3.Movie);
            expected.Add(Review4.Movie);
            expected.Add(Review5.Movie);
            IRepository repo = new FakeRepository();
            repo.Add(Review1);
            repo.Add(Review2);
            repo.Add(Review3);
            repo.Add(Review4);
            repo.Add(Review5);
            ReviewService RS = new ReviewService(repo);
            Assert.Equal(expected, RS.TopNMovies(5));
        }

        [Fact]
        public void TestMoviesOfReviewerSortedByRateThenDate()
        {
            Review Review1 = new Review(1, 4, 1, System.DateTime.Now);
            Review Review2 = new Review(1, 6, 1, System.DateTime.MaxValue);
            Review Review3 = new Review(2, 3, 2, System.DateTime.MaxValue);
            Review Review4 = new Review(2, 1, 5, System.DateTime.MinValue);
            Review Review5 = new Review(1, 2, 5, System.DateTime.MinValue);
            IRepository repo = new FakeRepository();
            repo.Add(Review1);
            repo.Add(Review2);
            repo.Add(Review3);
            repo.Add(Review4);
            repo.Add(Review5);
            ReviewService RS = new ReviewService(repo);
            List<Review> expected = new List<Review>();
            expected.Add(Review1);
            expected.Add(Review2);
            expected.Add(Review5);
            List<Review> actual = RS.MoviesOfReviewerSortedByRateThenDate(1);
            Assert.Equal(expected[0], actual[0]);
            Assert.Equal(expected[1], actual[1]);
            Assert.Equal(expected[2], actual[2]);
        }

        [Fact]
        public void TestReviewersOfMovieSortedByRateThenDate()
        {
            Review Review1 = new Review(1, 4, 1, System.DateTime.Now);
            Review Review2 = new Review(1, 6, 3, System.DateTime.MaxValue);
            Review Review3 = new Review(3, 1, 2, System.DateTime.MaxValue);
            Review Review4 = new Review(2, 1, 5, System.DateTime.MinValue);
            Review Review5 = new Review(4, 1, 5, System.DateTime.MinValue);
            IRepository repo = new FakeRepository();
            repo.Add(Review1);
            repo.Add(Review2);
            repo.Add(Review3);
            repo.Add(Review4);
            repo.Add(Review5);
            ReviewService RS = new ReviewService(repo);
            List<Review> expected = new List<Review>();
            expected.Add(Review3);
            expected.Add(Review4);
            expected.Add(Review5);
            List<Review> actual = RS.ReviewersOfMovieSortedByRateThenDate(1);
            Assert.Equal(expected[0], actual[0]);
            Assert.Equal(expected[1], actual[1]);
            Assert.Equal(expected[2], actual[2]);
        }
    }
}