using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.DataAccessLayer;
using IMDB.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : Controller
    {
        IMDBRepository repository;
        public MoviesController()
        {
            repository = new IMDBRepository();
        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            List<Movies> movies = new List<Movies>();
            try
            {
                movies = repository.GetAllMovies();
            }
            catch (Exception)
            {
                movies = null;
            }
            return Json(movies);
        }

        [HttpPut]
        public string ModifyMovieDetails(int movieId, string movieName, string imageSource,
            DateTime dateOfRelease, string plot, string producerName)
        {
            string result ="";
            try
            {
                var status = repository.UpdateMovieInfo(movieId, movieName, imageSource, dateOfRelease, plot, producerName);
                if (status)
                {
                    result = "Movie details modified successfully!";
                }
                else
                {
                    result = "Please add the Producer to Producers-List before assigning him to a Movie";
                }
            }
            catch (Exception)
            {
                result = "Something went wrong!";

            }
            return result;
        }

        [HttpPost]
        public string AddMovieDetails(string movieName, string imageSource,
            DateTime dateOfRelease, string plot, string producerName)
        {
            string result = "";
            try
            {
                var status = repository.AddMovie(movieName, imageSource, dateOfRelease, plot, producerName);
                if (status)
                {
                    result = "Movie details added successfully!";
                }
                else
                {
                    result = "Please add the Producer to Producers-List before assigning him to a Movie";
                }
            }
            catch (Exception)
            {
                result = "Something went wrong!";

            }
            return result;
        }

    }
}