using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetail : ContentPage
    {
        public ProductDetail(long idProduct, string Name, string Description, float UnitPrice, string source)
        {
            InitializeComponent();
            MyItemNameShow.Text = Name;
            MyItemDescriptionShow.Text = Description;
            MyImageCall.Source = new UriImageSource()
            {
                Uri = new Uri(source)
            };
        }
    }
}