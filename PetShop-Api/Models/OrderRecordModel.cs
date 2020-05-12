using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class OrderRecordModel
    {
        [Key]
        public long IdOrderRecord {get; set;}
        public long IdOrder {get;set;}
        public double TotalValue {get; set;}
        public long IdUser {get;set;}

    }
}