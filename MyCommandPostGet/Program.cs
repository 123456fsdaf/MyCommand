using Flurl;
using Flurl.Http;
using MyCommandPostGet;
using Newtonsoft.Json;
using System.Net;


// Pass the handler to httpclient(from you are calling api)

var json = JsonConvert.SerializeObject(new JsonRequest() { action = "ping", data = null, token = "" });
StringContent content = new StringContent(json,System.Text.Encoding.UTF8, "text/json");
var result =  await  MyHttpClient.Post("https://127.0.0.1/opencommand/api", content);
if (result != null)
{
    Console.WriteLine( result.Message);
}
Console.ReadLine();
