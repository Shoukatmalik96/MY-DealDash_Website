using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MyDealDouble.Services;
using MyDealDouble.Web.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyDealDouble.Web.Controllers
{
	public class DashboardController : Controller
	{
		DashboardService service = new DashboardService();
		//**---------SETUP USER MANAGER------------**//

		private DealDoubleUserManager _userManager;
		private DealDoubleRoleManager _roleManager;

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
		public DealDoubleRoleManager RoleManager
		{
			get
			{
				return _roleManager ?? HttpContext.GetOwinContext().GetUserManager<DealDoubleRoleManager>();
			}
			private set
			{
				_roleManager = value;
			}
		}

		public DashboardController()
		{
		}

		public DashboardController(DealDoubleUserManager userManager, DealDoubleRoleManager roleManager)
		{
			UserManager = userManager;
			RoleManager = roleManager;
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
			model.Roles = RoleManager.Roles.ToList();
			return View(model);
		}
		public ActionResult UsersListing(string roleID, string searchTerm, int? pageNo)
		{
			var pageSize = 2;

			UsersListingViewModel model = new UsersListingViewModel();
			//**--GETTING USER BY USING USERMANAGER--**//
			var roles = RoleManager.Roles.ToList();
			model.RoleID = roleID;
			model.SearchTerm = searchTerm;
			var users = UserManager.Users.ToList();
			if (!string.IsNullOrEmpty(roleID))
			{
				users = users.Where(x => x.Roles.FirstOrDefault(y => y.RoleId == roleID) != null).ToList();
			}
			if (!string.IsNullOrEmpty(searchTerm))
			{
				users = users.Where(x => x.Email.ToLower().Contains(searchTerm.ToLower()) ||x.UserName.ToLower().Contains(searchTerm.ToLower())).ToList();
			}
			pageNo = pageNo ?? 1;
			var skipCount = (pageNo.Value - 1) * pageSize;
			model.Users = users.Skip(skipCount).Take(pageSize).ToList();
			model.Pager = new Pager(10, pageNo, pageSize);
			return PartialView(model);

		}

		public async Task<ActionResult> UserDetaisl(string UserID)
		{
			UsersDetailsViewModel model = new UsersDetailsViewModel();
			var user = await UserManager.FindByIdAsync(UserID);
			if (user != null)
			{
				model.User = user;
			}
			return View(model);
		}
		public ActionResult RolesListing(string searchTerm, int? pageNo)
		{
			var pageSize = 1;
			RolesListingViewModel model = new RolesListingViewModel();
			model.SearchTerm = searchTerm;
			var roles = RoleManager.Roles.ToList();
			if (!string.IsNullOrEmpty(searchTerm))
			{
				roles = roles.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
			}
			pageNo = pageNo ?? 1;
			var skipCount = (pageNo.Value - 1) * pageSize;
			model.Roles = roles.OrderBy(x => x.Name).Skip(skipCount).Take(pageSize).ToList();
			model.Pager = new Pager(roles.Count(), pageNo, pageSize);
			return PartialView(model);

		}
		
	}
}

