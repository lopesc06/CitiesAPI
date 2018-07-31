using Cityinfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cityinfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id=1,
                    Name = "USA",
                    Description = "USA Description"
                },
                new CityDto()
                {
                    Id=2,
                    Name = "Mexico",
                    Description = "Mexico Description"
                },
                new CityDto()
                {
                    Id=3,
                    Name = "Chile",
                    Description = "Chile Description"
                },

            };
        }
    }
}
