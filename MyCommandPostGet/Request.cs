using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommandPostGet
{
    public static class Request
    {

        /// <summary>
        /// 检查服务器是否支持远程插件
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        public async static Task<JsonResponse> Ping(string server)
        {
            var json = JsonConvert.SerializeObject(new JsonRequest() { action = "ping", data = null, token = "" });
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            return await PostRequest(server+"/opencommand/api",content);
        }


        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="server"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public async static Task<JsonResponse> SendCode(string server,int uid)
        {

            var json = JsonConvert.SerializeObject(new JsonRequest() { action = "sendCode", data = uid, token = "" });
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            return await PostRequest(server + "/opencommand/api", content);
        }


        public async static Task<JsonResponse> Verify(string server,string token,int code)
        {
            var json = JsonConvert.SerializeObject(new JsonRequest() { action = "verify", data = code, token = token });
            StringContent content = new StringContent(json,System.Text.Encoding.UTF8, "application/json");
            return await PostRequest(server + "/opencommand/api", content);
        }

        public async static Task<JsonResponse> BeginInvoke(string server,string token,string command)
        {
            var json = JsonConvert.SerializeObject(new JsonRequest() { action = "command", data = command, token = token });
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            return await PostRequest(server + "/opencommand/api", content);
        }

        public async static Task<JsonResponse> PostRequest(string url, StringContent content)
        {
            return await MyHttpClient.Post(url, content);
        }
    }
}
