﻿using AutoMapper;
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
            var cityEntities = _cityInfoRepository.GetCities();
            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityResult = Mapper.Map<CityDto>(city);
                return Ok(cityResult);
            }

            var cityResultWithoutPointsOfInterest = Mapper.Map<CityWithoutPointsOfInterestDto>(city);
            return Ok(cityResultWithoutPointsOfInterest);
        }

    }
}
