using Microsoft.AspNet.Identity.EntityFramework;
using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Data
{
	public class DealDashDataContext: IdentityDbContext<DealDoubleUser>
	{
		public DealDashDataContext():base("name=DealDashDataContext")
		{

		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Auction> Auctions { get; set; }
		public DbSet<Picture> Pictures { get; set; }
		public DbSet<Bid> Bids { get; set; }
		public DbSet<AuctionPicture> AuctionPictures { get; set; }
		public DbSet<Comment> Comments { get; set; }

		public static DealDashDataContext Create()
		{
			return new DealDashDataContext();
		}
	}
}
