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
    public class UserController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion Properties

        #region Builder 
        public UserController(PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Builder

        #region Methods 
        [HttpGet("get/{id}")] //http:localhost:5000/user/get/{id}
        public async Task<ActionResult<UserModel>> GetUser(long id)
        {
            try
            {
                var user = await dBContext.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound(); //Return code 404
                }
                return Ok(user); //Return code 200
            }
            catch(Exception e)
            {
                return StatusCode(410);//BD Error code
            }
            
          
        }

        [HttpGet("all")] //http:localhost:5000/user/all
        //Return all the user from de DB
        public async Task<ActionResult<List<UserModel>>> GetAllUser()
        {
            try
            {
                return await dBContext.Users.ToListAsync();
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }
          
        }


        [HttpPut("update/{id}")] //http:localhost:5000/user/update
        public async Task<IActionResult> UpdateUser(long id, UserModel user)
        {
            
            try
            {
                if (id != user.IdUser)
                {
                    return BadRequest();
                }
                else
                {
                    dBContext.Entry(user).State = EntityState.Modified; //
                    await dBContext.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                bool existUser = dBContext.Users.Any(e => e.IdUser == id);
                if (!existUser)
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
        public async Task<IActionResult> DeleteUser(long id)
        {
            
            try
            {
                var user = await dBContext.Users.FindAsync(id);  
                if (user == null)
                {
                    return NotFound(); //Return code 404
                }
                dBContext.Users.Remove(user);
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
