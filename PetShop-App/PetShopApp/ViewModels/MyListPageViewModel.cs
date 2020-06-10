using Acr.UserDialogs;
using PetShopApp.Helpers;
using PetShopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PetShopApp.ViewModels
{
    class MyListPageViewModel : ViewModelBase
    {
        public ObservableCollection<Tuple<long, int>> FoodList { get; set; }
        public MyListPageViewModel()
        {
            FoodList = new ObservableCollection<Tuple<long, int>>();
            var savedList = new List<Tuple<long, int>>(Settings.listProductsCart);
            foreach (var item in savedList)
            {
                FoodList.Add(item);
                Console.WriteLine(item);
            }



        }
    }
}
