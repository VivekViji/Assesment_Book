using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment_Book.Model
{
	public class Book
	{
		public string Publisher { get; set; }
		public string Title { get; set; }
		public string AuthorLastName { get; set; }
		public string AuthorFirstName { get; set; }
		public decimal Price { get; set; }
		public decimal TotalPriceofAllBooks { get; set; }	
		public string MlaCitation { get; set; }
		public string ChicagoCitation { get; set; }
	}

	

}
