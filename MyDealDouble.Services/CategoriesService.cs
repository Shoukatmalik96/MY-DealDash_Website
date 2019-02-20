using MyDealDouble.Data;
using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Services
{
	public class CategoriesService
	{
		DealDashDataContext context = new DealDashDataContext();

		public Category GetAuctionById(int Id)
		{
			Category result = null;
			result = context.Categories.Find(Id);
			return result;
		}
		public List<Category> GetCategories()
		{
			List<Category> result = null;
			result = context.Categories.ToList();
			return result;
		}
		public List<Category> GetPromotedCategories()
		{
			List<Category> result = null;
			result = context.Categories.Take(4).ToList();
			return result;
		}
		public void saveCategory(Category category)
		{
			context.Categories.Add(category);
			context.SaveChanges();
		}
		public void EditCategory(Category category)
		{
			context.Entry(category).State = System.Data.Entity.EntityState.Modified;
			context.SaveChanges();

		}
		public void DeleteCategory(Category category)
		{
			context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
			context.SaveChanges();

		}
	}
}
