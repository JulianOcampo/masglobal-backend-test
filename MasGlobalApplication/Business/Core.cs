using MasGlobalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasGlobalApplication.Business
{
    public class Core
    {
        Employee employee = new Employee();

        public Employee CalculateAnnualSalary(Employee employee)
        {
            if (employee.ContractTypeName.Length > 0 && employee.ContractTypeName.Trim().ToLower() == "hourlysalaryemployee")
            {
                employee = CalculateHourlySalary(employee);
            }
            else if (employee.ContractTypeName.Length > 0 && employee.ContractTypeName.Trim().ToLower() == "monthlysalaryemployee")
            {
                employee = CalculateMonthtlySalary(employee);
            }

            return employee;
        }

        private Employee CalculateHourlySalary(Employee employee)
        {
            employee.AnnualSalary = (120 * employee.HourlySalary * 12);
            return employee;
        }

        private Employee CalculateMonthtlySalary(Employee employee)
        {
            employee.AnnualSalary = (employee.MonthlySalary * 12);
            return employee;
        }
    }


}