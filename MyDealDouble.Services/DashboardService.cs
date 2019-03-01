using MyDealDouble.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Services
{
	public class DashboardService
	{
		DealDashDataContext context = new DealDashDataContext();

		public int GetUserCount()
		{
			return context.Users.Count();
		}
		public int GetUserAuctionCount()
		{
			return context.Auctions.Count();
		}
		public int GetBidsCount()
		{
			return context.Bids.Count();
		}
		
	}
}
