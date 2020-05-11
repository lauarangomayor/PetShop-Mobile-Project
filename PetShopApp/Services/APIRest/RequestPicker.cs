using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopApp.Services.ApiRest
{
    public class RequestPicker<T>
    {
        #region Properties
        public Request<T> SendStrategy { get; set; }
        public RestConfiguration RestConfiguration { get; set; }
        #endregion
        #region Initialize
        public RequestPicker()
        {
            RestConfiguration = new RestConfiguration();
        }
        #endregion
        #region Methods
        public void StrategyPicker(string verb, string url)
        {
            var dictionary = RestConfiguration.VerbsConfiguration;
            string className;
            /* out is used to tell that className is an output value. */
            if (dictionary.TryGetValue(verb.ToUpper(), out className)) 
            {
                Type classType = Type.GetType(className);
                /* Recivies class name and params for converting them to a concrete class casted to the abstract class. */
                SendStrategy = (Request<T>)Activator.CreateInstance(classType, url);
            }
        }

        public async Task<APIResponse> ExecuteStrategy(T obj)
        {
            var response = await SendStrategy.SendRequest(obj);
            return response;
        }
        #endregion
    }
}
