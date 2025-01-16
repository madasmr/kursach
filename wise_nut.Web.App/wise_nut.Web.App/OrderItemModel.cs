using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut.Web.App
{
	public class OrderItemModel
	{
		public int ProductId { get; set; }

		public string Title { get; set; }

		public int Count { get; set; }

		public decimal Price { get; set; }
	}
}
