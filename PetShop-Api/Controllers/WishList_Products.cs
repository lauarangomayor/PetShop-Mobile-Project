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
    public class WishList_ProductsController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion
        #region Constrcutor
        public WishList_ProductsController (PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion
        #region Method
        [HttpGet("get/{id}")] //http://localhost:5000/WishList_Productss/get/1
        public async Task<ActionResult<WishList_ProductsModel>> GetWishList_Products(long id)
        {
            try {
                var wishList_product = await dBContext.WishLists_Products.FindAsync(id);
                if (wishList_product == null){
                    return NotFound();
                }
                return Ok(wishList_product);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        
        [HttpGet("all")]//http://localhost:5000/WishList_Productss/all
        public async Task<ActionResult<List<WishList_ProductsModel>>> GetAllWishList_Productss(){
            try {
                var wishList_products = await dBContext.WishLists_Products.ToListAsync();
                if (wishList_products.Count() == 0){
                    return NotFound();
                }
                return Ok(wishList_products);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]//http://localhost:5000/WishList_Productss/create
        public async Task<ActionResult<WishList_ProductsModel>> PostWishList_Products(WishList_ProductsModel wishList_products){
            try {
                dBContext.WishLists_Products.Add(wishList_products);
                await dBContext.SaveChangesAsync();
                return Ok(wishList_products);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPut("update/{id}")]//http://localhost:5000/WishList_Productss/update/2
        public async Task<IActionResult> UpdateWishList_Products(WishList_ProductsModel wishList_products,long id){
            try {
                if (id != wishList_products.IdWishList_Products){
                    return BadRequest();
                }
                dBContext.Entry(wishList_products).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();
                
            }
            catch (Exception e){
                bool wishList_productsExist = dBContext.WishLists_Products.Any(e => e.IdWishList_Products == id);
                if (!wishList_productsExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")] //http://localhost:5000/WishList_Productss/delete/1
        public async Task<IActionResult> DeleteWishList_Products(long id)
        {
            try {
                var wishList_products = await dBContext.WishLists_Products.FindAsync(id);
                if (wishList_products == null){
                    return NotFound();
                }
                dBContext.WishLists_Products.Remove(wishList_products);
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
