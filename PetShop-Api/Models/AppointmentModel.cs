using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class AppointmentModel
    {
        [Key]
        public long IdAppointment {get; set;}
        public DateTime Date {get;set;}
        public string Description {get; set;}
        public long IdPet{get;set;}
        public long IdVeterinarian{get;set;}
        public VeterinarianModel Veterinarian {get;set;}
        public PetModel Pet {get;set;}
    }
}