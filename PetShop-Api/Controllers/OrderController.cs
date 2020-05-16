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
    [Route("order")]
    public class OrderController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion Properties

        #region Builder 
        public OrderController(PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Builder

        #region Methods 
        [HttpGet("get/{id}")] //http:localhost:5000/order/get/{id}
        public async Task<ActionResult<OrderModel>> GetOrder(long id)
        {
            try
            {
                var order = await dBContext.Orders
                                           .Include(so => so.IdStateOrder)
                                           .Include(u => u.IdUser)
                                           .FirstAsync(o => o.IdOrder == id);
                if (order == null)
                {
                    return NotFound(); //Return code 404
                }
                return Ok(order); //Return code 200
            }
            catch(Exception e)
            {
                return StatusCode(410);//BD Error code
            }
            
          
        }

        [HttpGet("all")] //http:localhost:5000/order/all
        //Return all the order from de DB
        public async Task<ActionResult<List<OrderModel>>> AllOrder()
        {
            try
            {
                return await dBContext.Orders
                                        .Include(so => so.IdStateOrder)
                                        .Include(u => u.IdUser)
                                        .ToListAsync();
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }
          
        }

        [HttpPost("create")] //http:localhost:5000/order/create
        public async Task<ActionResult<OrderModel>> CreateOrder(OrderModel order)
        {
            try
            {
                dBContext.Orders.Add(order);
                await dBContext.SaveChangesAsync();

                return Ok(order);
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }            
        }

        [HttpPut("update/{id}")] //http:localhost:5000/order/update
        public async Task<IActionResult> UpdateOrder(long id, OrderModel order)
        {
            
            try
            {
                if (id != order.IdOrder)
                {
                    return BadRequest();
                }
                else
                {
                    dBContext.Entry(order).State = EntityState.Modified; //
                    await dBContext.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                bool existOrder = dBContext.Orders.Any(e => e.IdOrder == id);
                if (!existOrder)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(410);     
                }
                
            }            
        }

        [HttpDelete("delete/{id}")] //http:localhost:5000/order/delete/id
        public async Task<IActionResult> DeleteOrder(long id)
        {
            
            try
            {
                var order = await dBContext.Orders.FindAsync(id);  
                if (order == null)
                {
                    return NotFound(); //Return code 404
                }
                dBContext.Orders.Remove(order);
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
