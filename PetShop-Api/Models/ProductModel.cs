using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class ProductModel
    {
        [Key]
        public long IdProduct {get; set;}
        public string Name {get; set;}
        public string Description{get;set;}
        public CategoryModel Category{get;set;}
        public int QuantityAvailable{get;set;}
        public double UnitPrice{get;set;}
        public StateProductModel StateProduct {get;set;}

        public List<Order_ProductsModel> Orders_Products{get;set;}

        public List<WishList_ProductsModel> WishLists_Products{get;set;}
    }
}