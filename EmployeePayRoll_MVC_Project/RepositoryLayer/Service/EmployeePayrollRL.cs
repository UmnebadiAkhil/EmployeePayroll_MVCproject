using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeePayrollRL : IEmployeePayrollRL
    {
        private readonly IConfiguration configuration;
        public EmployeePayrollRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@ProfileImage", employeeModel.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
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
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@ProfileImage", employeeModel.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
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
                EmployeeModel employeeModel = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    string sqlQuery = "Select * from Employee where EmployeeId = " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        employeeModel.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        employeeModel.EmployeeName = dr["EmployeeName"].ToString();
                        employeeModel.ProfileImage = dr["ProfileImage"].ToString();
                        employeeModel.Gender = dr["Gender"].ToString();
                        employeeModel.Department = dr["Department"].ToString();
                        employeeModel.Salary = Convert.ToInt32(dr["Salary"]);
                        employeeModel.StartDate = Convert.ToDateTime(dr["StartDate"]);
                        employeeModel.Notes = dr["Notes"].ToString();
                    }
                    con.Close();
                }
                return employeeModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeModel> AllEmployeesList()
        {
            List<EmployeeModel> allEmployees = new List<EmployeeModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmployeeModel employeeModel = new EmployeeModel()
                        {
                            EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                            EmployeeName = dr["EmployeeName"].ToString(),
                            ProfileImage = dr["ProfileImage"].ToString(),
                            Gender = dr["Gender"].ToString(),
                            Department = dr["Department"].ToString(),
                            Salary = Convert.ToInt32(dr["Salary"]),
                            StartDate = Convert.ToDateTime(dr["StartDate"]),
                            Notes = dr["Notes"].ToString()
                        };
                        allEmployees.Add(employeeModel);
                    }
                    con.Close();
                }
                return allEmployees;
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
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Employee deleted successfully";
        }
    }
}
