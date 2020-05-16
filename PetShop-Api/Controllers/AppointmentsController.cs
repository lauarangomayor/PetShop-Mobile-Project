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
    public class AppointmentsController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;
        #endregion
        #region Constructor
        public AppointmentsController (PetshopDBContext dBContext){
            this.dBContext = dBContext;
        }
        #endregion
        #region Methods
        [HttpGet("get/{id}")]
        public async Task<ActionResult<AppointmentModel>> GetAppointment(long id){
            try{
                var appointment = await dBContext.Appointments.FindAsync(id);
                if (appointment == null){
                    return NotFound();
                }
                return Ok(appointment);
            }
            catch(Exception e){
                return StatusCode(410);
            }
                
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<AppointmentModel>>> GetAllAppointments(){
            try{
                return await dBContext.Appointments.ToListAsync();
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<AppointmentModel>> CreateAppointment(AppointmentModel appointment){
            try {
                dBContext.Appointments.Add(appointment);
                await dBContext.SaveChangesAsync();
                return Ok(appointment);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateAppointment(AppointmentModel appointment, long id){
            try{
                if (id != appointment.IdAppointment){
                    return BadRequest();
                }
                dBContext.Entry(appointment).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception e){
                bool appoitmentExist = dBContext.Appointments.Any(e => e.IdAppointment == id);
                if (!appoitmentExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAppoitment(long id){
            try{
                var appointment = await dBContext.Appointments.FindAsync(id);
                if (appointment == null){
                    return NotFound();
                }
                dBContext.Appointments.Remove(appointment);
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