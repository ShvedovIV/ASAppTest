using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASApp.Models
{   
    [Route("Buyer")]
    [ApiController]
    public class BuyerController : ControllerBase
    {

        private readonly ILogger<BuyerController> _logger;

        public BuyerController(ILogger<BuyerController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetBuyer")]
        //[HttpGet]
        public ActionResult<List<Buyer>> GetAll() =>
            BuyerRep.GetAll();


        [HttpGet("{id}")]
        public ActionResult<Buyer> Get(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : GET /Buyer/{id}");
            var buyer = BuyerRep.Get(id);

            if(buyer == null)
                return NotFound();

            return buyer;
        }
        
        [HttpPost]
        public IActionResult Create(Buyer buyer)
        {           
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : POST /Buyer");
            // При заполнении сущности Buyer будет автоматически проставлен BuyerId в Sale!!!
            var id = BuyerRep.Add(buyer);
            var buyer1 = BuyerRep.Get(id);
            if(buyer1 is null)
                return NotFound();
            foreach (Sale s in buyer1.SaleIds)
            { 
                s.BuyerId = id;
                SaleRep.Add(s);   
                var idSale = SaleRep.Add(s);
                var sale1 = SaleRep.Get(idSale);
                if(sale1 is null)
                    return NotFound();
                foreach (SalesData p in sale1.SalesData)
                {
                    p.SaleId = idSale; 
                    SalesDataRep.Add(p);    
                }
                SaleRep.Update(s); 
            }
            BuyerRep.Update(buyer);  
            
            return CreatedAtAction(nameof(Create), new { id = buyer.Id }, buyer);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Buyer buyer)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : PUT /Buyer/{id}");
            if (id != buyer.Id)
                return BadRequest();

            var existingBuyer = BuyerRep.Get(id);
            if(existingBuyer is null)
                return NotFound();

            BuyerRep.Update(buyer);           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : DELETE /Buyer/{id}");
            var buyer = BuyerRep.Get(id);

            if (buyer is null)
                return NotFound();

            BuyerRep.Delete(id);

            return NoContent();
        }
    }
}