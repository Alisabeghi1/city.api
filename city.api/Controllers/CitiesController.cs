﻿using city.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace city.api.Controllers
{
    [Route("api/Cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetCities()

        {
            var result = CitiesDataStore.current?.Cities.ToList();


            return Ok(result);
        }

        [HttpGet("{id}")]

        public ActionResult<CityDto> GetCity(int id)
        {       
            var cityToReturn = CitiesDataStore.current.Cities
                .FirstOrDefault(x => x.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }


        //ali.com/api/cities/1/tehran/iran
        //[HttpGet("{id}/{city}/{country}")]

        //public ActionResult<CityDto> Testrout(int id, string city, string country)
        //{
        //    return Ok();
        //}


    }
}
