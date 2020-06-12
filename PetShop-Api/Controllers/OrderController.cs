using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop_Api.Controllers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShop_Api.Models;

namespace PetShop_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;
        public ProductController pC;
        #endregion Properties

        #region Builder 
        public OrderController(PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
            this.pC = new ProductController(dBContext);
        }
        #endregion Builder

        #region Methods 
        [HttpGet("get/{id}")] //http:localhost:5000/order/get/{id}
        public async Task<ActionResult<OrderModel>> GetOrder(long id)
        {
            try
            {
                var order = await dBContext.Orders
                                           .Include(so => so.StateOrder)
                                           .Include(c => c.Client)
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

        [HttpGet("getOrdersByClientId/{id}")]
        public async Task<ActionResult<OrderModel>> GetOrdersByClientId(long id)
        {
            try
            {
                var order = await dBContext.Orders
                                           .Where(o => o.IdClient == id)
                                           .Include(so => so.StateOrder)
                                           .Include(c => c.Client)
                                           .ToListAsync();
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
        public async Task<ActionResult<List<OrderModel>>> GetAllOrder()
        {
            try
            {
                return await dBContext.Orders
                                        .Include(so => so.StateOrder)
                                        .Include(c => c.Client) 
                                        .ToListAsync();
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }
          
        }

        [HttpPost("create")] //http:localhost:5000/order/create
        public async Task<ActionResult<OrderModel>> CreateOrder(Object order)
        {
                try
                {
                //Console.WriteLine(order.ToString());
                var jsonString = order.ToString();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                Console.WriteLine(dic["TotalValue"]);
                OrderModel newOrder = Parsing(dic);
                dBContext.Orders.Add(newOrder);
                await dBContext.SaveChangesAsync();
                var idNewOrder = newOrder.IdOrder;
                var listDic = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(dic["Products"].ToString());
                foreach (Dictionary<string,string> d in listDic){
                    Order_ProductsModel newOrder_Product = new Order_ProductsModel();
                    newOrder_Product.IdOrder = idNewOrder;
                    newOrder_Product.IdProduct = long.Parse(d["IdProduct"]);
                    newOrder_Product.QuantityBought = int.Parse(d["QuantityBought"]);
                    ProductModel pm = await pC.GetProductModel(newOrder_Product.IdProduct);
                    pm.QuantityAvailable -= newOrder_Product.QuantityBought;
                    await pC.UpdateProduct(pm,newOrder_Product.IdProduct);
                    dBContext.Orders_Products.Add(newOrder_Product);
                }
                await dBContext.SaveChangesAsync();

                return Ok(order);
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }            
        }
        public OrderModel Parsing(Dictionary<string, object> dic){ 
            OrderModel newOrder = new OrderModel();
            newOrder.OrderDate = DateTime.Parse(dic["OrderDate"].ToString());
            newOrder.TotalValue = double.Parse(dic["TotalValue"].ToString());
            newOrder.IdStateOrder = long.Parse(dic["IdStateOrder"].ToString());
            newOrder.IdClient = long.Parse(dic["IdClient"].ToString());
            return newOrder;

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

        [HttpPost("moveOrderToRecord/{id}")]
        public async Task<IActionResult> MoveOrderToRecord(long id){
            try{
                var order = await dBContext.Orders.FindAsync(id);
                if (order == null){
                    return NotFound();
                }
                // Create a record
                OrderRecordModel or = new OrderRecordModel();
                or.IdOrder = order.IdOrder;
                or.TotalValue = order.TotalValue;
                or.OrderDate = order.OrderDate;
                or.IdClient = order.IdClient;
                dBContext.OrdersRecords.Add(or);

                // Delete from Orders
                dBContext.Orders.Remove(order);
                await dBContext.SaveChangesAsync();
                return Ok(or);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
        #endregion Methods
    }
}
