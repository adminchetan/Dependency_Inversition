using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BL
{
   public class Student:IStudent 
    {
        List<MyStudentPRoperties> lst = new List<MyStudentPRoperties>();

        public List<MyStudentPRoperties> Getdata()  
        {
            MyStudentPRoperties obj = new MyStudentPRoperties();
            obj.Address = "noida 126";
            obj.Age = "29";
            obj.name = "champak";

            lst.Add(obj);

            return lst;
           
        }


 
    }
}
