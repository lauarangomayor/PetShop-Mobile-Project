using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class WishListModel
    {
        [Key]
        public long IdWishList {get; set;}
        public UserModel User {get;set;}
        public List<WishList_ProductsModel> WishLists_Products{get;set;}
    }
}