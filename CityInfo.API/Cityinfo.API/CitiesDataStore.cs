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
                    Description = "USA Description",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "USA Point Of Interest #1",
                            Description = "Description of USA Point Of Interest #1"
                        },
                         new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "USA Point Of Interest #2",
                            Description = "Description of USA Point Of Interest #2"
                        }
                    }
                },
                new CityDto()
                {
                    Id=2,
                    Name = "Mexico",
                    Description = "Mexico Description",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Mexico Point Of Interest #1",
                            Description = "Description of Mexico Point Of Interest #1"
                        },
                         new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Mexico Point Of Interest #2",
                            Description = "Description of Mexico Point Of Interest #2"
                        }
                    }
                },
                new CityDto()
                {
                    Id=3,
                    Name = "Chile",
                    Description = "Chile Description",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Chile Point Of Interest #1",
                            Description = "Description of Chile Point Of Interest #1"
                        },
                         new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Chile Point Of Interest #2",
                            Description = "Description of Chile Point Of Interest #2"
                        }
                    }
                },

            };
        }
    }
}
