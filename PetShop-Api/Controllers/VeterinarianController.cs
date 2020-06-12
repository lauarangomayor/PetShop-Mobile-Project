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
    public class VeterinarianController : ControllerBase{
        #region Properties
        private readonly PetshopDBContext dBContext;
        #endregion
        #region Constructor
        public VeterinarianController(PetshopDBContext dBContext){
            this.dBContext = dBContext;
        }
        #endregion
        #region Method
        
        [HttpGet("get/{id}")]
        public async Task<ActionResult<VeterinarianModel>> GetVeterinarian(long id){
            try{
                var veterinarian = await dBContext.Veterinarians
                                                  .Include(u => u.User)
                                                  .FirstAsync(v => v.IdVeterinarian == id);
                if (veterinarian == null){
                    return NotFound();
                }
                return Ok(veterinarian);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
        [HttpGet("getVeterinariansAvailables/{day}&{hour}")]
        public async Task<ActionResult<ProductModel>> GetVeterinariansAvailables(string day,string hour)
        {
            try {
                string date = day + " " + hour;
                DateTime startAppointment = DateTime.ParseExact(date,"MM-dd-y H:mm",null);
                var BusyVets = await dBContext.Appointments
                                                .Where(a => startAppointment<a.Date.AddHours(1) &&
                                                            startAppointment>a.Date.AddHours(-1))
                                                .Join(dBContext.Veterinarians,
                                                      aV => aV.IdVeterinarian,
                                                      v => v.IdVeterinarian,
                                                      (aV, v) => new {v.IdVeterinarian}
                                                     ).ToListAsync();
                List<long> idBusyVets = new List<long>();
                foreach(var v in BusyVets) idBusyVets.Add(v.IdVeterinarian);
                Console.WriteLine(idBusyVets.ToString());
                var veterinarians = await dBContext.Veterinarians.Include(v => v.User).ToListAsync();
                List<VeterinarianModel> vetsAvailables = new List<VeterinarianModel>();
                foreach(VeterinarianModel vet in veterinarians){
                    if(!idBusyVets.Contains(vet.IdVeterinarian)){
                        vetsAvailables.Add(vet);    
                    }
                }
                if (vetsAvailables == null){
                    return NotFound();
                }
                return Ok(vetsAvailables);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }
        [HttpGet("getVeterinariansBySpecialtyId/{id}")]
        public async Task<ActionResult<List<VeterinarianModel>>> GetVeterinariansBySpecialtyId(long id){
          try{
                var veterinarians = await dBContext.Specialties_Vets
                                                  .Where(s => s.IdSpecialty == id)
                                                  .Join(dBContext.Veterinarians,vSV => vSV.IdVeterinarian, v => v.IdVeterinarian,
                                                  (vSV,v)=> new {v.IdVeterinarian,v.IdUser,v.User})
                                                  .ToListAsync();
                if (veterinarians == null){
                    return NotFound();
                }
                return Ok(veterinarians);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<VeterinarianModel>>> GetAllVeterinarians(){
            try {
                var veterinarians = await dBContext.Veterinarians
                                                   .Include(u => u.User)
                                                   .ToListAsync();
                if (veterinarians.Count() == 0){
                    return NotFound();
                }
                return Ok(veterinarians);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("registerVeterinarian")] //http://localhost:5000/Veterinarian/registerVeterinarian
        public async Task<ActionResult<VeterinarianModel>> RegisterVeterinarian(UserModel user)
        {
            try
            {   
                bool existUser = dBContext.Users.Any(e => e.Email == user.Email);
                if (!existUser && user.UserType==0)
                {
                        dBContext.Users.Add(user);
                        await dBContext.SaveChangesAsync();
                        VeterinarianModel vet = new VeterinarianModel();   
                        vet.IdUser=user.IdUser;                         
                        dBContext.Veterinarians.Add(vet);
                        await dBContext.SaveChangesAsync();

                        return Ok(vet);

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
        
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateVeterinarian(VeterinarianModel veterinarian,long id){
            try {
                if (id != veterinarian.IdVeterinarian){
                    return BadRequest();
                }
                dBContext.Entry(veterinarian).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception e){
                bool veterinarianExist = dBContext.Veterinarians.Any(e => e.IdVeterinarian == id);
                if (!veterinarianExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteVeterinarian(long id)
        {
            try {
                var veterinarian = await dBContext.Veterinarians.FindAsync(id);
                if (veterinarian == null){
                    return NotFound();
                }
                dBContext.Veterinarians.Remove(veterinarian);
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