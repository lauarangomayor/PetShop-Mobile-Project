using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.AuxModels
{
    public class ParametersRequest
    {
        #region Properties
        public List<string> Parameters { get; set; }
        public Dictionary<string,string> QueryParameters { get; set; }
        #endregion
        #region Initialize
        public ParametersRequest() { }
        #endregion
    }
}
