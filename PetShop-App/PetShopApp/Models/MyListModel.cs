using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class MyListModel: BaseModel

    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFavorite { get; set; }
    }

}
