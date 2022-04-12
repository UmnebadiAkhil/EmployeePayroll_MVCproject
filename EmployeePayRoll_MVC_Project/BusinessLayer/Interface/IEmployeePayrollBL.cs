using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeePayrollBL
    {
        public string AddEmployee(EmployeeModel employeeModel);
        public string UpdateEmployee(EmployeeModel employeeModel);
        public EmployeeModel GetEmployeeDataById(int? id);
        public List<EmployeeModel> AllEmployeesList();
        public string DeleteEmployee(int? id);
    }
}