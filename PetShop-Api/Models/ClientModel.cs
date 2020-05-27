using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PetShop_Api.Models
{
    public class ClientModel
    {
        [Key]
        public long IdClient {get; set;}

        public long IdUser{get;set;}

        public UserModel User {get;set;}
        [IgnoreDataMember]
        public List<OrderModel> Orders {get;set;}
        [IgnoreDataMember]
        public List<PetModel> Pets {get;set;}

        //public List<VeterinarianModel> Veterinarians {get;set;}
        [IgnoreDataMember]
        public List<WishListModel> WishLists{get;set;}
    }
}