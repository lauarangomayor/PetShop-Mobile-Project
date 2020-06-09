using PetShopApp.Models;
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
    public partial class HomeShopView : ContentPage
    {
        HomeShopViewModel context = new HomeShopViewModel();
        public HomeShopView()
        {
            InitializeComponent();
            BindingContext = context;
        }

       /* private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var myProducts = e.Item as ProductModel;
            await Navigation.PushAsync(new ProductDetail(myProducts.ID, myProducts.Name, myProducts.Description, myProducts.UnitPrice, myProducts.Image));
        }

        void OnListViewScrolled(Object sender, ScrolledEventArgs e)
        {
            Debug.WriteLine("ScrollX: " + e.ScrollX);
            Debug.WriteLine("ScrollY: " + e.ScrollY);
        } */
    }
}