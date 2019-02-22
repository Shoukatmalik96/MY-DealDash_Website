using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDealDouble.Web.viewModels
{
	public class CategoriesListingViewModel : PageViewModel
	{
		public List<Category> Categories { get; set; }
	}

	public class CategoriesViewModel : PageViewModel
	{
		public List<Category> AllCategories { get; set; }
	}

	public class CategoryDetailsViewModel : PageViewModel
	{
		public Category Category { get; set; }
	}


	public class CategoryViewModel : PageViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public List<Auction> Auctions { get; set; }
	}
}