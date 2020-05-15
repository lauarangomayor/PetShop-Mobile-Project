using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class WishList_ProductsModel
    {
        [Key]
        public long IdWishList_Products {get; set;}
        public long IdWishList{get;set;}
        public WishListModel WishList {get;set;}
        public long IdProduct{get;set;}
        public ProductModel Product {get; set;}
    }
}