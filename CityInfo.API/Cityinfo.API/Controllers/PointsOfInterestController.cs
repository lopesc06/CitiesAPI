using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cityinfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            return Ok(city.PointOfInterestDto);
        }

        [HttpGet("{cityId}/pointsofinterest/{pointId}")]
        public IActionResult GetPointOfInterest(int cityId, int pointId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var pointofinterest = city.PointOfInterestDto.FirstOrDefault(p => p.Id == pointId);
            if(pointofinterest == null)
            {
                return NotFound();
            }
            return Ok(pointofinterest);
        }

    }
}
