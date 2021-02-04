using MasGlobalApplication.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace MasGlobalApplication.Data
{
    public class EmployeeDataAccess
    {
        public List<Employee> getEmployees()
        {
            List<Employee> jsonResponse = new List<Employee>();
            var client = new RestClient(ConfigurationManager.AppSettings["apiUrl"] + ConfigurationManager.AppSettings["employees"]);
            var reqRest = new RestRequest(Method.GET);
            IRestResponse res = client.Execute(reqRest);
            if (res.StatusCode == HttpStatusCode.Accepted || res.StatusCode == HttpStatusCode.OK)
            {
                jsonResponse = JsonConvert.DeserializeObject<List<Employee>>(res.Content.ToString());
                return jsonResponse;
            }
            return jsonResponse;
        }
    }
}