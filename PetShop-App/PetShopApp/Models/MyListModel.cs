using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    class MyListModel: BaseModel
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }
    }
}
