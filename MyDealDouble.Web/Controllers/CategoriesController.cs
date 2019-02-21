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
		CategoriesService CategoriesService = new CategoriesService();
		public ActionResult Index()
        {
			CategoriesListingViewModels models = new CategoriesListingViewModels();
			models.PageTitle = "Cateories";
			models.PageDescription = "Categories Listing";
			return View(models);
        }
		public ActionResult Listing()
		{
			CategoriesListingViewModels model = new CategoriesListingViewModels();
			model.categories = CategoriesService.GetCategories();
			return PartialView(model);

		}

		[HttpGet]
		public ActionResult Create()
		{
			CategoriesViewModel model = new CategoriesViewModel();
			model.PageTitle = "Category";
			model.PageDescription = "Categories page";
			return PartialView(model);
		}
		[HttpPost]
		public ActionResult Create(Category category)
		{
			CategoriesService.saveCategory(category);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit(int ID)
		{
			CategoriesViewModel model = new CategoriesViewModel();
			model.category = CategoriesService.GetCategoryById(ID);
			return PartialView(model);
		}
		[HttpPost]
		public ActionResult Edit(Category category)
		{
			CategoriesService.EditCategory(category);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Delete(int ID)
		{
			CategoriesViewModel model = new CategoriesViewModel();
			model.category = CategoriesService.GetCategoryById(ID);
			return PartialView(model);
		}
		[HttpPost]
		public ActionResult Delete(Category category)
		{
			CategoriesService.DeleteCategory(category);
			return RedirectToAction("Index");
		}
	}
}