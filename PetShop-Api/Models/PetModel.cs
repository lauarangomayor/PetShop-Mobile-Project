using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class PetModel
    {
        [Key]
        public long IdPet {get; set;}
        public string Name {get; set;}
        public SpecieModel Specie {get;set;}
        public string GeneralInfo{get;set;}
        public DateTime Birthdate{get;set;}
        public UserModel User {get;set;}

        public List<AppointmentModel> Appointments{get;set;}

        
        
    }
}