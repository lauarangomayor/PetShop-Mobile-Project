using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class ClientModel
    {
        [Key]
        public long IdClient {get; set;}
        
        public long IdUser{get;set;}

        public UserModel User {get;set;}

        public List<OrderModel> Orders {get;set;}

        public List<PetModel> Pets {get;set;}

        //public List<VeterinarianModel> Veterinarians {get;set;}

        public List<WishListModel> WishLists{get;set;}
    }
}