using city.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace city.api.Controllers
{
    [Route("api/Cities/{cityId}/PointsOfInterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointsOfInterestDto>>
            GetPointsOfiterest(int cityId)
        {
            var city = CitiesDataStore.current
                .Cities.FirstOrDefault
                (c => c.Id == cityId);

            if (cityId == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);


        }


        [HttpGet("{pointofinterestId}")]
        public ActionResult<PointsOfInterestDto>
            GetPointsOfInterest(int cityId, int pointofinterestId)
        {
            var city = CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var point = city.PointsOfInterest
                .FirstOrDefault(p => p.Id == pointofinterestId);

            if (point == null)
            {
                return NotFound();
            }
            return Ok(point);
        }
    }
}
