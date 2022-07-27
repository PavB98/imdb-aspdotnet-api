using IMDB.DataAccessLayer;
using System;

namespace IMDB.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMDBRepository repository = new IMDBRepository();

            DateTime d = new DateTime(2022, 8, 2);
            var status = repository.UpdateMovieInfo(1002, "The Wilds", "the_wilds.png", d, "A roller coaster of adventures", "Christian Bale");
            Console.WriteLine(status);

            #region
            //DateTime d = new DateTime(2000, 9, 1);
            //var status = repository.AddProducer("ABC", "XYZ",d, "Company", "Female");
            //Console.WriteLine(status);
            #endregion

            //DateTime d = new DateTime(2000, 9, 1);
            //var status = repository.AddActor("Harry", "Harry Porter", d, "Male");
            //Console.WriteLine(status);

            //var movies = repository.GetAllMovies();
            //foreach (var m in movies)
            //{
            //    Console.WriteLine("{0}\t\t{1}", m.MovieId, m.MovieName);
            //}
        }
    }
}
