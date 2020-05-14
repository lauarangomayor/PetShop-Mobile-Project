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
    public class AppointmentRecordController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;
        #endregion
        #region Constructor
        public AppointmentRecordController (PetshopDBContext dBContext){
            this.dBContext = dBContext;
        }
        #endregion
        #region Methods
        [HttpGet("get/{id}")]
        public async Task<ActionResult<AppointmentRecord>> GetAppointmentRecord(long id){
            try{
                var appointmentRecord = await dBContext.AppointmentsRecords.FindAsync(id);
                if (appointmentRecord == null){
                    return NotFound();
                }
                return Ok(appointmentRecord);
            }
            catch(Exception e){
                return StatusCode(410);
            }
                
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<AppointmentRecord>>> GetAllAppointmentRecords(){
            try{
                return await dBContext.AppointmentsRecords.ToListAsync();
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<AppointmentRecord>> CreateAppointment(AppointmentRecord appointmentRecord){
            try {
                dBContext.AppointmentsRecords.Add(appointmentRecord);
                await dBContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAppointmentRecord), appointmentRecord.IdAppointmentRecord);
            }
            catch(Exception e){
                return StatusCode(410);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateAppointmentRecord(AppointmentRecord appointmentRecord, long id){
            try{
                if (id != appointmentRecord.IdAppointmentRecord){
                    return BadRequest();
                }
                dBContext.Entry(appointmentRecord).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception e){
                bool appoitmentRecordExist = dBContext.AppointmentsRecords.Any(e => e.IdAppointmentRecord == id);
                if (appoitmentRecordExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AppointmentModel>> DeleteAppoitmentRecord(long id){
            try{
                var appointmentRecord = await dBContext.AppointmentsRecords.FindAsync(id);
                if (appointmentRecord == null){
                    return NotFound();
                }
                dBContext.AppointmentsRecords.Remove(appointmentRecord);
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