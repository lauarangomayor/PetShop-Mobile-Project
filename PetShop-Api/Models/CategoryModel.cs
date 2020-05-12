using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class CategoryModel
    {
        [Key]
        public long IdCategory {get; set;}
        public string Name {get;set;}
        public List<ProductModel> Products {get;set;}

    }
}