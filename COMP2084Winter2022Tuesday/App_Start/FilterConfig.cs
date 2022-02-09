using System.Web;
using System.Web.Mvc;

namespace COMP2084Winter2022Tuesday
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
