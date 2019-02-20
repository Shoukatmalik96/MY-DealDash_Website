using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Entities
{
	public class Auction: BaseEntity
	{
		public virtual Category Category { get; set; }
		public int CategoryID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal ActualAmount { get; set; }
		public DateTime StartingDate { get; set; }
		public DateTime EndingDate { get; set; }

		public virtual List<AuctionPicture> AuctionPictures { get; set; }
	}
}


