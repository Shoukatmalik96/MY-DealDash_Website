using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MyDealDouble.Services;
using MyDealDouble.Web.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDealDouble.Web.Controllers
{
    public class DashboardController : Controller
    {
		DashboardService service = new DashboardService();
		//**---------SETUP USER MANAGER------------**//

		private DealDoubleUserManager _userManager;

		public DashboardController()
		{
		}

		public DashboardController(DealDoubleUserManager userManager)
		{
			UserManager = userManager;
		}

		public DealDoubleUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<DealDoubleUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		public ActionResult Index()
        {
			DashboardViewModel model = new DashboardViewModel();

			model.UserCount = service.GetUserCount();
			model.AuctionsCount = service.GetUserAuctionCount();
			model.BidsCount = service.GetBidsCount();

			return View(model);
        }
		public ActionResult Users(string roleID, string searchTerm, int? pageNo)
		{
			UsersViewModel model = new UsersViewModel();

			model.PageTitle = "Users";
			model.PageDescription = "Users Listing Page";

			model.RoleID = roleID;
			model.SearchTerm = searchTerm;
			model.PageNo = pageNo;
			model.Roles = new List<IdentityRole>();

			return View(model);
		}
		public ActionResult UsersListing(int? roleID, string searchTerm, int? pageNo)
		{
			var pageSize = 2;

			UsersListingViewModel model = new UsersListingViewModel();

			//**--GETTING USER BY USING USERMANAGER--**//
			model.Users = UserManager.Users.ToList();
			model.RoleID = roleID;
			model.SearchTerm = searchTerm;

			model.Pager = new Pager(10, pageNo, pageSize);

			return PartialView(model);

		}
	}
}