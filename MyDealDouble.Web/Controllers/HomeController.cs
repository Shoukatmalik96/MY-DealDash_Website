using MyDealDouble.Services;
using MyDealDouble.Web.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDealDouble.Web.Controllers
{
	public class HomeController : Controller
	{
		AuctionsService AuctionsService = new AuctionsService();
		public ActionResult Index()
		{
			AuctionsViewModels vModel = new AuctionsViewModels();

			vModel .AllAuctions= AuctionsService.GetAuctions();
			if (vModel.AllAuctions != null)
			{
				vModel.PromotedAuctions = AuctionsService.GetPromotedAuctions();
			}
			vModel.PageTitle = "Home Page";
			vModel.PageDescription = "This is Home Page";
			
			return View(vModel);
		}

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
	}
}