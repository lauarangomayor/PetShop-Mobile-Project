using PetShopApp.AuxModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetShopApp.Services.ApiRest
{
    public class RequestParameters<T> : Request<T>
    {
        /* GET and DELETE verbs. */
        #region Initialize
        public RequestParameters(string url, string verb)
        {
            Url = url;
            Verb = verb;
        }

        #endregion
        #region Methods

        public override async Task<APIResponse> SendRequest(T obj)
        {
            APIResponse response = new APIResponse()
            {
                Code = 400,
                IsSuccess = false,
                Response = ""
            };

            try
            {
                /* Context function. */
                using (var client = new HttpClient())
                {
                    var HttpVerb = (Verb == "GET") ? HttpMethod.Get : HttpMethod.Delete;
                    await this.ConstructURL(obj);

                    HttpRequestMessage RequestMessage = new HttpRequestMessage(HttpVerb, Url);
                    RequestMessage = HeaderService.AddHeader(RequestMessage);
                    HttpResponseMessage HttpResponse= await client.SendAsync(RequestMessage);
                    response.Code = Convert.ToInt32(HttpResponse.StatusCode);
                    response.IsSuccess = HttpResponse.IsSuccessStatusCode;
                    response.Response = await HttpResponse.Content.ReadAsStringAsync();

                }
            }
            catch (Exception)
            {
                response.Response = "Server error";
            }
            return response;
        }
        private async Task ConstructURL(T parameters)
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
