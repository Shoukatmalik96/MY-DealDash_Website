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

			vModel.PageTitle = "Home Page";
			vModel.PageDescription = "This is Home Page";

			//var auctions = AuctionsService.GetAuctions();

			//vModel.AllAuctions = new List<MyDealDouble.Entities.Auction>();
			//vModel.AllAuctions.AddRange(auctions);
			//vModel.AllAuctions.AddRange(auctions);
			//vModel.AllAuctions.AddRange(auctions);
			//vModel.AllAuctions.AddRange(auctions);
			//vModel.AllAuctions.AddRange(auctions);
			//vModel.AllAuctions.AddRange(auctions);
			//vModel.AllAuctions.AddRange(auctions);

			//vModel.PromotedAuctions = AuctionsService.GetAuctions();
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