using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BL;

namespace DependencyInversioon.Controllers
{
    public class HomeController : Controller
    {
    
        private IEmployee emp = null;
        private IStudent std = null;

        public HomeController(IEmployee employee,IStudent student)
        {
            emp = employee;
            std = student;
        }

        public ActionResult Index()
        {
            //int i= emp.getEmployee();
            List<MyStudentPRoperties> list = std.Getdata();

     
           foreach(var obj in list)
            {
                var name = obj.name;
                var Address = obj.Address;
                var Age = obj.Age;
            }

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
    }
}