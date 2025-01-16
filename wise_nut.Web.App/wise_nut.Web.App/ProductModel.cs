using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut.Web.App
{
	public class ProductModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
}
