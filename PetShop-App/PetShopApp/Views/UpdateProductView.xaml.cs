using PetShopApp.ViewModels;
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
    public partial class UpdateProductView : ContentPage
    {
        UpdateProductViewModel context = new UpdateProductViewModel();
        public UpdateProductView()
        {
            InitializeComponent();
            BindingContext = context;
        }
    }
}