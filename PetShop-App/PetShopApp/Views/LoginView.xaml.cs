using PetShopApp.Services.Navigation;
using PetShopApp.ViewModels;
using Rg.Plugins.Popup.Services;
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
    public partial class LoginView : ContentPage
    {
        LoginViewModel context = new LoginViewModel();
        NavigationService navigationService = new NavigationService();
        public LoginView()
        {
            //BarBackgroundColor = Color.FromHex("#096085");
            InitializeComponent();
            BindingContext = context;
            gotoRegister();
        }

        void gotoRegister()
        {
            labelgotoRegister.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                  {
                    await navigationService.PushPage(new RegisterClientView(), null);

                  })

            });
        }


    }
}