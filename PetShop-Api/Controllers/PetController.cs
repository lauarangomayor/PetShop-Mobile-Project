using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetShop_Api.Models;

namespace PetShop_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;
        #endregion
        #region Constructor
        public PetController(PetshopDBContext dBContext){
            this.dBContext = dBContext;
        }
        #endregion
        #region Methods
        [HttpGet("get/{id}")]
        public async Task<ActionResult<PetModel>> GetPet(long id){
            try{
                var pet = await dBContext.Pets
                                        .Include(c => c.Client)
                                        .Include(s => s.Specie)
                                        .FirstAsync(p => p.IdPet == id);
                if (pet == null){
                    return NotFound();
                }
                return Ok(pet);
            }
            catch(Exception e){
                return StatusCode(410);
            }
                
        }

        [HttpGet("getPetsByClientId/{id}")]
        public async Task<ActionResult<OrderModel>> GetPetsByClientId(long id)
        {
            try
            {
                var pets = await dBContext.Pets
                                           .Where(p => p.IdClient == id)
                                           .Include(s => s.Specie)
                                           .ToListAsync();
                if (pets == null)
                {
                    return NotFound();
                }
                return Ok(pets);
            }
            catch(Exception e)
            {
                return StatusCode(410);
            }          
        }

        [HttpGet("getPetsResumeByClientId/{id}")]
        public async Task<ActionResult<List<JsonObject>>> GetPetsResume(long id)
        {
            try{
                var pets = await dBContext.Pets
                                    .Where(p => p.IdClient == id)
                                    .Select(p => new { p.IdPet, p.Name })
                                    .ToListAsync();
                if (pets == null)
                {
                    return NotFound();
                }
                return Ok(pets);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<PetModel>>> GetAllPets(){
            try{
                return await dBContext.Pets
                                    .Include(c => c.Client)
                                    .Include(s => s.Specie)
                                    .ToListAsync();
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<PetModel>> CreatePet(PetModel pet){
            try {
                dBContext.Pets.Add(pet);
                await dBContext.SaveChangesAsync();
                return Ok(pet);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdatePet(PetModel pet, long id){
            try{
                if (id != pet.IdPet){
                    return BadRequest();
                }
                dBContext.Entry(pet).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception e){
                bool petExist = dBContext.Pets.Any(e => e.IdPet == id);
                if (!petExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePet(long id){
            try{
                var pet = await dBContext.Pets.FindAsync(id);
                if (pet == null){
                    return NotFound();
                }
                dBContext.Pets.Remove(pet);
                await dBContext.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
        #endregion
    }
}