using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace ASApp.Models
{   
    [Route("Sale")]
    [ApiController]
    public class SaleController : ControllerBase
    {

        private readonly ILogger<SaleController> _logger;

        public SaleController(ILogger<SaleController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetSale")]
        //[HttpGet]
        public ActionResult<List<Sale>> GetAll() =>
            SaleRep.GetAll();


        [HttpGet("{id}")]
        public ActionResult<Sale> Get(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : GET /Sale/{id}");
            var sale = SaleRep.Get(id);

            if(sale == null)
                return NotFound();

            return sale;
        }
        
        [HttpPost]
        public IActionResult Create(Sale sale)
        {         
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : POST /Sale");   
            // При заполнении сущности SalesData будет автоматически проставлен SaleId!!!
            var id = SaleRep.Add(sale);
            var sale1 = SaleRep.Get(id);
            if(sale1 is null)
                return NotFound();
            foreach (SalesData p in sale1.SalesData)
            {
                p.SaleId = id; 
                SalesDataRep.Add(p);    
            }
            SaleRep.Update(sale); 
            return CreatedAtAction(nameof(Create), new { id = sale.Id }, sale);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Sale sale)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : PUT /Sale/{id}");
            if (id != sale.Id)
                return BadRequest();

            var existingSale = SaleRep.Get(id);
            if(existingSale is null)
                return NotFound();

            SaleRep.Update(sale);           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : DELETE /Sale/{id}");
            var sale = SaleRep.Get(id);

            if (sale is null)
                return NotFound();

            SaleRep.Delete(id);

            return NoContent();
        }
    }
}