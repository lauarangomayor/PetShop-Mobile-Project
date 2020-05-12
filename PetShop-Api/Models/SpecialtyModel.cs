using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class SpecialtyModel
    {
        [Key]
        public long IdSpecialty {get; set;}
        public string Specialty {get; set;}
        public List<Specialties_VetsModel> Specialties_Vets {get;set;}
    }
}