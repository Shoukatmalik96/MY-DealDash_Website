using Microsoft.AspNet.Identity;
using MyDealDouble.Entities;
using MyDealDouble.Services;
using MyDealDouble.Web.viewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDealDouble.Web.Controllers
{
    public class SharedController : Controller
    {

		SharedService service = new SharedService();

		[HttpPost]
		public JsonResult UploadPictures()
		{
			JsonResult result = new JsonResult();

			List<object> picturesJSON = new List<object>();

			var pictures = Request.Files;

			for (int i = 0; i < pictures.Count; i++)
			{
				var picture = pictures[i];

				var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);

				var path = Server.MapPath("~/Content/images/") + fileName;

				picture.SaveAs(path);

				var dbPicture = new Picture();
				dbPicture.URL = fileName;

				int pictureID = service.SavePicture(dbPicture);

				picturesJSON.Add(new { ID = pictureID, pictureURL = fileName });
			}

			result.Data = picturesJSON;

			return result;
		}

		public JsonResult LeaveComment(MyDealDouble.Web.viewModels.CommentViewModal modal)
		{
			JsonResult result = new JsonResult();

			try
			{
				var Comment = new Comment();
				Comment.Text = modal.Text;
				Comment.EntityID = modal.EntityID;
				Comment.RecordID = modal.RecordID;
				Comment.UserID = User.Identity.GetUserId();// This take logged in user Id
				Comment.TimeStamp = DateTime.Now; //Current Server time
				var res = service.LeaveComment(Comment);
				result.Data = new { Success = res };
			}
			catch (Exception ex)
			{
				result.Data = new { Success = false, ex.Message };
				
			}
			return result;
		}
	}
}


