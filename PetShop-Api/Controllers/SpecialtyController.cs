using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShop_Api.Models;

namespace PetShop_Api.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class SpecialtyController : ControllerBase{
        #region Properties
        private readonly PetshopDBContext dBContext;
        #endregion
        #region Constructor
        public SpecialtyController(PetshopDBContext dBContext){
            this.dBContext = dBContext;
        }
        #endregion
        #region Method
        [HttpGet("get/{id}")]
        public async Task<ActionResult<SpecialtyModel>> GetSpecialty(long id){
            try{
                var specialty = await dBContext.Specialties.FindAsync(id);
                if (specialty == null){
                    return NotFound();
                }
                return Ok(specialty);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<SpecialtyModel>>> GetAllSpecialties(){
            try{
                return await dBContext.Specialties.ToListAsync();
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult<SpecialtyModel>> CreateSpecialty(SpecialtyModel specialty){
            try {
                dBContext.Specialties.Add(specialty);
                await dBContext.SaveChangesAsync();
                return Ok(specialty);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSpecialty(SpecialtyModel specialty,long id){
            try {
                if (id != specialty.IdSpecialty){
                    return BadRequest();
                }
                dBContext.Entry(specialty).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception e){
                bool specialtyExist = dBContext.Specialties.Any(e => e.IdSpecialty == id);
                if (!specialtyExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSpecialty(long id)
        {
            try {
                var specialty = await dBContext.Specialties.FindAsync(id);
                if (specialty == null){
                    return NotFound();
                }
                dBContext.Specialties.Remove(specialty);
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