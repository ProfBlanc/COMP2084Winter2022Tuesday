using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace COMP2084Winter2022Tuesday
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			/*
			routes.MapRoute(
				name: "Custom",
				url: "Ben/Blanc/{id}",
				defaults: new {  id = UrlParameter.Optional }
			);
			*/

			routes.MapRoute(
				name: "SemesterTerm",
				url: "Semesters/{year}/{term}",
				defaults: new { controller = "Semesters", action = "Term" },
				constraints: new { year = @"\d{4}", term = @"winter|fall|summer|spring" }
			);
			routes.MapRoute(
				name: "SemesterYear",
				url: "Semesters/{year}",
				defaults: new { controller = "Semesters", action = "Year" },
				constraints: new { year = @"\d{4}"}
			);
			
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);




		}
	}
}
