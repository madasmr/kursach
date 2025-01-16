using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut.Data
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string Title { get; set;  }
		public string Type { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
}
