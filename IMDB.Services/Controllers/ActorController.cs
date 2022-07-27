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
    public class ActorController : Controller
    {
        IMDBRepository repository;
        public ActorController()
        {
            repository = new IMDBRepository();
        }

        [HttpGet]
        public JsonResult GetAllActors()
        {
            List<Actors> actors = new List<Actors>();
            try
            {
                actors = repository.GetAllActors();
            }
            catch (Exception)
            {
                actors = null;
            }
            return Json(actors);
        }

        [HttpPost]
        public string AddActor(string actorName, string bio, DateTime dateOfBirth, string gender)
        {
            bool status = false;
            string result = "";
            try
            {
                status = repository.AddActor(actorName, bio, dateOfBirth, gender);
                if (status)
                {
                    result = "Actor details added succesfully!";
                }
                else
                {
                    result = "Sorry, can not add Actor!";
                }
            }
            catch (Exception)
            {
                result = "Sorry, something wend wrong!";
            }
            return result;
        }
    }
}