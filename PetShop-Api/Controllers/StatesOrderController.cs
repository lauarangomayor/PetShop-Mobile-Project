using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShop_Api.Models;

namespace PetShop_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatesOrderController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion Properties

        #region Builder 
        public StatesOrderController(PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Builder

        #region Methods 
        [HttpGet("get/{id}")] //http:localhost:5000/statesOrder/get/{id}
        public async Task<ActionResult<StateOrderModel>> GetStateOrder(long id)
        {
            try
            {
                var stateOrder = await dBContext.StatesOrder.FindAsync(id);  
                if (stateOrder == null)
                {
                    return NotFound(); //Return code 404
                }
                return Ok(stateOrder); //Return code 200
            }
            catch(Exception e)
            {
                return StatusCode(410);//BD Error code
            }
            
          
        }

        [HttpGet("all")] //http:localhost:5000/statesOrder/all
        //Return all the StatesOrder from de DB
        public async Task<ActionResult<List<StateOrderModel>>> GetAllStatesOrder()
        {
            try
            {
                return await dBContext.StatesOrder.ToListAsync();
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }
          
        }

        [HttpPost("create")] //http:localhost:5000/statesOrder/create
        public async Task<ActionResult<StateOrderModel>> CreateStateOrder(StateOrderModel stateOrder)
        {
            try
            {
                dBContext.StatesOrder.Add(stateOrder);
                await dBContext.SaveChangesAsync();

                return Ok(stateOrder);
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }            
        }

        [HttpPut("update/{id}")] //http:localhost:5000/statesOrder/update
        public async Task<IActionResult> UpdateStateOrder(long id, StateOrderModel stateOrder)
        {
            
            try
            {
                if (id != stateOrder.IdStateOrder)
                {
                    return BadRequest();
                }
                else
                {
                    dBContext.Entry(stateOrder).State = EntityState.Modified; //
                    await dBContext.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                bool existStateOrder = dBContext.StatesOrder.Any(e => e.IdStateOrder == id);
                if (!existStateOrder)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(410);     
                }
                
            }            
        }

        [HttpDelete("delete/{id}")] //http:localhost:5000/statesOrder/delete/id
        public async Task<IActionResult> DeleteStateOrder(long id)
        {
            
            try
            {
                var stateOrder = await dBContext.StatesOrder.FindAsync(id);  
                if (stateOrder == null)
                {
                    return NotFound(); //Return code 404
                }
                dBContext.StatesOrder.Remove(stateOrder);
                await dBContext.SaveChangesAsync();
                return NoContent(); //Return code 204 
            }
            catch(Exception e)
            {
                return StatusCode(410);                    
            }            
        }
        #endregion Methods
    }
}
