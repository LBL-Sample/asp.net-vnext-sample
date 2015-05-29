using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace MVC.TagHelper.Web.Controllers
{
    public class EnvironmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
