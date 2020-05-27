using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop_Api.Models;

namespace PetShop_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion
        #region Constrcutor
        public ProductController (PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion
        #region Method

        [HttpGet("get/{id}")] //http://localhost:5000/Product/get/1
        public async Task<ActionResult<ProductModel>> GetProduct(long id){ //Trae la categoria asociada a el producto con ese id
            try{
                var product = await dBContext.Products
                                                    .Include(c => c.Category)
                                                    .Include(sp => sp.StateProduct)
                                                    .FirstAsync(p => p.IdProduct == id);
                if (product == null){
                    return NotFound();
                }
                return Ok(product);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
    
        [HttpGet("getProductsByCategoryId/{id}")]
        public async Task<ActionResult<ProductModel>> GetProductsByCategoryId(long id)
        {
            try {
                var product = await dBContext.Products
                                             .Where(p => p.IdCategory == id)
                                             .Include(c => c.Category)
                                             .Include(sp => sp.StateProduct)
                                             .ToListAsync();
                if (product == null){
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpGet("all")]//http://localhost:5000/Product/all
        public async Task<ActionResult<List<ProductModel>>> GetAllProducts(){
            try {
                var products = await dBContext.Products
                                              .Include(c => c.Category)
                                              .Include(sp => sp.StateProduct)
                                              .ToListAsync();
                if (products.Count() == 0){
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]//http://localhost:5000/Product/create
        public async Task<ActionResult<ProductModel>> PostProduct(ProductModel product){
            try {
                dBContext.Products.Add(product);
                await dBContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProduct), product.IdProduct);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPut("update/{id}")]//http://localhost:5000/Product/update/2
        public async Task<IActionResult> UpdateProduct(ProductModel product,long id){
            try {
                if (id != product.IdProduct){
                    return BadRequest();
                }
                dBContext.Entry(product).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();
                
            }
            catch (Exception e){
                bool productExist = dBContext.Products.Any(e => e.IdProduct == id);
                if (!productExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")] //http://localhost:5000/Product/delete/1
        public async Task<IActionResult> DeleteProduct(long id)
        {
            try {
                var product = await dBContext.Products.FindAsync(id);
                if (product == null){
                    return NotFound();
                }
                dBContext.Products.Remove(product);
                await dBContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }
        

        #endregion

    }
}
