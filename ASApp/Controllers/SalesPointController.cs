using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace ASApp.Models
{   
    [Route("SalesPoint")]
    [ApiController]
    public class SalesPointController : ControllerBase
    {
        

        private readonly ILogger<SalesPointController> _logger;

        public SalesPointController(ILogger<SalesPointController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetSalesPoint")]
        //[HttpGet]
        public ActionResult<List<SalesPoint>> GetAll() =>
            SalesPointRep.GetAll();


        [HttpGet("{id}")]
        public ActionResult<SalesPoint> Get(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} :GET /SalesPoint/{id}");
            var salesPoint = SalesPointRep.Get(id);

            if(salesPoint == null)
                return NotFound();

            return salesPoint;
        }
        
        [HttpPost]
        public IActionResult Create(SalesPoint salesPoint)
        {       
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} :POST /SalesPoint");
            // При заполнении сущности ProvidedProducts будет автоматически проставлен SalesPointId!!!
            var id = SalesPointRep.Add(salesPoint);
            var salesPoint1 = SalesPointRep.Get(id);
            if(salesPoint1 is null)
                return NotFound();
            foreach (ProvidedProducts p in salesPoint1.ProvidedProducts)
            {
                p.SalesPointId = id; 
                ProvidedProductsRep.Add(p);    
            }
            SalesPointRep.Update(salesPoint); 
                    

            return CreatedAtAction(nameof(Create), new { id = salesPoint.Id }, salesPoint);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, SalesPoint salesPoint)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} :PUT /SalesPoint/{id}");
            if (id != salesPoint.Id)
                return BadRequest();

            var existingsalesPoint = SalesPointRep.Get(id);
            if(existingsalesPoint is null)
                return NotFound();

            SalesPointRep.Update(salesPoint);           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} :DELETE /SalesPoint/{id}");
            var salesPoint = SalesPointRep.Get(id);

            if (salesPoint is null)
                return NotFound();

            SalesPointRep.Delete(id);

            return NoContent();
        }
    }
}