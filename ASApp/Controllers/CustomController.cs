using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ASApp.Models
{   
    [Route("Custom")]
    [ApiController]
    public class CustomController : ControllerBase
    {

        private readonly ILogger<CustomController> _logger;

        public CustomController(ILogger<CustomController> logger)
        {
            _logger = logger;
        }

       
        [HttpGet]
        public ActionResult<List<Sale>> GetAll() =>
            SaleRep.GetAll();


        [HttpGet("{id}")]
        public ActionResult<Sale> Get(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : GET /Custom/{id}");
            var sale = SaleRep.Get(id);

            if(sale == null)
                return NotFound();

            return sale;
        }

        [HttpPost]
        public IActionResult Create(Sale sale)
        {         
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : POST /Custom");
            var SalesPoint1 = SalesPointRep.Get(sale.SalesPointId);
            if(SalesPoint1 is null)
                return NotFound();
            if(SalesPoint1.ProvidedProducts is null)
                return NotFound();
            foreach (SalesData s in sale.SalesData)
            {
                foreach (ProvidedProducts p in SalesPoint1.ProvidedProducts)
                {
                    if (s.ProductId == p.ProductId)
                    {
                        if (p.ProductQuantity>= s.ProductQuantity)
                        {
                            p.ProductQuantity -= s.ProductQuantity;
                            ProvidedProductsRep.Update(p);
                            SalesPointRep.Update(SalesPoint1);
                            SaleRep.Add(sale);
                            var user = sale.BuyerId;
                            if (user is null)
                                return CreatedAtAction(nameof(Create), new { id = sale.Id }, sale);

                            var user1 = BuyerRep.Get(Convert.ToInt32(user));
                            if (user1 is null)
                                return CreatedAtAction(nameof(Create), new { id = sale.Id }, sale);

                            user1.SaleIds.Add(sale);

                        }
                    }

                }
            }
            return CreatedAtAction(nameof(Create), new { id = sale.Id }, sale);
        }
        
        
    }
}