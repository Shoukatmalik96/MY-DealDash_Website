using MyDealDouble.Data;
using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Services
{
	public class BidsService
	{
		DealDashDataContext context = new DealDashDataContext();

		public bool AddBid(Bid bid)
		{
			context.Bids.Add(bid);
			return context.SaveChanges() > 0;
		}
	}
}
