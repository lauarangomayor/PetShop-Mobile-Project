using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class SpecieModel
    {
        [Key]
        public long IdSpecie {get; set;}
        public string Specie {get; set;}
        public List<PetModel> Pets {get;set;} 
    }
}