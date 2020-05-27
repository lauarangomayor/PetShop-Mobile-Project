using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace PetShop_Api.Models
{
    public class WishListModel
    {
        [Key]
        public long IdWishList {get; set;}
        public long IdClient {get;set;}
        public ClientModel Client {get;set;}
        [IgnoreDataMember]
        public List<WishList_ProductsModel> WishLists_Products{get;set;}
    }
}