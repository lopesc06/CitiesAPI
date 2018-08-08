using Cityinfo.API.Models;
using Cityinfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cityinfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        //method injection
        private ICityInfoRepository _cityInfoRepository;
        public CitiesController (ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetCities()
        {
            //return Ok(CitiesDataStore.Current.Cities);
            var cityEntities = _cityInfoRepository.GetCities();
            var results = new List<CityWithoutPointsOfInterestDto>();
            foreach (var cityEntity in cityEntities)
            {
                results.Add(new CityWithoutPointsOfInterestDto
                {
                    Id = cityEntity.Id,
                    Name = cityEntity.Name,
                    Description = cityEntity.Description                
                });
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            //var CitiesToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            //if(CitiesToReturn == null)
            //{
            //    return NotFound();
            //}
            //return Ok(CitiesToReturn);

            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityResult = new CityDto()
                {
                    Id = city.Id,
                    Name = city.Name,
                    Description = city.Description
                };
                foreach (var pointOfInterest in city.PointsOfInterest)
                {
                    cityResult.PointsOfInterest.Add(new PointOfInterestDto {
                        Id = pointOfInterest.Id,
                        Name = pointOfInterest.Name,
                        Description = pointOfInterest.Description
                    });
                }
                return Ok(cityResult);
            }

            var cityResultWithoutPointsOfInterest = new CityWithoutPointsOfInterestDto()
            {
                Id = city.Id,
                Name = city.Name,
                Description = city.Description
            };
            return Ok(cityResultWithoutPointsOfInterest);
        }

    }
}
