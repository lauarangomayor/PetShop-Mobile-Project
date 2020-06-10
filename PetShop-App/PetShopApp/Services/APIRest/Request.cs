using PetShopApp.AuxModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetShopApp.Services.APIRest
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

        public async Task ConstructURL(ParametersRequest parameters)
        {
            ParametersRequest Parameters = parameters as ParametersRequest;
            if (Parameters.Parameters.Count > 0)
            {
                Url = (Url.Substring(Url.Length - 1) == "/") ? Url.Remove(Url.Length - 1) : Url;
                Parameters.Parameters.ForEach(p => Url += "/" + p);
            }
            if (Parameters.QueryParameters.Count > 0)
            {
                var queryParameters = await new FormUrlEncodedContent(Parameters.QueryParameters).ReadAsStringAsync();
                Url = Url + queryParameters;
            }   
        }
        #endregion
    }
}
