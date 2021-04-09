using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBCExample.Models;

namespace NBCexample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products/5/priceHistory
        [HttpGet("{id}/priceHistory")]
        public async Task<ActionResult<ProductPriceHistory>> GetPriceHistory(long id)
        {
            var histories = await _context.PriceHistories.Where(p => p.ProductId == id).ToListAsync();
            var product = await _context.Products.FindAsync(id);

            if (histories.Count == 0 || product == null)
            {
                return NoContent();
            }

            return new ProductPriceHistory(product, histories);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var productEntity = _context.Entry(product);

            productEntity.State = EntityState.Modified;

            var history = new PriceHistory();
            history.ProductId = id;
            history.Date = DateTime.UtcNow;
            history.NewPrice = product.Price;

            _context.PriceHistories.Add(history);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            product.Created = DateTime.UtcNow;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            
            var history = new PriceHistory();
            history.ProductId = product.Id;
            history.Date = DateTime.UtcNow;
            history.NewPrice = product.Price;
            _context.PriceHistories.Add(history);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
