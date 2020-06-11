using PetShopApp.Models;
using PetShopApp.Services.Navigation;
using PetShopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesView : ContentPage
    {
        public CategoriesView()
        {
            InitializeComponent();
            BindingContext = new CategoriesViewModel();

        }

        /*private async void OnItemSelected(Object sender, ItemTappedEventArgs c)
        {

            var category = c.Item as CategoryModel;
           // await Navigation.PushAsync(new ProductsByCategoryView(), c);
            //await NavigationService.PushPage(new ProductDetail(myProducts.ID, myProducts.Name, myProducts.Description, myProducts.UnitPrice, myProducts.Image));
        }*/

        void OnListViewScrolled(object sender, ScrolledEventArgs e)
        {
            Debug.WriteLine("ScrollX: " + e.ScrollX);
            Debug.WriteLine("ScrollY: " + e.ScrollY);
        }
    }
}