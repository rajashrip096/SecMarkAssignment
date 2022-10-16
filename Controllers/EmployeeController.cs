using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SecMarkAssignment.DAL;
using SecMarkAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecMarkAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL employeedal;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeedal = new EmployeeDAL(configuration);
        }
        // GET: EmployeeController
        public ActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee emp)
        {
            try
            {
                Employee res = employeedal.GetEmployeeByEmail(emp);
                if (res != null && res.Password == emp.Password)
                {
                    HttpContext.Session.SetString("email", emp.Email);
                    return View(); 
                }

                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult Index()
        {
            var employee = employeedal.GetAllEmployee();
            return View(employee);
        }
        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = employeedal.GetEmployeeById(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int res = employeedal.AddEmployee(emp);
                if (res == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = employeedal.GetEmployeeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int res = employeedal.UpdateEmployee(emp);
                if (res == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = employeedal.GetEmployeeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = employeedal.DeleteEmployee(id);
                if (res == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
