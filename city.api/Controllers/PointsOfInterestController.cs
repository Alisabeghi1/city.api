using city.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace city.api.Controllers
{

    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
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

        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
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

        #region POST


        [HttpPost]

        public ActionResult<PointOfInterestDto> CreatePointOfInterest(
            int cityId,
            PointOfInterestForCreationDto pointOfInterest
            )
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
        #endregion


        #region EDIT

        [HttpPut("{pointofinterestId}")]

        public ActionResult UpdatePointOfinterest(
            int cityId, int pointofinterestId
            ,PointOfInterestForUpdateDto pointOfInterest)
        {
            var city = CitiesDataStore.current.Cities.
                FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            var point = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointofinterestId);
            if (point == null) { return NotFound();}

            point.Name = pointOfInterest.Name;
            point.Description = pointOfInterest.Description;
            return NoContent(); 
            
        }
        #endregion

    }
}
