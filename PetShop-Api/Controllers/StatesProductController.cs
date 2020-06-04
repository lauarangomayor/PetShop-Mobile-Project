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
    public class StatesProductController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion
        #region Constrcutor
        public StatesProductController (PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion
        #region Method
        [HttpGet("get/{id}")] //http://localhost:5000/StatesProduct/get/1
        public async Task<ActionResult<StateProductModel>> GetStateProduct(long id)
        {
            try {
                var stateProduct = await dBContext.StatesProducts.FindAsync(id);
                if (stateProduct == null){
                    return NotFound();
                }
                return Ok(stateProduct);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        
        [HttpGet("all")]//http://localhost:5000/StatesProduct/all
        public async Task<ActionResult<List<StateProductModel>>> GetAllStateProduct(){
            try {
                var statusProducts = await dBContext.StatesProducts.ToListAsync();
                if (statusProducts.Count() == 0){
                    return NotFound();
                }
                return Ok(statusProducts);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]//http://localhost:5000/StatesProduct/create
        public async Task<ActionResult<StateProductModel>> CreateStateProduct(StateProductModel stateProduct){
            try {
                dBContext.StatesProducts.Add(stateProduct);
                await dBContext.SaveChangesAsync();
                return Ok(stateProduct);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPut("update/{id}")]//http://localhost:5000/StatesProduct/update/2
        public async Task<IActionResult> UpdateStateProduct(StateProductModel stateProduct,long id){
            try {
                if (id != stateProduct.IdStateProduct){
                    return BadRequest();
                }
                dBContext.Entry(stateProduct).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();
                
            }
            catch (Exception e){
                bool stateProductExist = dBContext.StatesProducts.Any(e => e.IdStateProduct == id);
                if (!stateProductExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")] //http://localhost:5000/StatesProduct/delete/1
        public async Task<IActionResult> DeleteStateProduct(long id)
        {
            try {
                var stateProduct = await dBContext.StatesProducts.FindAsync(id);
                if (stateProduct == null){
                    return NotFound();
                }
                dBContext.StatesProducts.Remove(stateProduct);
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
