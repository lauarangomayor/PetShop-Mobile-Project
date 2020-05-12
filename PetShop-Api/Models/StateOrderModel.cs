using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class StateOrderModel
    {
        [Key]
        public long IdStateOrder {get; set;}
        public string Description {get; set;}
        public List<OrderModel> Orders {get;set;} //relacion entre StateOrder y Order
    }
}