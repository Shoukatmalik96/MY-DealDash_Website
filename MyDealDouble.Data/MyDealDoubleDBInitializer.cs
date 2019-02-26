using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Data
{
	public class MyDealDoubleDBInitializer : CreateDatabaseIfNotExists<DealDashDataContext>
	{
		protected override void Seed(DealDashDataContext context)
		{
			SeedRoles(context);
			SeedUsers(context);
		}

		public void SeedRoles(DealDashDataContext context)
		{
			List<IdentityRole> rolesIDealDouble = new List<IdentityRole>();

			rolesIDealDouble.Add(new IdentityRole() { Name = "Administrator" });
			rolesIDealDouble.Add(new IdentityRole() { Name = "Moderator" });
			rolesIDealDouble.Add(new IdentityRole() { Name = "User" });

			var rolesStore = new RoleStore<IdentityRole>(context);
			var rolesManager = new RoleManager<IdentityRole>(rolesStore);

			foreach (IdentityRole role in rolesIDealDouble)
			{
				if (!rolesManager.RoleExists(role.Name))
				{
					var result = rolesManager.Create(role);

					if (result.Succeeded) continue;
				}
			}
		}

		public void SeedUsers(DealDashDataContext context)
		{
			var usersStore = new UserStore<DealDoubleUser>(context);
			var usersManager = new UserManager<DealDoubleUser>(usersStore);

			DealDoubleUser admin = new DealDoubleUser();
			admin.Email = "admin@email.com";
			admin.UserName = "admin";
			var password = "admin123";

			if (usersManager.FindByEmail(admin.Email) == null)
			{
				var result = usersManager.Create(admin, password);

				if (result.Succeeded)
				{
					//add necessary roles to admin
					usersManager.AddToRole(admin.Id, "Administrator");
					usersManager.AddToRole(admin.Id, "Moderator");
					usersManager.AddToRole(admin.Id, "User");
				}
			}
		}
	}
}
