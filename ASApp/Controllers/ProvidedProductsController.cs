using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace ASApp.Models
{   
    [Route("ProvidedProducts")]
    [ApiController]
    public class ProvidedProductsController : ControllerBase
    {

        private readonly ILogger<ProvidedProductsController> _logger;

        public ProvidedProductsController(ILogger<ProvidedProductsController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetProvidedProducts")]
        //[HttpGet]
        public ActionResult<List<ProvidedProducts>> GetAll() =>
            ProvidedProductsRep.GetAll();


        [HttpGet("{id}")]
        public ActionResult<ProvidedProducts> Get(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : GET /ProvidedProducts/{id}");
            var providedProducts = ProvidedProductsRep.Get(id);

            if(providedProducts == null)
                return NotFound();

            return providedProducts;
        }
        
        [HttpPost]
        public IActionResult Create(ProvidedProducts providedProducts)
        {        
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : POST /ProvidedProducts");    
            ProvidedProductsRep.Add(providedProducts);
            return CreatedAtAction(nameof(Create), new { id = providedProducts.Id }, providedProducts);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, ProvidedProducts providedProducts)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : PUT /ProvidedProducts/{id}");
            if (id != providedProducts.Id)
                return BadRequest();

            var existingprovidedProducts = ProvidedProductsRep.Get(id);
            if(existingprovidedProducts is null)
                return NotFound();

            ProvidedProductsRep.Update(providedProducts);           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} : DELETE /ProvidedProducts/{id}");
            var providedProducts = ProvidedProductsRep.Get(id);

            if (providedProducts is null)
                return NotFound();

            ProvidedProductsRep.Delete(id);

            return NoContent();
        }
    }
}