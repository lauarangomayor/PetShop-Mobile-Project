using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
namespace PetShop_Api.Models
{
    public class CategoryModel
    {
        [Key]
        public long IdCategory {get; set;}
        public string Name {get;set;}
        
        [IgnoreDataMember]
        public List<ProductModel> Products {get;set;}

    }
}