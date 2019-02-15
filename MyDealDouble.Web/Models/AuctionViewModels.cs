using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDealDouble.Web.Models
{
	public class AuctionListViewModel
	{
		public List<Auction> Auctions { get; set; } = new List<Auction>();
	}
}