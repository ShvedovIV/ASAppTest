using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ASApp.Models
{   
    [Route("SalesData")]
    [ApiController]
    public class SalesDataController : ControllerBase
    {
        

        private readonly ILogger<SalesDataController> _logger;

        public SalesDataController(ILogger<SalesDataController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetSalesData")]
        //[HttpGet]
        public ActionResult<List<SalesData>> GetAll() =>
            SalesDataRep.GetAll();


        [HttpGet("{id}")]
        public ActionResult<SalesData> Get(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : GET /SalesData/{id}");
            var salesData = SalesDataRep.Get(id);

            if(salesData == null)
                return NotFound();

            return salesData;
        }
        
        [HttpPost]
        public IActionResult Create(SalesData salesData)
        {       
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : POST /SalesData");
            SalesDataRep.Add(salesData);        
            return CreatedAtAction(nameof(Create), new { id = salesData.Id }, salesData);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, SalesData salesData)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : PUT /SalesData/{id}");
            if (id != salesData.Id)
                return BadRequest();

            var existingsalesPoint = SalesDataRep.Get(id);
            if(existingsalesPoint is null)
                return NotFound();

            SalesDataRep.Update(salesData);           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : DELETE /SalesData/{id}");
            var salesData = SalesDataRep.Get(id);

            if (salesData is null)
                return NotFound();

            SalesDataRep.Delete(id);

            return NoContent();
        }
    }
}