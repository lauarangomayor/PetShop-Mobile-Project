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
    public class ClientController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion Properties

        #region Builder 
        public ClientController(PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Builder

        #region Methods 
        [HttpGet("get/{id}")] //http:localhost:5000/user/get/{id}
        public async Task<ActionResult<ClientModel>> GetClient(long id)
        {
            try
            {
                var client = await dBContext.Clients                                                  
                                            .Include(u => u.User)
                                            .FirstAsync(v => v.IdClient == id);
                if (client == null)
                {
                    return NotFound(); //Return code 404
                }
                return Ok(client); //Return code 200
            }
            catch(Exception e)
            {
                return StatusCode(410);//BD Error code
            }
 
        }
        [HttpGet("all")] //http://localhost:5000/client/all
        //Return all the user from de DB
        public async Task<ActionResult<List<ClientModel>>> GetAllClient()
        {
            try
            {
                return await dBContext.Clients
                                      .Include(u => u.User)
                                      .ToListAsync();
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }
          
        }
        
        [HttpPost("registerClient")] //http://localhost:5000/client/registerClient
        public async Task<ActionResult<ClientModel>> RegisterClient(UserModel user)
        {
            try
            {   
                bool existUser = dBContext.Users.Any(e => e.Email == user.Email);
                if (!existUser && user.UserType==1)
                {
                        dBContext.Users.Add(user);
                        await dBContext.SaveChangesAsync();
                        ClientModel client = new ClientModel();   
                        client.IdUser=user.IdUser;                         
                        dBContext.Clients.Add(client);
                        await dBContext.SaveChangesAsync();

                        return Ok(client);

                }
                else
                {
                    return StatusCode(410);     
                }
   
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }            
        }
        


        [HttpPut("update/{id}")] //http:localhost:5000/user/update
        public async Task<IActionResult> UpdateClient(long id, ClientModel client)
        {
            
            try
            {
                if (id != client.IdClient)
                {
                    return BadRequest();
                }
                else
                {
                    dBContext.Entry(client).State = EntityState.Modified; //
                    await dBContext.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                bool existClient = dBContext.Clients.Any(e => e.IdClient == id);
                if (!existClient)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(410);     
                }
                
            }            
        }

        [HttpDelete("delete/{id}")] //http:localhost:5000/user/delete/id
        public async Task<IActionResult> DeleteClient(long id)
        {
            
            try
            {
                var client = await dBContext.Clients.FindAsync(id);  
                if (client == null)
                {
                    return NotFound(); //Return code 404
                }
                dBContext.Clients.Remove(client);
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