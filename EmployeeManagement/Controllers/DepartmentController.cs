using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        public string List()
        {
            return "List() of DepartmentController";
        }

        public string Detail() {
            return "Details() of DepartmentController";
        }
    }
}
