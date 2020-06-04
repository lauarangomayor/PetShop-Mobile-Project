using System;
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
        public DateTime OrderDate{get;set;}
        public long IdClient {get;set;}

    }
}