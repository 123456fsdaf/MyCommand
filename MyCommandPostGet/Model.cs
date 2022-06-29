using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyCommandPostGet
{
    public  class JsonRequest
    {
        public string token { get; set; }
        public string action { get; set; }

        public Object data { get; set; }
    }

    public class JsonResponse
    {
        [JsonProperty("retcode")]
        public int Retcode { get; set; }

        [JsonProperty("message")]
        public String Message { get; set; }


        [JsonProperty("data")]
        public Object Data;
    }

}
