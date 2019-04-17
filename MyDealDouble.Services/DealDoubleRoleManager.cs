using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MyDealDouble.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Services
{
	public class DealDoubleRoleManager:RoleManager<IdentityRole>
	{
		public DealDoubleRoleManager(IRoleStore<IdentityRole, string> roleStore) : base(roleStore)
		{

		}

		public static DealDoubleRoleManager Create(IdentityFactoryOptions<DealDoubleRoleManager> options ,IOwinContext context)
		{
			return new DealDoubleRoleManager(new RoleStore<IdentityRole>(context.Get<DealDashDataContext>()));
		}
	}
}
