using Cityinfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cityinfo.API
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }
            //init seed data
            var cities = new List<City>()
            {
                new City()
                {
                    Name = "USA",
                    Description = "USA Description",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "USA Point Of Interest #1",
                            Description = "Description of USA Point Of Interest #1"
                        },
                         new PointOfInterest()
                        {
                            Name = "USA Point Of Interest #2",
                            Description = "Description of USA Point Of Interest #2"
                        }
                    }
                },
                new City()
                {
                    Name = "Mexico",
                    Description = "Mexico Description",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Mexico Point Of Interest #1",
                            Description = "Description of Mexico Point Of Interest #1"
                        },
                         new PointOfInterest()
                        {
                            Name = "Mexico Point Of Interest #2",
                            Description = "Description of Mexico Point Of Interest #2"
                        }
                    }
                },
                new City()
                {
                    Name = "Chile",
                    Description = "Chile Description",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Chile Point Of Interest #1",
                            Description = "Description of Chile Point Of Interest #1"
                        },
                         new PointOfInterest()
                        {
                            Name = "Chile Point Of Interest #2",
                            Description = "Description of Chile Point Of Interest #2"
                        }
                    }
                },

            };
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }

    }
}
