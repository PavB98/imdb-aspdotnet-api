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
    public class ProducerController : Controller
    {
        IMDBRepository repository;
        public ProducerController()
        {
            repository = new IMDBRepository();
        }

        [HttpGet]
        public JsonResult GetAllProducers()
        {
            List<Producers> producers = new List<Producers>();
            try
            {
                producers = repository.GetAllProducers();
            }
            catch (Exception)
            {
                producers = null;
            }
            return Json(producers);
        }

        [HttpPost]
        public string AddProducer(string producerName, string bio, DateTime dateOfBirth, string company, string gender)
        {
            bool status = false;
            string result = "";
            try
            {
                status = repository.AddProducer(producerName,bio, dateOfBirth,company, gender);
                if (status)
                {
                    result = "Producer details added succesfully!";
                }
                else
                {
                    result = "Sorry, can not add Producer!";
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