using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDealDouble.Web.viewModels
{
	public class AuctionsListingViewModels : PageViewModel
	{
		public List<Auction> Auctions { get; set; }
		
	}
	public class AuctionsViewModels:PageViewModel
	{
		public List<Auction> AllAuctions { get; set; }
		public List<Auction> PromotedAuctions { get; set; }
	}
}