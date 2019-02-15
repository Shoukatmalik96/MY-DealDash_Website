﻿using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Data
{
	public class DealDashDataContext:DbContext
	{
		public DealDashDataContext():base("name=DealDashDataContext")
		{

		}

		public DbSet<Auction> Auctions { get; set; }
	}
}