using city.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace city.api.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable <CityDto>> GetCities()

        {
            return Ok(CitiesDataStore.current.Cities);
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
