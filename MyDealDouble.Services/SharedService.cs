using MyDealDouble.Data;
using MyDealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Services
{
	public class SharedService
	{
		DealDashDataContext context = new DealDashDataContext();


		public int SavePicture(Picture picture)
		{
			context.Pictures.Add(picture);
			context.SaveChanges();
			return picture.ID;
		}
	}
}
