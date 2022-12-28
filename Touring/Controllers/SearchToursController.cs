using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Touring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchToursController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SearchToursController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Get(string country)
        {
            var rootFolder = _webHostEnvironment.WebRootPath;
            var filePath = Path.Combine(rootFolder, @"files\countries.min.json");
            var gData = System.IO.File.ReadAllText(filePath);
            JsonDocument jsnCountries = JsonDocument.Parse(gData);
            var jdata = jsnCountries.RootElement;
            JsonElement cities = new JsonElement();
            jdata.TryGetProperty(country,out cities);
            return Json(new { data = cities });
        }

        [HttpPost]
        public IActionResult GetCities([FromBody]string countries)
        {
            var cList = countries.Split(',');
            var rootFolder = _webHostEnvironment.WebRootPath;
            var fullPath = Path.Combine(rootFolder, @"files\countries.min.json");
            var rawData = System.IO.File.ReadAllText(fullPath);
            JsonDocument jsonRaw = JsonDocument.Parse(rawData);
            var countriesJson = jsonRaw.RootElement.EnumerateObject();

            var query = from c in countriesJson
                        join l in cList on c.Name equals l
                        select new { country = c.Name, cities = c.Value };
            return Json(new { data = query });
        }

    }
}
