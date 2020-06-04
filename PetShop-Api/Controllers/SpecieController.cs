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
    public class SpecieController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion
        #region Constrcutor
        public SpecieController (PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion
        #region Method
        [HttpGet("get/{id}")]
        public async Task<ActionResult<SpecieModel>> GetSpecie(long id)
        {
            try {
                var specie = await dBContext.Species.FindAsync(id);
                if (specie == null){
                    return NotFound();
                }
                return Ok(specie);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        } 

        [HttpGet("all")]
        public async Task<ActionResult<List<SpecieModel>>> GetAllSpecies(){
            try {
                var species = await dBContext.Species.ToListAsync();
                if (species.Count() == 0){
                    return NotFound();
                }
                return Ok(species);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<SpecieModel>> CreateSpecie(SpecieModel specie){
            try {
                dBContext.Species.Add(specie);
                await dBContext.SaveChangesAsync();
                return Ok(specie);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSpecie(SpecieModel specie,long id){
            try {
                if (id != specie.IdSpecie){
                    return BadRequest();
                }
                dBContext.Entry(specie).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();
                
            }
            catch (Exception e){
                bool specieExist = dBContext.Species.Any(e => e.IdSpecie == id);
                if (!specieExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSpecie(long id)
        {
            try {
                var specie = await dBContext.Species.FindAsync(id);
                if (specie == null){
                    return NotFound();
                }
                dBContext.Species.Remove(specie);
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