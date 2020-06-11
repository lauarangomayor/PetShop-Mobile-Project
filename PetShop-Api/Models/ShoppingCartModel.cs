using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PetShop_Api.Models
{
    public class ShoppingCartModel
    {
        

        public List<long> IdProducts{get;set;}

        
    }
}