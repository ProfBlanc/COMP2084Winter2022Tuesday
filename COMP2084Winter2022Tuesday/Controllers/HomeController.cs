using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COMP2084Winter2022Tuesday.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			//Console.Write("Hello");
			ViewBag.Salutation = "How's it going?";
			return View();
		}

		//[Authorize] [TEXT]
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

		public ActionResult Test()
		{
			return Content("Hello from Test Action of Home Controller");
		}
		
		public ActionResult ViewTest()
		{
			return View();
		}
	}
}