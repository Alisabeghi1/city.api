using city.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace city.api.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.current.Cities);

        }

        [HttpGet("{id}")]

        public JsonResult GetCity(int id)
        {
            return new JsonResult(
                CitiesDataStore.current.Cities
                .FirstOrDefault(c => id == id));
                
        }
    }
}
