using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace PetShop_Api.Models
{
    public class UserModel
    {
        [Key]
        public long IdUser {get; set;}
        public string DocumentId {get;set;}
        public string Name {get; set;}
        public string Telephone{get;set;}
        public string Address{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public int UserType{get;set;}
        [IgnoreDataMember]
        public List <ClientModel> Clients {get;set;}
        [IgnoreDataMember]
        public List <VeterinarianModel> Veterinarians {get;set;}
    }
}