using AuthService.Client.Interfaces;
using AuthService.Client.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Common.Interfaces.Services
{
    public class BaseClient: IBaseClient
    {
        internal string _url;

        public void ConfigureClient(string url)
        {
            _url = url;
        }

        internal async Task<BaseDataModel<T>> Execute<T>(string method, object body = null)
        {
            var result = new BaseDataModel<T>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_url);
                    HttpResponseMessage response = body != null
                        ? await client.PostAsync(method, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")) 
                        : await client.GetAsync(method);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<BaseDataModel<T>>(content);
                    }
                    else
                    {
                        result.Errors.Add("Failed");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add("Failed");
            }

            return result;
        }
    }
}
