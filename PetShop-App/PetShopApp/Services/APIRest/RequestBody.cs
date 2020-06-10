using Newtonsoft.Json;
using PetShopApp.AuxModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetShopApp.Services.APIRest
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

            try
            {
                /* Context function. */
                using (var handler = new HttpClientHandler())
                {
                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    handler.ServerCertificateCustomValidationCallback = (h, c, ch, pe) =>
                    {
                        return true;
                    };
                    using (var client = new HttpClient(handler))
                    {
                        string jsonObject = JsonConvert.SerializeObject(obj);
                        HttpContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                        var HttpVerb = (Verb == "POST") ? HttpMethod.Post : HttpMethod.Put;
                        HttpRequestMessage RequestMessage = new HttpRequestMessage(HttpVerb, Url);
                        RequestMessage = HeaderService.AddHeader(RequestMessage);
                        RequestMessage.Content = content;
                        client.Timeout = TimeSpan.FromSeconds(50);
                        HttpResponseMessage HttpResponse = await client.SendAsync(RequestMessage);
                        response.Code = Convert.ToInt32(HttpResponse.StatusCode);
                        response.IsSuccess = HttpResponse.IsSuccessStatusCode;
                        response.Response = await HttpResponse.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception e)
            {
                response.Response = "Server error";
            }
            return response;

        }

       
        #endregion
    }
}
