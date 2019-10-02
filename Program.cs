using MovieRating.Core.MovieRating.Core;
using MovieRating.Infrastructure.JSONReader;
using System;

namespace MovieRating
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            ReviewService RevServ = new ReviewService(new ReviewRepository());
            
            Console.WriteLine("Select user");
            int cislo = RevServ.CountOfUserReviews(int.Parse(Console.ReadLine()));
            Console.WriteLine("User has this many reviews" + cislo);
        }
    }
}
    