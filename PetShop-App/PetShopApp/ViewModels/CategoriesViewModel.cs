using PetShopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PetShopApp.ViewModels
{
    class CategoriesViewModel : ViewModelBase
    {
        #region Commands
        #endregion Commands
        public ObservableCollection<CategoryModel> CategoriesList { get; set; }
        public CategoriesViewModel()
        {
            CategoriesList = new ObservableCollection<CategoryModel>();

            CategoriesList.Add(new CategoryModel {CategoryId = 1, Name = "Aseo" });
            CategoriesList.Add(new CategoryModel {CategoryId = 2, Name = "Accesorios" });
            CategoriesList.Add(new CategoryModel {CategoryId = 3, Name = "Medicamentos" });
            CategoriesList.Add(new CategoryModel {CategoryId = 4, Name = "Varios" });




        }

    }

}
