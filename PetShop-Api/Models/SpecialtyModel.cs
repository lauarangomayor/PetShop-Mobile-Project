using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace PetShop_Api.Models
{
    public class SpecialtyModel
    {
        [Key]
        public long IdSpecialty {get; set;}
        public string Specialty {get; set;}
        [IgnoreDataMember]
        public List<Specialties_VetsModel> Specialties_Vets {get;set;}
    }
}