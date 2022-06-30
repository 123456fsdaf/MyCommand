using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommandPostGet
{
    public static class MyHttpClient
    {
        public static HttpClient HttpClient { get; set; }   
        static MyHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient = new HttpClient(clientHandler);
        }
        

        public static async Task<JsonResponse> Post(string url,StringContent content)
        {
#pragma warning disable CS8603 // 可能返回 null 引用。
            return await Task.Run(async() =>
            {
                var a = await HttpClient.PostAsync(url, content);
                return JsonConvert.DeserializeObject<JsonResponse>(await a.Content.ReadAsStringAsync());
            });
#pragma warning restore CS8603 // 可能返回 null 引用。
        }
        

        public static async Task<JsonResponse> Get(string url)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var a = await HttpClient.GetAsync(url);
                    return JsonConvert.DeserializeObject<JsonResponse>(await a.Content.ReadAsStringAsync());
                }
                catch (Exception)
                {
                    return new JsonResponse() { Message = "exit" };
                }
            });
        }
    }
}
