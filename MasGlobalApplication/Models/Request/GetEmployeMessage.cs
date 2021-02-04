using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasGlobalApplication.Models.Request
{
    public class GetEmployeMessage
    {
        [JsonProperty(PropertyName = "id")]
        public string CallId { get; set; }
    }
}