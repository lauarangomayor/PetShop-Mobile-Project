using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace PetShop_Api.Models
{
    public class StateOrderModel
    {
        [Key]
        public long IdStateOrder {get; set;}
        public string Description {get; set;}
        [IgnoreDataMember]
        public List<OrderModel> Orders {get;set;} //relacion entre StateOrder y Order
    }
}