using System;
using Xunit;

namespace MovieRating.UnitTests.XUnit
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1)]
        public void TestCountOfUserReviews(int x)
        {

        }
        [Theory]
        [InlineData(1)]
        public void TestAvarageReviewOfUser(int x)
        {

        }
        [Theory]
        [InlineData(1, 1)]
        public void TestCountOfSpecificGradesForMovieByUser(int x, int y)
        {

        }
        [Theory]
        [InlineData(1)]
        public void TestAvarageReviewOfMovie(int x)
        {

        }
        [Theory]
        [InlineData(1, 5)]
        public void TestCountOfSpecificGradesForMovie(int x, int y)
        {

        }
        [Fact]
        public void TestMovieWithMostHighestGradeRate()
        {

        }
        [Fact]
        public void TestReviewersWithMostReviews()
        {

        }
        [Theory]
        [InlineData(4, 4)]
        [InlineData(10, 5)]
        [InlineData(0, 0)]
        public void TopNMovies(int x, int expected)
        {

        }
    }
}