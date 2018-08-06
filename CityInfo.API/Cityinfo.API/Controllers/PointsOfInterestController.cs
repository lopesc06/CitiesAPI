using Cityinfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        //Gets all Points of interest from a city
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        //Gets a specific point of interest from a city
        [HttpGet("{cityId}/pointsofinterest/{pointId}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int pointId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var pointofinterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointId);
            if (pointofinterest == null)
            {
                return NotFound();
            }
            return Ok(pointofinterest);
        }

        //Creates a new point of interest in a city
        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) //Input Validation
            {
                return BadRequest(ModelState); //Return Bad request with the corresponding messages
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);
            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };
            city.PointsOfInterest.Add(finalPointOfInterest);
            return CreatedAtRoute("GetPointOfInterest", new
            { cityId = cityId, pointId = finalPointOfInterest.Id }, finalPointOfInterest);
        }

        //It makes a full update of the city 
        [HttpPut("{cityId}/pointsofinterest/{pointId}")]
        public IActionResult UpdatePointOfInterest(int cityId, int pointId, [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) //Input Validation
            {
                return BadRequest(ModelState); //Return Bad request with the corresponding messages
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            var pointOfInterestFromStorage = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointId);
            if (city == null || pointOfInterestFromStorage == null)
            {
                return NotFound();
            }

            pointOfInterestFromStorage.Name = pointOfInterest.Name;
            pointOfInterestFromStorage.Description = pointOfInterest.Description;
            return NoContent();
        }

        //Partial Update from a  point of interest
        [HttpPatch("{cityId}/pointsofinterest/{pointId}")]
        public  IActionResult PartialUpdatePointOfInterest (int cityId, int pointId, [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            var pointOfInterestFromStorage = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointId);
            if (city == null || pointOfInterestFromStorage == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterestFromStorage.Name,
                Description = pointOfInterestFromStorage.Description
            };
            patchDoc.ApplyTo(pointOfInterestToPatch,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TryValidateModel(pointOfInterestToPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            pointOfInterestFromStorage.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStorage.Description = pointOfInterestToPatch.Description;
            return NoContent();
        }

        //Delete a Point Of interest from a city
        [HttpDelete("{cityId}/pointsofinterest/{pointId}")]
        public IActionResult DeletePointOfInterest (int cityId, int pointId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            var pointOfInterestFromStorage = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointId);
            if (city == null || pointOfInterestFromStorage == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestFromStorage);
            return NoContent();
        }
    }
}
