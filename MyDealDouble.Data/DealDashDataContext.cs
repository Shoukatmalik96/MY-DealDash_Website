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
		public DealDashDataContext():base("name=DealDoubleConnectionString")
		{
			// Re strict the Database Initializer to Use Our Database initializer instead of default initializer
			Database.SetInitializer<DealDashDataContext>(new DealDoubleDBInitializer());
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Auction> Auctions { get; set; }
		public DbSet<Picture> Pictures { get; set; }
		public DbSet<AuctionPicture> AuctionPictures { get; set; }
		public DbSet<Bid> Bids { get; set; }
		public DbSet<Comment> Comments { get; set; }

		public static DealDashDataContext Create()
		{
			return new DealDashDataContext();
		}

		//**----THREE STRATEGIES OF DATABSE INITIALIZER-------**//(Default - Strategy)

		//**----STRATEGY 1  { In this strategy entity framework check database if database exist follow that database and if database not exist will generate the new database}-------**//
		//CreateDatabaseIfNotExist

		//**----STRATEGY 2 { Agr hum ye strategy use karen gye to phir hame koi migration kar ne ki zarorat nahi pare gye. Entity framework khud karegye ye sare cheezen }-------**//
		//DropCreateDataseIfModalChanges

		//**----STRATEGY 3  { In this strategy every time when we start our project the existing databse will be deleted and new database will be generated }-------**//
		//DropCreateDatabaseAlways
	}
}
