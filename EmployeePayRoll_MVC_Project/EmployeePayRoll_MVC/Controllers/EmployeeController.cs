using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeePayrollBL employeePayrollBL;
                public EmployeeController(IEmployeePayrollBL employeePayrollBL)
        {
            this.employeePayrollBL = employeePayrollBL;
        }
        public IActionResult Index()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = employeePayrollBL.AllEmployeesList().ToList();
            return View(lstEmployee);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                employeePayrollBL.AddEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = employeePayrollBL.GetEmployeeDataById(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] EmployeeModel employeeModel)
        {
            if (id != employeeModel.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeePayrollBL.UpdateEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = employeePayrollBL.GetEmployeeDataById(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = employeePayrollBL.GetEmployeeDataById(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeePayrollBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
