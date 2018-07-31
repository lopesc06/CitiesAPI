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
        [HttpGet()]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var CitiesToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if(CitiesToReturn == null)
            {
                return NotFound();
            }
            return Ok(CitiesToReturn);
        }

    }
}
