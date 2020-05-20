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
    public class Order_ProductsController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion Properties

        #region Builder 
        public Order_ProductsController(PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Builder

        #region Methods 
        [HttpGet("get/{id}")] //http:localhost:5000/order_products/get/{id}
        public async Task<ActionResult<Order_ProductsModel>> GetOrder_Products(long id)
        {
            try
            {
                var order_products = await dBContext.Orders_Products
                                                    .Include(p => p.Product)
                                                    .FirstAsync(op => op.IdOrder_Products == id);
                if (order_products == null)
                {
                    return NotFound(); //Return code 404
                }
                return Ok(order_products); //Return code 200
            }
            catch(Exception e)
            {
                return StatusCode(410);//BD Error code
            }
            
          
        }

        [HttpGet("all")] //http:localhost:5000/order_products/all
        //Return all the orders_products from de DB
        public async Task<ActionResult<List<Order_ProductsModel>>> GetAllOrder_Products()
        {
            try
            {
                return await dBContext.Orders_Products
                                        .Include(p => p.Product)
                                        .ToListAsync();
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }
          
        }

        [HttpPost("create")] //http:localhost:5000/order_products/create
        public async Task<ActionResult<Order_ProductsModel>> CreateOrder_Products(Order_ProductsModel order_products)
        {
            try
            {
                dBContext.Orders_Products.Add(order_products);
                await dBContext.SaveChangesAsync();

                return Ok(order_products);
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }            
        }

        [HttpPut("update/{id}")] //http:localhost:5000/order_products/update
        public async Task<IActionResult> UpdateOrder_Products(long id, Order_ProductsModel order_Products)
        {
            
            try
            {
                if (id != order_Products.IdOrder_Products)
                {
                    return BadRequest();
                }
                else
                {
                    dBContext.Entry(order_Products).State = EntityState.Modified; //
                    await dBContext.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                bool existOrder_Products = dBContext.Orders_Products.Any(e => e.IdOrder_Products == id);
                if (!existOrder_Products)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(410);     
                }
                
            }            
        }

        [HttpDelete("delete/{id}")] //http:localhost:5000/order_Products/delete/id
        public async Task<IActionResult> DeleteOrder_Products(long id)
        {
            
            try
            {
                var order_Products = await dBContext.Orders_Products.FindAsync(id);  
                if (order_Products == null)
                {
                    return NotFound(); //Return code 404
                }
                dBContext.Orders_Products.Remove(order_Products);
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
