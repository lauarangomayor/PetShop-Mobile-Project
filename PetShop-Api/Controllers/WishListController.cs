using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShop_Api.Models;

namespace PetShop_Api.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class WishListController : ControllerBase{
        #region Properties
        private readonly PetshopDBContext dBContext;
        #endregion
        #region Constructor
        public WishListController(PetshopDBContext dBContext){
            this.dBContext = dBContext;
        }
        #endregion
        #region Method
        [HttpGet("get/{id}")]
        public async Task<ActionResult<WishListModel>> GetWishList(long id){
            try{
                var wishList = await dBContext.WishLists
                                              .Include(c => c.Client)
                                              .FirstAsync(w => w.IdWishList == id);
                if (wishList == null){
                    return NotFound();
                }
                return Ok(wishList);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<WishListModel>>> GetAllWishLists(){
            try {
                var wishLists = await dBContext.WishLists
                                               .Include(c => c.Client)
                                               .ToListAsync();
                if (wishLists.Count() == 0){
                    return NotFound();
                }
                return Ok(wishLists);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult<WishListModel>> CreateWishList(WishListModel wishList){
            try {
                dBContext.WishLists.Add(wishList);
                await dBContext.SaveChangesAsync();
                return Ok(wishList);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateWishList(WishListModel wishList,long id){
            try {
                if (id != wishList.IdWishList){
                    return BadRequest();
                }
                dBContext.Entry(wishList).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception e){
                bool wishListExist = dBContext.WishLists.Any(e => e.IdWishList == id);
                if (!wishListExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteWishList(long id)
        {
            try {
                var wishList = await dBContext.WishLists.FindAsync(id);
                if (wishList == null){
                    return NotFound();
                }
                dBContext.WishLists.Remove(wishList);
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