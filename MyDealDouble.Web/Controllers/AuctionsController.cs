using MyDealDouble.Entities;
using MyDealDouble.Services;
using MyDealDouble.Web.Models;
using MyDealDouble.Web.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDealDouble.Web.Controllers
{
    public class AuctionsController : Controller
    {
		AuctionsService AuctionsService = new AuctionsService();

		public ActionResult Index()
        {
			AuctionsListingViewModels model = new AuctionsListingViewModels();
			model.Auctions = AuctionsService.GetAuctions();
			model.PageTitle = "Auctions";
			model.PageDescription = "Auctions Listing Page";
			if (Request.IsAjaxRequest())
			{
				return PartialView(model);
			}
			else
			{
				return View(model);
			}
		}
			
		[HttpGet]
		public ActionResult Create()
		{
			return PartialView();
		}
		[HttpPost]
		public ActionResult Create(Auction auction)
		{
			AuctionsService.saveAuction(auction);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit(int ID)
		{
			var auction = AuctionsService.GetAuctionById(ID);
			return PartialView(auction);
		}
		[HttpPost]
		public ActionResult Edit(Auction auction)
		{
			AuctionsService.EditAuction(auction);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Delete(int ID)
		{

			var auction = AuctionsService.GetAuctionById(ID);
			return View(auction);
		}
		[HttpPost]
		public ActionResult Delete(Auction auction)
		{
			AuctionsService.DeleteAuction(auction);
			return RedirectToAction("Index");
		}
		public ActionResult Details(int ID)
		{
			var aution = AuctionsService.GetAuctionById(ID);
			return View(aution);
		}
	}
}