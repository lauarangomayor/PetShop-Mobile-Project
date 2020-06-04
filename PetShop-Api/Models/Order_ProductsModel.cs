using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class Order_ProductsModel
    {
        [Key]
        public long IdOrder_Products {get; set;}
        public long IdOrder {get;set;}
        public long IdProduct{get;set;}
        public ProductModel Product {get; set;}
        public int QuantityBought{get;set;}
        
    }
}