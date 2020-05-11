using PetShopApp.AuxModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopApp.Services.ApiRest
{
    public abstract class Request<T>
    {
        #region Properties
        protected string Url { get; set;}
        protected string Verb { get; set; }

        private static HeaderService headerService;

        #endregion
        #region Getters/Setters
        protected static HeaderService HeaderService
        {
            // Sigleton pattern for instancing the same atribute in all child classes.
            get 
            {
                if (headerService == null)
                {
                    headerService = new HeaderService();
                }
                return headerService;

            }
        }
        #endregion
        #region Methods
        public abstract Task<APIResponse> SendRequest(T obj);
        #endregion
    }
}
