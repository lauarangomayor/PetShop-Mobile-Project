using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class AppointmentRecordModel
    {
        [Key]
        public long IdAppointmentRecord {get; set;}
        public long  IdAppointment {get;set;}
        public DateTime AppointmentDate {get; set;}
        public long IdVet {get;set;}
        public long IdPet{get;set;}
        public string abstractAppointment{get;set;}
    }
}