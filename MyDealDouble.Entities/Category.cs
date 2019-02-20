using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDealDouble.Entities
{
	public class Category:BaseEntity
	{
		
		public string Name { get; set; }
		public string Description { get; set; }

		public List<Auction> Auctions { get; set; }
	}
}
