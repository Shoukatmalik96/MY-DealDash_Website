using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Entities
{
	public class Auction
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string pictureURL { get; set; }
		public string Description { get; set; }
		public decimal ActualAmount { get; set; }
		public DateTime StartingDate { get; set; }
		public DateTime EndingDate { get; set; }
	}
}


