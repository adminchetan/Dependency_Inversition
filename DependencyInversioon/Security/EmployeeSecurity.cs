using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyInversioon.Models;

namespace DependencyInversioon.Security
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using ( uttaraon_neerajEntities1 entities = new uttaraon_neerajEntities1())
            {
                return entities.Users.Any(user =>
                       user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.Password == password);
            }
        }
    }
}