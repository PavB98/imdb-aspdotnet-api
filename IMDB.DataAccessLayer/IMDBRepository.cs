using IMDB.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace IMDB.DataAccessLayer
{
    public class IMDBRepository
    {
        IMDBDataBaseContext imdbContextObj;
        public IMDBRepository()
        {
            imdbContextObj = new IMDBDataBaseContext();
        }

        public List<Movies> GetAllMovies()
        {
            List<Movies> moviesList = new List<Movies>();
            try
            {
                moviesList = imdbContextObj.Movies.ToList();
            }
            catch (Exception)
            {
                moviesList = null;
            }
            return moviesList;
        }

        public List<Actors> GetAllActors()
        {
            List<Actors> actorsList = new List<Actors>();
            try
            {
                actorsList = imdbContextObj.Actors.ToList();
            }
            catch (Exception)
            {
                actorsList = null;
            }
            return actorsList;
        }

        public List<Producers> GetAllProducers()
        {
            List<Producers> producersList = new List<Producers>();
            try
            {
                producersList = imdbContextObj.Producers.ToList();
            }
            catch (Exception)
            {
                producersList = null;
            }
            return producersList;
        }

        public bool UpdateMovieInfo(int movieId, string movieName, string imageSource, 
            DateTime dateOfRelease, string plot, string producerName, params string[] actors)
        {
            bool status = false;
            int producerId;
            try
            {
                var movie = imdbContextObj.Movies.Find(movieId);
                //var movie = imdbContextObj.Movies.Where(m => m.MovieName == movieName); - When search is based on non primary key

                producerId = imdbContextObj.Producers
                                            .Where(p => p.ProducerName == producerName)
                                            .Select(a => a.ProducerId)
                                            .FirstOrDefault();

                if (producerId != 0 && producerId > 100)
                {
                    movie.MovieName = movieName;
                    movie.PosterImageSource = imageSource;
                    movie.DateOfRelease = dateOfRelease;
                    movie.Plot = plot;
                    movie.Producer = producerId;

                    imdbContextObj.Update<Movies>(movie);
                    imdbContextObj.SaveChanges();

                    var actorsMoviesList = imdbContextObj.MoviesActors.Where(ma => ma.MovieId == movieId).ToList();
                    imdbContextObj.MoviesActors.RemoveRange(actorsMoviesList);
                    imdbContextObj.SaveChanges();

                    foreach (var item in actors)
                    {
                        int actorId = imdbContextObj.Actors
                                            .Where(a => a.ActorName == item)
                                            .Select(v => v.ActorId)
                                            .FirstOrDefault();
                        
                        MoviesActors actorMovie = new MoviesActors();
                        actorMovie.MovieId = movieId;
                        actorMovie.ActorId = actorId;

                        imdbContextObj.Add<MoviesActors>(actorMovie);
                        imdbContextObj.SaveChanges();
                    }
                    status = true;
                }
                else
                {
                    status = false;
                    Console.WriteLine("Please add the Producer to Producers-List before assigning him to a Movie");
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool AddMovie(string movieName, string imageSource,
            DateTime dateOfRelease, string plot, string producerName, params string[] actors)
        {
            bool status = false;
            int producerId;
            Movies movie = new Movies();
            try
            {
                producerId = imdbContextObj.Producers
                                    .Where(p => p.ProducerName == producerName)
                                    .Select(a => a.ProducerId)
                                    .FirstOrDefault();
                if (producerId != 0 && producerId > 100)
                {
                    movie.MovieName = movieName;
                    movie.PosterImageSource = imageSource;
                    movie.DateOfRelease = dateOfRelease;
                    movie.Plot = plot;
                    movie.Producer = producerId;

                    imdbContextObj.Add<Movies>(movie);
                    imdbContextObj.SaveChanges();

                    int movieId = movie.MovieId;

                    foreach (var item in actors)
                    {
                        int actorId = imdbContextObj.Actors
                                            .Where(a => a.ActorName == item)
                                            .Select(v=>v.ActorId)
                                            .FirstOrDefault();
                        
                        MoviesActors actorMovie = new MoviesActors();
                        actorMovie.MovieId = movieId;
                        actorMovie.ActorId = actorId;

                        imdbContextObj.Add<MoviesActors>(actorMovie);
                        imdbContextObj.SaveChanges();
                        }
                    
                    status = true;
                }
                else
                {
                    status = false;
                    Console.WriteLine("Please add the Producer to Producers-List before assigning him/her to a Movie");
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool AddActor(string actorName, string bio, DateTime dateOfBirth, string gender)
        {
            bool status = false;
            Actors actor = new Actors();
            try
            {
                actor.ActorName = actorName;
                actor.ActorBio = bio;
                actor.DateOfBirth = dateOfBirth;
                actor.Gender = gender;

                imdbContextObj.Add<Actors>(actor);
                imdbContextObj.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool AddProducer(string producerName, string bio, DateTime dateOfBirth, string company, string gender)
        {
            bool status = false;
            Producers producer = new Producers();
            try
            {
                producer.ProducerName = producerName;
                producer.ProducerBio = bio;
                producer.Company = company;
                producer.DateOfBirth = dateOfBirth;
                producer.Gender = gender;

                imdbContextObj.Add<Producers>(producer);
                imdbContextObj.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
