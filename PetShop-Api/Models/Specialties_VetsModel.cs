using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class Specialties_VetsModel
    {
        [Key]
        public long IdSpecialties_Vets {get; set;}
        public long IdVeterinarian{get;set;}
        public VeterinarianModel Veterinarian {get;set;}
        public long IdSpecialty{get;set;}
        public SpecialtyModel Specialty {get; set;}
        
    }
}