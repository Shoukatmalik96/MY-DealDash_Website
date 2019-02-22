using MyDealDouble.Data;
using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Services
{
	public class AuctionsService
	{
		DealDashDataContext context = new DealDashDataContext();

		public Auction GetAuctionById(int Id)
		{
			Auction result = null;
			result = context.Auctions.Find(Id);
			return result;
		}
		public List<Auction> GetAuctions()
		{
			List<Auction> result = null;
			result = context.Auctions.ToList();
			return result;
		}
		public List<Auction> GetPromotedAuctions()
		{
			List<Auction> result = null;
			result = context.Auctions.Take(4).ToList();
			return result;
		}
		public void saveAuction(Auction auction)
	    {
			context.Auctions.Add(auction);
			context.SaveChanges();
	    }
		public void UpdateAuction(Auction auction)
		{
			context.Entry(auction).State = System.Data.Entity.EntityState.Modified;
			context.SaveChanges();
			
		}
		public void DeleteAuction(Auction auction)
		{
			context.Entry(auction).State = System.Data.Entity.EntityState.Deleted;
			context.SaveChanges();

		}
	}
}
