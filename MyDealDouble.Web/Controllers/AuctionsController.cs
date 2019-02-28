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
		CategoriesService categoriesService = new CategoriesService();
		SharedService sharedService = new SharedService();

		public ActionResult Index(int? categoryID, string searchTerm, int? pageNo)
        {

			AuctionsListingViewModel model = new AuctionsListingViewModel();

			model.PageTitle = "Auctions";
			model.PageDescription = "Auction Listing Page";

			model.CategoryID = categoryID;
			model.SearchTerm = searchTerm;
			model.PageNo = pageNo;

			model.Categories = categoriesService.GetAllCategories();
			return PartialView(model);
			
		}

		public ActionResult Listing(int? categoryID, string searchTerm, int? pageNo)
		{
			var pageSize = 2;

			AuctionsListingViewModel model = new AuctionsListingViewModel();

			model.Auctions = AuctionsService.SearchAuctions(categoryID, searchTerm, pageNo, pageSize);

			var totalAuctions = AuctionsService.GetAuctionCount(categoryID, searchTerm);

			model.Pager = new Pager(totalAuctions, pageNo, pageSize);

			return PartialView(model);
			
		}

		[HttpGet]
		public ActionResult Create()
		{
			CreateAuctionViewModel model = new CreateAuctionViewModel();
			model.Categories = categoriesService.GetAllCategories() ;
			return PartialView(model);
		}
		[HttpPost]
		public ActionResult Create(CreateAuctionViewModel model)
		{
			Auction auction = new Auction();
			auction.Title = model.Title;
			auction.Description = model.Description;
			auction.ActualAmount = model.ActualAmount;
			auction.StartingTime = model.StartingTime;
			auction.EndingTime  = model.EndingTime;
			auction.CategoryID  = model.CategoryID;

			auction.AuctionPictures = new List<AuctionPicture>();
			var pictureIDs = model.AuctionPictures.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries)
																		.Select(ID => int.Parse(ID)).ToList();


			//foreach (var picID in pictureIDs)
			//{
			//	var auctionPictures = new AuctionPicture();
			//	auctionPictures.PictureID = picID;
			//	auction.AuctionPictures.Add(auctionPictures);
			//}

			//Same logic by using foreach

		   auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { PictureID = x }));
			AuctionsService.saveAuction(auction);
			return RedirectToAction("Listing");
		}
		[HttpGet]
		public ActionResult Edit(int ID)
		{
			CreateAuctionViewModel model = new CreateAuctionViewModel();

			var auction = AuctionsService.GetAuctionById(ID);

			model.ID = auction.ID;
			model.Title = auction.Title;
			model.CategoryID = auction.CategoryID;
			model.Description = auction.Description;
			model.ActualAmount = auction.ActualAmount;
			model.StartingTime = auction.StartingTime;
			model.EndingTime = auction.EndingTime;

			model.Categories = categoriesService.GetAllCategories();
			model.AuctionPicturesList = auction.AuctionPictures;

			return PartialView(model);
		}

		[HttpPost]
		public ActionResult Edit(CreateAuctionViewModel model)
		{
			Auction auction = new Auction();
			auction.ID = model.ID;
			auction.Title = model.Title;
			auction.CategoryID = model.CategoryID;
			auction.Description = model.Description;
			auction.ActualAmount = model.ActualAmount;
			auction.StartingTime = model.StartingTime;
			auction.EndingTime = model.EndingTime;

			if (!string.IsNullOrEmpty(model.AuctionPictures))
			{
				//LINQ
				var pictureIDs = model.AuctionPictures
											.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
											.Select(ID => int.Parse(ID)).ToList();

				auction.AuctionPictures = new List<AuctionPicture>();
				auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { AuctionID = auction.ID, PictureID = x }).ToList());
			}

			AuctionsService.UpdateAuction(auction);

			return RedirectToAction("Listing");
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
			return RedirectToAction("Listing");
		}
		public ActionResult Details(int ID)
		{
			//AuctionDetailsViewModel model = new AuctionDetailsViewModel();
			//model.Auction= AuctionsService.GetAuctionById(ID);

			AuctionDetailsViewModel model = new AuctionDetailsViewModel();

			model.Auction = AuctionsService.GetAuctionById(ID);

			model.BidsAmount = model.Auction.ActualAmount + model.Auction.Bids.Sum(x => x.BidAmount);

			var latestBidder = model.Auction.Bids.OrderByDescending(x => x.Timestamp).FirstOrDefault();

			model.LatestBidder = latestBidder != null ? latestBidder.User : null;

			model.Comments = sharedService.GetAllComments(23,model.Auction.ID);

			model.PageTitle = "Auctions Details: " + model.Auction.Title;
			model.PageDescription = model.Auction.Description.Substring(0, 10);
			return View(model);
		}
	}
}

