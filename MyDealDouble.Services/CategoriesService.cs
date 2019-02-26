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

		public List<Category> GetAllCategories()
		{
			return context.Categories.ToList();
		}
		public Category GetCategoryByID(int ID)
		{
			return context.Categories.Find(ID);
		}
		public void SaveCategory(Category category)
		{
			context.Categories.Add(category);
			context.SaveChanges();
		}
		public void UpdateCategory(Category category)
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
