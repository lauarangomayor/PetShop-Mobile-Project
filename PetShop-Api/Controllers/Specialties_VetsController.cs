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
    public class Specialties_VetsController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion Properties

        #region Builder 
        public Specialties_VetsController(PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Builder

        #region Methods 
        [HttpGet("get/{id}")] 
        public async Task<ActionResult<Specialties_VetsModel>> GetSpecialties_Vet(long id)
        {
            try
            {
                var specialties_vets= await dBContext.Specialties_Vets
                                           .Include(s => s.Specialty)
                                           .Include(s => s.Veterinarian)
                                           .FirstAsync(sv => sv.IdSpecialties_Vets == id);
                if (specialties_vets == null)
                {
                    return NotFound(); 
                }
                return Ok(specialties_vets); 
            }
            catch(Exception e)
            {
                return StatusCode(410);
            }
            
          
        }

        [HttpGet("all")] 
        public async Task<ActionResult<List<Specialties_VetsModel>>> GetAllSpecialties_Vets()
        {
            try
            {
                return await dBContext.Specialties_Vets
                                            .Include(s => s.Specialty)
                                            .Include(s => s.Veterinarian)
                                            .ToListAsync();
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }
          
        }

        [HttpPost("create")] 
        public async Task<ActionResult<Specialties_VetsModel>> CreateSpecialties_Vets(Specialties_VetsModel specialties_vets)
        {
            try
            {
                dBContext.Specialties_Vets.Add(specialties_vets);
                await dBContext.SaveChangesAsync();

                return Ok(specialties_vets);
            }
            catch(Exception e)
            {
                return StatusCode(410);     
            }            
        }

        [HttpPut("update/{id}")] 
        public async Task<IActionResult> UpdateSpecialties_Vets(long id, Specialties_VetsModel specialties_vets)
        {
            
            try
            {
                if (id != specialties_vets.IdSpecialties_Vets)
                {
                    return BadRequest();
                }
                else
                {
                    dBContext.Entry(specialties_vets).State = EntityState.Modified; 
                    await dBContext.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                bool existSpecialties_vets = dBContext.Specialties_Vets.Any(e => e.IdSpecialties_Vets == id);
                if (!existSpecialties_vets)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(410);     
                }
                
            }            
        }

        [HttpDelete("delete/{id}")] 
        public async Task<IActionResult> DeleteSpecialties_Vets(long id)
        {
            
            try
            {
                var specialties_vets = await dBContext.Specialties_Vets.FindAsync(id);  
                if (specialties_vets == null)
                {
                    return NotFound(); 
                }
                dBContext.Specialties_Vets.Remove(specialties_vets);
                await dBContext.SaveChangesAsync();
                return NoContent(); 
            }
            catch(Exception e)
            {
                return StatusCode(410);                    
            }            
        }
        #endregion Methods
    }
}
