using MyDealDouble.Entities;
using MyDealDouble.Services;
using MyDealDouble.Web.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDealDouble.Web.Controllers
{
    public class CategoriesController : Controller
    {
		CategoriesService categoriesService = new CategoriesService();

		[HttpGet]
		public ActionResult Index()
		{
			CategoriesListingViewModel model = new CategoriesListingViewModel();

			model.PageTitle = "Categories";
			model.PageDescription = "Categories Listing Page";

			return View(model);
		}

		public ActionResult Listing()
		{
			CategoriesListingViewModel model = new CategoriesListingViewModel();

			model.Categories = categoriesService.GetAllCategories();

			return PartialView(model);
		}

		[HttpGet]
		public ActionResult Create()
		{
			CategoryViewModel model = new CategoryViewModel();

			return PartialView(model);
		}

		[HttpPost]
		public ActionResult Create(CategoryViewModel model)
		{
			Category category = new Category();
			category.Name = model.Name;
			category.Description = model.Description;

			categoriesService.SaveCategory(category);

			return RedirectToAction("Listing");
		}

		[HttpGet]
		public ActionResult Edit(int ID)
		{
			CategoryViewModel model = new CategoryViewModel();

			var category = categoriesService.GetCategoryByID(ID);

			model.ID = category.ID;
			model.Name = category.Name;
			model.Description = category.Description;

			return PartialView(model);
		}

		[HttpPost]
		public ActionResult Edit(CategoryViewModel model)
		{
			Category category = new Category();
			category.ID = model.ID;
			category.Name = model.Name;
			category.Description = model.Description;

			categoriesService.UpdateCategory(category);

			return RedirectToAction("Listing");
		}

		[HttpPost]
		public ActionResult Delete(Category category)
		{
			categoriesService.DeleteCategory(category);

			return RedirectToAction("Listing");
		}

		[HttpGet]
		public ActionResult Details(int ID)
		{
			CategoryDetailsViewModel model = new CategoryDetailsViewModel();

			model.Category = categoriesService.GetCategoryByID(ID);

			model.PageTitle = "Category Details: " + model.Category.Name;
			model.PageDescription = model.Category.Description.Substring(0, 10);

			return View(model);
		}
	}
}