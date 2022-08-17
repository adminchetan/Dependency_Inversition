using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BL;
using DependencyInversioon.Filters;

namespace DependencyInversioon.Controllers
{
    public class HomeController : Controller
    {
    
        private IEmployee emp = null;    // create instance of interface
        private IStudent std = null;       // create instance of interface


        public HomeController(IEmployee employee,IStudent student)    //call constructor
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

        [MyCustomExcepctions]
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            int a = 9;
            //a=a / 0;
            return View("abc");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}