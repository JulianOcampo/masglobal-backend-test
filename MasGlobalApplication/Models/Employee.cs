using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasGlobalApplication.Models
{
    public class Employee : Salary
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "contractTypeName")]
        public string ContractTypeName { get; set; }

        [JsonProperty(PropertyName = "roleId")]
        public int RoleId { get; set; }

        [JsonProperty(PropertyName = "roleName")]
        public string RoleName { get; set; }

        [JsonProperty(PropertyName = "roleDescription")]
        public string RoleDescription { get; set; }

        [JsonProperty(PropertyName = "hourlySalary")]
        public double HourlySalary { get; set; }

        [JsonProperty(PropertyName = "monthlySalary")]
        public double MonthlySalary { get; set; }

        public Employee(int id = 0, string name = "", string contractTypeName = "", int roleId = 0, string roleName = "", string roleDescription = "", double hourlySalary = 0.0, double monthlySalary = 0.0)
        {
            Id = id;
            Name = name;
            ContractTypeName = contractTypeName;
            RoleId = roleId;
            RoleName = roleName;
            RoleDescription = roleDescription;
            HourlySalary = hourlySalary;
            MonthlySalary = monthlySalary;
        }
    }
}