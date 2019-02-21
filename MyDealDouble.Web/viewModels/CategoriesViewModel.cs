using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDealDouble.Web.viewModels
{
	public class CategoriesViewModel:PageViewModel
	{
		public Category  category { get; set; }
	}
	public class CategoriesListingViewModels : PageViewModel
	{
		public List<Category> categories { get; set; }

	}
}