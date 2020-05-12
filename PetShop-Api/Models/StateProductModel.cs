using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class StateProductModel
    {
        [Key]
        public long IdStateProduct {get; set;}
        public string Description {get;set;}
        public List<ProductModel> Products {get;set;}

    }
}