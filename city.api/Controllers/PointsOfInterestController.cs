using city.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace city.api.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet("PointTo/{cityId}")]
        public ActionResult<IEnumerable<PointOfInterestDto>>
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


        [HttpGet("{pointofinterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto>
            GetPointOfInterest(int cityId, int pointofinterestId)
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

        [HttpPost]

        public ActionResult<PointOfInterestDto> CreatePointOfInterest(
            int cityId,
            PointOfInterestForCreationDto pointOfInterest
            )
        {
            var city = CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var maxPointOfIneterstId = CitiesDataStore.current.Cities
                .SelectMany(c => c.PointsOfInterest)
                .Max(p => p.Id);
            var createPoint = new PointOfInterestDto()
            {
                Id = ++maxPointOfIneterstId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };
            city.PointsOfInterest.Add(createPoint);

            return CreatedAtAction("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointofinterestId = createPoint.Id
                },
                createPoint
                );
        }
    }
}
