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
    public class WishListProducts : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion
        #region Constrcutor
        public WishListProducts (PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion
        #region Method
        [HttpGet("get/{id}")] //http://localhost:5000/WishListProducts/get/1
        public async Task<ActionResult<WishList_ProductsModel>> GetWishListProduct(long id)
        {
            try {
                var WishListProduct = await dBContext.WishLists_Products.FindAsync(id);
                if (WishListProduct == null){
                    return NotFound();
                }
                return Ok(WishListProduct);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        
        [HttpGet("all")]//http://localhost:5000/WishListProducts/all
        public async Task<ActionResult<List<WishList_ProductsModel>>> GetAllWishListProducts(){
            try {
                var WishListProducts = await dBContext.WishLists_Products.ToListAsync();
                if (WishListProducts.Count() == 0){
                    return NotFound();
                }
                return Ok(WishListProducts);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]//http://localhost:5000/WishListProducts/create
        public async Task<ActionResult<WishList_ProductsModel>> PostWishListProduct(WishList_ProductsModel WishListProduct){
            try {
                dBContext.WishLists_Products.Add(WishListProduct);
                await dBContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetWishListProduct), WishListProduct.IdWishList_Products);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPut("update/{id}")]//http://localhost:5000/WishListProducts/update/2
        public async Task<IActionResult> UpdateWishListProduct(WishList_ProductsModel WishListProduct,long id){
            try {
                if (id != WishListProduct.IdWishList_Products){
                    return BadRequest();
                }
                dBContext.Entry(WishListProduct).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();
                
            }
            catch (Exception e){
                bool WishListProductExist = dBContext.WishLists_Products.Any(e => e.IdWishList_Products == id);
                if (!WishListProductExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")] //http://localhost:5000/WishListProducts/delete/1
        public async Task<IActionResult> DeleteWishListProduct(long id)
        {
            try {
                var WishListProduct = await dBContext.WishLists_Products.FindAsync(id);
                if (WishListProduct == null){
                    return NotFound();
                }
                dBContext.WishLists_Products.Remove(WishListProduct);
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
