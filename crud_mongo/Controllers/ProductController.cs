using crud_mongo.Models;
using crud_mongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _productServices;

        public ProductController(ProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<List<ProductModel>> Get() => await _productServices.GetAsync(); 

        [HttpPost]
        public async Task<IActionResult> Post(ProductModel newProduct)
        {
            await _productServices.CreateAsync(newProduct); 
            return CreatedAtAction(nameof(Get), new { id = newProduct.id }, newProduct);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ProductModel updatedProduct)
        {
            var product = await _productServices.GetAsync(id); 
            
            if (product is null)
            {
                return NotFound();
            }
            updatedProduct.id = product.id; await _productServices.UpdateAsync(id, updatedProduct); 
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productServices.GetAsync(id); 
            
            if (product is null)
            {
                return NotFound();
            }
            await _productServices.RemoveAsync(id); 
            return NoContent();
        }

    }
}
