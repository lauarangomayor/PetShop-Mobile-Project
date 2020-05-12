using Newtonsoft.Json;
using PetShopApp.AuxModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetShopApp.Services.ApiRest
{
    public class RequestBody<T> : Request<T>
    {
        /* POST and PUT verbs. */
        #region Initilize
        public RequestBody(string url, string verb)
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

            string jsonObject = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            try
            {
                /* Context function. */
                using (var client = new HttpClient())
                {
                    var HttpVerb = (Verb == "POST") ? HttpMethod.Post : HttpMethod.Put;
                    HttpRequestMessage RequestMessage = new HttpRequestMessage(HttpVerb, Url);
                    RequestMessage = HeaderService.AddHeader(RequestMessage);
                    RequestMessage.Content = content;
                    HttpResponseMessage HttpResponse = await client.SendAsync(RequestMessage);
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

       
        #endregion
    }
}
