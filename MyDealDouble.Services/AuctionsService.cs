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

			var auctions = context.Auctions.AsQueryable();
			if (auctions.Count() > 0 )
			{
				result = auctions.ToList();
			}
			else
			{
				result = new List<Auction>();
			}
			return result;
		}
		public List<Auction> GetPromotedAuctions()
		{
			List<Auction> result = null;
			result = context.Auctions.Take(3).ToList();
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
		public List<Auction> SearchAuctions(int? categoryID, string searchTerm, int? pageNo, int pageSize)
		{
			var auctions = context.Auctions.AsQueryable();

			if (categoryID.HasValue && categoryID.Value > 0)
			{
				auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
			}

			if (!string.IsNullOrEmpty(searchTerm))
			{
				auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
			}

			pageNo = pageNo ?? 1;
			//pageNo = pageNo.HasValue ? pageNo.Value : 1;

			var skipCount = (pageNo.Value - 1) * pageSize;

			return auctions.OrderByDescending(x => x.CategoryID).Skip(skipCount).Take(pageSize).ToList();
		}

		public int GetAuctionCount(int? categoryID, string searchTerm)
		{
			var auctions = context.Auctions.AsQueryable();

			if (categoryID.HasValue && categoryID.Value > 0)
			{
				auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
			}

			if (!string.IsNullOrEmpty(searchTerm))
			{
				auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
			}

			return auctions.Count();
		}
	}
}
