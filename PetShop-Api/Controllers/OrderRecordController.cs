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
    public class OrderRecordController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion Properties

        #region Builder 
        public OrderRecordController(PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Builder

        #region Methods 
        [HttpGet("get/{id}")] //http:localhost:5000/orderRecord/get/{id}
        public async Task<ActionResult<OrderRecordModel>> GetOrderRecord(long id)
        {
            try
            {
                var orderRecord = await dBContext.OrdersRecords.FindAsync(id);
                if (orderRecord == null)
                {
                    return NotFound(); //Return code 404
                }
                return Ok(orderRecord); //Return code 200
            }
            catch(Exception e)
            {
                return StatusCode(410);//BD Error code
            }            
        }
        [HttpGet("getSalesByTimePeriod/{date1}&{date2}")] //http://localhost:5000/orderRecord/getSalesByTimePeriod/01.01.2010&01.01.2015
        public async Task<ActionResult<OrderRecordModel>> GetSalesByTimePeriod(String date1,String date2)
        {
            try
            {
                var orderRecord = await dBContext.OrdersRecords
                                           .Where(or => or.OrderDate > DateTime.Parse(date1) && 
                                                        or.OrderDate < DateTime.Parse(date2))
                                           .ToListAsync();
                if (orderRecord == null)
                {
                    return NotFound(); //Return code 404
                }
                return Ok(orderRecord); //Return code 200
            }
            catch(Exception e)
            {
                return StatusCode(410);//BD Error code
            }
            
          
        }
        [HttpGet("getOrdersRecordByClientId/{id}")]
        public async Task<ActionResult<OrderRecordModel>> GetOrdersRecordByClientId(long id)
        {
            try
            {
                var orderRecord = await dBContext.OrdersRecords
                                           .Where(or => or.IdClient == id)
                                           .ToListAsync();
                if (orderRecord == null)
                {
                    return NotFound(); //Return code 404
                }
                return Ok(orderRecord); //Return code 200
            }
            catch(Exception e)
            {
                return StatusCode(410);//BD Error code
            }
            
          
        }

        [HttpGet("all")] //http:localhost:5000/order/all
        //Return all the order from de DB
        public async Task<ActionResult<List<OrderRecordModel>>> GetAllOrderRecord()
        {
            try
            {
                return await dBContext.OrdersRecords.ToListAsync();
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }
          
        }

        [HttpPost("create")] //http:localhost:5000/order/create
        public async Task<ActionResult<OrderRecordModel>> CreateOrderRecord(OrderRecordModel orderrecord)
        {
            try
            {
                dBContext.OrdersRecords.Add(orderrecord);
                await dBContext.SaveChangesAsync();

                return Ok(orderrecord);
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }            
        }

        [HttpDelete("delete/{id}")] //http:localhost:5000/orderrecord/delete/id
        public async Task<IActionResult> DeleteOrderRecord(long id)
        {
            
            try
            {
                var orderrecord = await dBContext.OrdersRecords.FindAsync(id);  
                if (orderrecord == null)
                {
                    return NotFound(); //Return code 404
                }
                dBContext.OrdersRecords.Remove(orderrecord);
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
