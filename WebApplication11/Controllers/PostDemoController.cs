using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class PostDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HiddenDemo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitHidden(string hiddenValue)
        {
            PostDemoViewModel vm = new PostDemoViewModel
            {
                Name = hiddenValue
            };
            return View(vm);
        }

        public ActionResult FormPost(string name)
        {
            PostDemoViewModel vm = new PostDemoViewModel
            {
                Name = name
            };
            return View(vm);
        }
    }
}