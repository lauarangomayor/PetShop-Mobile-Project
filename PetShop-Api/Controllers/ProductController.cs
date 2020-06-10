using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop_Api.Models;
using Newtonsoft.Json;

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

        public async Task<ProductModel> GetProductModel(long id){ //Trae la categoria asociada a el producto con ese id
            try{
                var product = await dBContext.Products
                                                    .Include(c => c.Category)
                                                    .Include(sp => sp.StateProduct)
                                                    .FirstAsync(p => p.IdProduct == id);
                return product;
            }
            catch(Exception e){
                Console.WriteLine(e);
                return null;
            }
        }

        [HttpGet("getWishListProductsByClientId/{id}")]
        public async Task<ActionResult<ProductModel>> GetWishListProductsByClientId(long id)
        {
            try {
                
                var idWishlist =  await dBContext.WishLists
                                           .Where(w => w.IdClient == id)
                                           .Select(w => w.IdWishList).FirstAsync();

                var products = await dBContext.WishLists_Products
                                                .Where(wp => wp.IdWishList == idWishlist)
                                                .Join(dBContext.Products,
                                                      pWP => pWP.IdProduct,
                                                      p => p.IdProduct,
                                                      (pWP, p) => new {p.IdProduct,p.Name,p.Description,
                                                                       p.IdCategory,p.Category,p.QuantityAvailable, 
                                                                       p.UnitPrice, p.IdStateProduct,p.StateProduct}
                                                     ).ToListAsync();
                if (products == null){
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpGet("getOrderProductsByOrderId/{id}")]
        public async Task<ActionResult<ProductModel>> GetOrderProductsByOrderId(long id)
        {
            try {
                var products = await dBContext.Orders_Products
                                                .Where(op => op.IdOrder == id)
                                                .Join(dBContext.Products,
                                                      pOP => pOP.IdProduct,
                                                      p => p.IdProduct,
                                                      (pOP, p) => new {p.IdProduct,p.Name,p.Description,
                                                                       p.IdCategory,p.Category,p.QuantityAvailable, 
                                                                       p.UnitPrice, p.IdStateProduct,p.StateProduct}
                                                     ).ToListAsync();
                if (products == null){
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpGet("GetProductsByStateId/{id}")]
        public async Task<ActionResult<ProductModel>> GetProductsByStateId(long id) //Trae todos los productos con ese id estado 
        {
            try {
                var products = await dBContext.Products
                                             .Where(p => p.IdStateProduct == id)
                                             .Include(c => c.StateProduct)
                                             .Include(sp => sp.Category)
                                             .ToListAsync();
                if (products == null){
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        
        [HttpGet("getProductsByCategoryId/{id}")]
        public async Task<ActionResult<ProductModel>> GetProductsByCategoryId(long id) //Trae todos los productos con ese id categoria
        {
            try {
                var products = await dBContext.Products
                                             .Where(p => p.IdCategory == id)
                                             .Include(c => c.Category)
                                             .Include(sp => sp.StateProduct)
                                             .ToListAsync();
                if (products == null){
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }   
    
        [HttpGet("getProductsResume/{id}")]
        public async Task<ActionResult<ProductModel>> GetProductsResume() //Trae el resumen (id, foto, nombre, precio) de todos los productos
        {
            try {

                var products = await dBContext.Products
                                                .Select(p => new {p.Name,p.Description,p.QuantityAvailable, 
                                                        p.UnitPrice}
                                                     ).ToListAsync();
                if (products == null){
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("getProductsByListId")]
        public async Task<ActionResult<List<ProductModel>>> GetProductsByListId(IdProductListModel listIdsEntry){
            try {
                //Console.WriteLine(listIdsEntry.ToString());
                
                //var jsonString = listIdsEntry.ToString();
                //var dic = JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsonString);
                var listIds = new List<long>(listIdsEntry.IdProducts);
                //List<long> listIds = dic.Values.ToList();
                
                //onsole.WriteLine(listIds);
                //var listIds = JsonConvert.DeserializeObject<List<string>>(dic["IdProducts"].ToString);
                
                //Console.WriteLine(listIds);
                /*var products = await dBContext.Products
                                               .Join(listIds,
                                                     p => p.IdProduct,
                                                     id => id,
                                                     (p,id)=> new {p.IdProduct, p.Name, p.ImagePath}).ToListAsync();*/
                
                var products = await dBContext.Products
                                              .Where(p => listIds.Contains(p.IdProduct))
                                              .Select(p => new{p.IdProduct, p.Name, p.ImagePath, p.UnitPrice})
                                              .ToListAsync();
                 if (products == null){
                         return NotFound();
                     }
                    return Ok(products);
            }
            catch (Exception e){
                Console.WriteLine(e);
                return StatusCode(410);
            }
            
            
        }

        [HttpGet("all")]//http://localhost:5000/Product/all
        public async Task<ActionResult<List<ProductModel>>> GetAllProducts(){
            try {
                return await dBContext.Products
                                              .Include(c => c.Category)
                                              .Include(sp => sp.StateProduct)
                                              .ToListAsync();
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]//http://localhost:5000/Product/create
        public async Task<ActionResult<ProductModel>> CreateProduct(ProductModel product){
            try {
                dBContext.Products.Add(product);
                await dBContext.SaveChangesAsync();
                return Ok(product);
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
