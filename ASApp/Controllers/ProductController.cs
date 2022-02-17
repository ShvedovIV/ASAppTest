using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ASApp.Models
{   
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetProduct")]
        //[HttpGet]
        public ActionResult<List<Product>> GetAll() =>
            ProductRep.GetAll();


        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} :GET /Product/{id}");
            var product = ProductRep.Get(id);

            if(product == null)
                return NotFound();

            return product;
        }
        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} :POST /Product");            
            ProductRep.Add(product);
            return CreatedAtAction(nameof(Create), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} :PUT /Product/{id}");
            if (id != product.Id)
                return BadRequest();

            var existingProduct = ProductRep.Get(id);
            if(existingProduct is null)
                return NotFound();

            ProductRep.Update(product);           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()} :DELETE /Product/{id}");
            var product = ProductRep.Get(id);

            if (product is null)
                return NotFound();

            ProductRep.Delete(id);

            return NoContent();
        }
    }
}