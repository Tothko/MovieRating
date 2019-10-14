using MovieRating.Core.MovieRating.Core;
using MovieRating.Infrastructure.JSONReader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class PerformanceTests
    {
        private static readonly IRepository repository = new ReviewRepository(@"C:\Users\Marek\source\repos\MovieRating\Resources\ratings.json");
        private static readonly long MaxExecutionDuration = 4000;
        private static readonly long ExecutionCycles = 5;
        private static void AssertPerformance(Action method,long maxTimeMilliseconds, long numberOfRuns)
        {
            //Execute method first time because of JIT compilation
            method();

            //Allocate new stopwatch object
            Stopwatch stopwatch = new Stopwatch();

            //This will be incremented every run by number of milliseconds that run takes
            long totalMilliseconds = 0;

            for(long runIndex = 0; runIndex < numberOfRuns; ++runIndex)
            {
                stopwatch.Start();
                method();
                stopwatch.Stop();

                totalMilliseconds += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            Assert.True(totalMilliseconds / numberOfRuns < maxTimeMilliseconds);
        }

        [Fact]
        public void TestCountOfUserReviews()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => RS.CountOfUserReviews(5), MaxExecutionDuration, ExecutionCycles);
        }

        [Fact]
        public void TestAvarageReviewOfUser()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => RS.AvarageReviewOfUser(5), MaxExecutionDuration, ExecutionCycles);
        }

        [Fact]
        public void CountOfMovieReviews()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => RS.CountOfMovieReviews(5), MaxExecutionDuration, ExecutionCycles);
        }

        [Fact]
        public void TestAvarageReviewOfMovie()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => RS.AvarageReviewOfMovie(5), MaxExecutionDuration, ExecutionCycles);
        }

        [Fact]
        public void TestCountOfSpecificGradesForMovie()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => RS.CountOfSpecificGradesForMovie(5,5), MaxExecutionDuration, ExecutionCycles);
        }


        [Fact]

        public void TestCountOfSpecificGradesForMovieByUser()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => RS.CountOfSpecificGradesForMovieByUser(5, 5), MaxExecutionDuration, ExecutionCycles);
        }

        [Fact]
        public void TestMovieWithMostHighestGradeRate()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => RS.MovieWithMostHighestGradeRate(), MaxExecutionDuration, ExecutionCycles);
        }


        [Fact]
        public void TestReviewersWithMostReviews()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => _ = RS.ReviewersWithMostReviews(), MaxExecutionDuration, ExecutionCycles);
        }
       
        [Fact]
        public void TestTopNMovies()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => _= RS.TopNMovies(5), MaxExecutionDuration, ExecutionCycles);
        }

        [Fact]
        public void TestMoviesOfReviewerSortedByRateThenDate()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => _=RS.MoviesOfReviewerSortedByRateThenDate(1), MaxExecutionDuration, ExecutionCycles);
        }

        [Fact]
        public void TestReviewersOfMovieSortedByRateThenDate()
        {
            ReviewService RS = new ReviewService(repository);
            AssertPerformance(() => _=RS.ReviewersOfMovieSortedByRateThenDate(1), MaxExecutionDuration, ExecutionCycles);
        }
    }
}
