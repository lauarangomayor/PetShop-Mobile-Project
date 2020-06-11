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
    public partial class LoginShopView
    {
        LoginShopViewModel context = new LoginShopViewModel();
        NavigationService navigationService = new NavigationService();

        public LoginShopView()
        {
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
                    await PopupNavigation.PopAsync();
                    await navigationService.PushPage(new RegisterClientView(), null);

                })

            });
        }

    }
}