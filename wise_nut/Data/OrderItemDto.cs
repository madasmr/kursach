﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut.Data
{
	public class OrderItemDto
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public decimal Price { get; set; }
		public int Count { get; set; }
		public OrderDto Order { get; set; }
	}
}
