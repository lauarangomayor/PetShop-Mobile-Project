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
    public partial class AppointmentRecordView : ContentPage
    {
        AppointmentRecordViewModel context;
        public AppointmentRecordView()
        {
            InitializeComponent();
            context = new AppointmentRecordViewModel();
            BindingContext = context;
        }
    }
}