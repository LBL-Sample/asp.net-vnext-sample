using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using MVC.TagHelper.Web.Models;


namespace MVC.TagHelper.Web.Controllers
{
    public class SelectTagController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            SelectViewModel model = new SelectViewModel();
            ViewBag.Countties = new List<SelectListItem>()
            {
                new SelectListItem {Text = "China"},
                new SelectListItem {Text = "Beijing"}
            };
            return View(model);
        }
    }
}
