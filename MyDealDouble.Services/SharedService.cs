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
		public bool LeaveComment(Comment comment)
		{
			context.Comments.Add(comment);
			// Save changes returns now of rows  
			//---** if no of rows are greater than zero then comments are added**------------
			return context.SaveChanges() > 0; 

		}
		public List<Comment> GetAllComments(int entityID,int recordID)
		{
			return context.Comments.Where(x=>x.EntityID == entityID && x.RecordID == recordID).ToList();
		}
	}
}
