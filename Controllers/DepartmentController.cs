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
    public class DepartmentController : Controller
    {
        private readonly IConfiguration configuration;
        DepartmentDAL departmentdal;
        public DepartmentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            departmentdal = new DepartmentDAL(configuration);
        }
        


        public ActionResult Index()
        {
            var department = departmentdal.GetAllDepartment();
            return View(department);
        }
        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var department = departmentdal.GetDepartmentById(id);
            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                int res = departmentdal.AddDepartment(department);
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

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var department = departmentdal.GetDepartmentById(id);
            return View(department);

        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department d)
        {
            try
            {
                int res = departmentdal.UpdateDepartment(d);
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

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var department = departmentdal.GetDepartmentById(id);
            return View(department);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = departmentdal.DeleteDepartment(id);
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
