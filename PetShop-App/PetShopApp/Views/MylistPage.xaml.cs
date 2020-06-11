using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopApp.Models;
using PetShopApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MylistPage : ContentPage
    {
        public MylistPage()
        {
            InitializeComponent();
            BindingContext = new MyListPageViewModel();
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as MyListModel;
            await Navigation.PushAsync(new MyListPageDetail(mydetails.Name, mydetails.Ingredients, mydetails.Image));
        }

        void OnListViewScrolled(Object sender, ScrolledEventArgs e)
        {
            Debug.WriteLine("ScrollX: " + e.ScrollX);
            Debug.WriteLine("ScrollY: " + e.ScrollY);
        }

        void OnCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            Debug.WriteLine("HorizontalDelta: " + e.HorizontalDelta);
            Debug.WriteLine("VerticalDelta: " + e.VerticalDelta);
            Debug.WriteLine("HorizontalOffset: " + e.HorizontalOffset);
            Debug.WriteLine("VerticalOffset: " + e.VerticalOffset);
            Debug.WriteLine("FirstVisibleItemIndex: " + e.FirstVisibleItemIndex);
            Debug.WriteLine("CenterItemIndex: " + e.CenterItemIndex);
            Debug.WriteLine("LastVisibleItemIndex: " + e.LastVisibleItemIndex);
        }
    }
}