using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasGlobalApplication.Models
{
    public class Salary
    {
        [JsonProperty(PropertyName = "annualSalary")]
        public double AnnualSalary { get; set; }
    }
}