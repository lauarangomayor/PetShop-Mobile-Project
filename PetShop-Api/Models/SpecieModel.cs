using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace PetShop_Api.Models
{
    public class SpecieModel
    {
        [Key]
        public long IdSpecie {get; set;}
        public string Specie {get; set;}
        [IgnoreDataMember]
        public List<PetModel> Pets {get;set;} 
    }
}