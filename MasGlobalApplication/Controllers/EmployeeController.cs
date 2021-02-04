using MasGlobalApplication.Business;
using MasGlobalApplication.Data;
using MasGlobalApplication.Models;
using MasGlobalApplication.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace MasGlobalApplication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        Core core = new Core();
        EmployeeDataAccess employeeData = new EmployeeDataAccess();
        ErrorMessage errorMessage = new ErrorMessage();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Employee/{id:int}")]

        public HttpResponseMessage GetById(int id)
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee();
            try
            {
                employees = employeeData.getEmployees();
                employee = employees.Find(data => data.Id == id);
                if (employee == null || employee.Id == 0)
                {
                    throw new Exception("Not Found");
                }
                else
                {
                    employee = core.CalculateAnnualSalary(employee);
                }
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
            catch (Exception ex)
            {
                errorMessage.Error = true;
                errorMessage.Reason = ex.Message;
                return Request.CreateResponse(HttpStatusCode.NotFound, errorMessage);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Employees")]
        public HttpResponseMessage GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            List<Employee> employeesWithAnualSalary = new List<Employee>();
            try
            {
                employees = employeeData.getEmployees();
                if (employees.Count() == 0)
                {
                    throw new Exception("Not Found");
                }
                foreach (var employee in employees)
                {
                    employeesWithAnualSalary.Add(core.CalculateAnnualSalary(employee));
                }

                return Request.CreateResponse(HttpStatusCode.OK, employeesWithAnualSalary);
            }
            catch (Exception ex)
            {
                errorMessage.Error = true;
                errorMessage.Reason = ex.Message;
                return Request.CreateResponse(HttpStatusCode.NotFound, errorMessage);
            }
        }
    }
}