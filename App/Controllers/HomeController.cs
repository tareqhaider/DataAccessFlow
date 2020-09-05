using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;
using DataLibrary.BusinessLogic;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employee List";

            var collection = EmployeeProcessor.LoadEmployees();

            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var item in collection)
            {
               employees.Add( new EmployeeModel
               {
                   EmployeeId = item.EmployeeId,
                   FirstName = item.FirstName,
                   Lastname = item.LastName,
                   Email = item.Email
               });         
            }

            return View(employees);

        }



        [HttpGet]
        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee Signup";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp( EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int flag = EmployeeProcessor.CreateEmployee(model.EmployeeId, model.FirstName, model.Lastname, model.Email);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}