using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDealDouble.Web.viewModels
{
	public class CommentViewModal
	{
		public string Text { get; set; }

		public int Rating { get; set; }

		public int EntityID { get; set; }

		public int RecordID { get; set; }
	}
}