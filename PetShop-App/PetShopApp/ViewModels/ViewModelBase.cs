using PetShopApp.Services.Navigation;
using PetShopApp.Services.Propagation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopApp.ViewModels
{
    public class ViewModelBase : NotificationObject
    {
        #region Properties
        public NavigationService NavigationService { get; set; }
        #endregion
        #region Initialization
        public ViewModelBase()
        {
            NavigationService = App.NavigationService;
        }
        #endregion
        #region Methods
        public virtual async Task ConstructorAsync(object parameters)
        {
            await Task.FromResult(true);
        }
        #endregion
    }
}
