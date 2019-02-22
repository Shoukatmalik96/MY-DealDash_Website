using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyDealDouble.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "AuctionsDetails",
				url: "auctions-details/{id}",
				defaults: new { controller = "Auctions", action = "Details", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "CategoriesDetails",
				url: "categories-details/{id}",
				defaults: new { controller = "Categories", action = "Details", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
