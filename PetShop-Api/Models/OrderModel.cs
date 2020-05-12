using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class OrderModel
    {
        [Key]
        public long IdOrder {get; set;}
        public double TotalValue {get;set;}
        public string IdPerson {get; set;}
        public UserModel User {get;set;}
        public StateOrderModel StateOrder {get;set;}

        //public List<Order_ProductsModel> Order_Product{get;set;}

    }
}