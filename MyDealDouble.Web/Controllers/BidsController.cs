using Microsoft.AspNet.Identity;
using MyDealDouble.Entities;
using MyDealDouble.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDealDouble.Web.Controllers
{
    public class BidsController : Controller
    {
		BidsService BidsService = new BidsService();

		[HttpPost]
		public JsonResult Bid(int ID)
		{
			JsonResult result = new JsonResult();

			if (User.Identity.IsAuthenticated)
			{
				Bid bid = new Bid();

				bid.AuctionID = ID;
				bid.UserID = User.Identity.GetUserId();
				bid.Timestamp = DateTime.Now;
				bid.BidAmount = 10;

				var bidResult = BidsService.AddBid(bid);

				if (bidResult)
				{
					result.Data = new { Success = true };
				}
				else
					result.Data = new { Success = false, Message = "Unable to add bid to auction." };
			}
			else
			{
				result.Data = new { Success = false, Message = "User needs to login for bids." };
			}

			return result;
		}
	}
}