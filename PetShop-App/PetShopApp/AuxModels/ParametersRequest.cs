using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.AuxModels
{
    public class ParametersRequest
    {
        #region Properties
        public List<string> Parameters { get; set; }
        public Dictionary<string, string> QueryParameters { get; set; }
        #endregion Properties

        #region Initialize
        public ParametersRequest()
        {
            Parameters = new List<string>();
            QueryParameters = new Dictionary<string, string>();
        }
        #endregion Initialize
    }
}
