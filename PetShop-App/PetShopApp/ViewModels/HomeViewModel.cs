using PetShopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PetShopApp.ViewModels
{
    class HomeViewModel
    {
        public ObservableCollection<ProductModel> ProductsList { get; set; }
        public HomeViewModel()
        {
            ProductsList = new ObservableCollection<ProductModel>();
            ProductsList.Add(new MyListModel { Name = "Test1", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 1", Ingredients = "This is our detail page 1. Cheese, Bacon, Tomato" });
            ProductsList.Add(new MyListModel { Name = "Test2", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 2", Ingredients = "This is our detail page 2. Cheese, Bacon, Tomato" });
            ProductsList.Add(new MyListModel { Name = "Test3", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 3", Ingredients = "This is our detail page 3. Cheese, Bacon, Tomato" });
            ProductsList.Add(new MyListModel { Name = "Test4", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 4", Ingredients = "This is our detail page 4. Cheese, Bacon, Tomato" });
            ProductsList.Add(new MyListModel { Name = "Test5", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 1", Ingredients = "This is our detail page 1. Cheese, Bacon, Tomato" });
            FoodList.Add(new MyListModel { Name = "Test6", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 2", Ingredients = "This is our detail page 2. Cheese, Bacon, Tomato" });
            FoodList.Add(new MyListModel { Name = "Test7", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 3", Ingredients = "This is our detail page 3. Cheese, Bacon, Tomato" });
            FoodList.Add(new MyListModel { Name = "Test8", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 4", Ingredients = "This is our detail page 4. Cheese, Bacon, Tomato" });
            FoodList.Add(new MyListModel { Name = "Test9", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 1", Ingredients = "This is our detail page 1. Cheese, Bacon, Tomato" });
            FoodList.Add(new MyListModel { Name = "Test10", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 2", Ingredients = "This is our detail page 2. Cheese, Bacon, Tomato" });
            FoodList.Add(new MyListModel { Name = "Test11", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 3", Ingredients = "This is our detail page 3. Cheese, Bacon, Tomato" });
            FoodList.Add(new MyListModel { Name = "Test12", Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg", Detail = "This is a burger 4", Ingredients = "This is our detail page 4. Cheese, Bacon, Tomato" });

        }
    }
}
