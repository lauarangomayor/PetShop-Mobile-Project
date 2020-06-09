using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Configuration
{
    public class RestConfiguration
    {
        #region Properties
        private readonly string NameSpaceRest;
        public Dictionary<string, string> VerbsConfiguration;
        #endregion
        #region Initialize
        public RestConfiguration()
        {
            NameSpaceRest = "PetShopApp.Services.APIRest.";
            InitializeVerbsConfiguration();
        }
        #endregion
        #region methods
        private void InitializeVerbsConfiguration()
        {
            VerbsConfiguration = new Dictionary<string, string>();
            VerbsConfiguration.Add("GET", string.Concat(NameSpaceRest, "RequestParameters`1"));
            VerbsConfiguration.Add("DELETE", string.Concat(NameSpaceRest, "RequestParameters`1"));
            VerbsConfiguration.Add("POST", string.Concat(NameSpaceRest, "RequestBody`1"));
            VerbsConfiguration.Add("PUT", string.Concat(NameSpaceRest, "RequestBody`1"));

        }
        #endregion
    }
}
