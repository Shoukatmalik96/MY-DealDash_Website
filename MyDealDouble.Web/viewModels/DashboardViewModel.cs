using Microsoft.AspNet.Identity.EntityFramework;
using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MyDealDouble.Web.viewModels
{
	public class DashboardViewModel:PageViewModel
	{
		public int Page { get; set; }
		public int UserCount { get; set; }
		public int AuctionsCount { get; set; }
		public int BidsCount { get; set; }
	}
	public class UsersViewModel:PageViewModel
	{
		public string SearchTerm { get; set; }
		public string RoleID { get; set; }
		public List<IdentityRole> Roles { get; set; }
		public int? PageNo { get; set; }
	}
	public class UsersListingViewModel : PageViewModel
	{
		public List<DealDoubleUser> Users { get; set; }
		public Pager Pager { get; set; }
		public object RoleID { get; set; }
		public string Name { get; set; }
		public string SearchTerm { get;  set; }
	}
	public class RolesListingViewModel : PageViewModel
	{
		public List<IdentityRole> Roles { get; set; }
		public Pager Pager { get; set; }
		public string roleName { get; set; }
		public string SearchTerm { get; set; }
	}
	public class UsersDetailsViewModel : PageViewModel
	{
		public DealDoubleUser User { get; set; }
		public Pager Pager { get; set; }
		public object RoleID { get; set; }
		public string Name { get; set; }
		public string SearchTerm { get; set; }
	}
	public class UserRolesViewModel : PageViewModel
	{
		public DealDoubleUser User { get; set; }
		//public Pager Pager { get; set; }
		//public object RoleID { get; set; }
		//public string Name { get; set; }
		//public string SearchTerm { get; set; }
		public List<IdentityRole> AvailableRoles { get; set; } = new List<IdentityRole>();
		public List<IdentityRole> UserRoles { get; set; } = new List<IdentityRole>();
		
	}
}