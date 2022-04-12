using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeePayrollBL : IEmployeePayrollBL
    {
        IEmployeePayrollRL employeePayrollRL;

        public EmployeePayrollBL(IEmployeePayrollRL employeePayrollRL)
        {
            this.employeePayrollRL = employeePayrollRL;
        }
        public string AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.employeePayrollRL.AddEmployee(employeeModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Employee registered successfully";
        }

        public string UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.employeePayrollRL.UpdateEmployee(employeeModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Employee updated successfully";
        }

        public EmployeeModel GetEmployeeDataById(int? id)
        {
            try
            {
                return this.employeePayrollRL.GetEmployeeDataById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeModel> AllEmployeesList()
        {
            try
            {
                return this.employeePayrollRL.AllEmployeesList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteEmployee(int? id)
        {
            try
            {
                this.employeePayrollRL.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Employee deleted successfully";
        }
    }
}