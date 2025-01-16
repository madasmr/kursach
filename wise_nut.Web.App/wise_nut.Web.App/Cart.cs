﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut.Web.App
{
	public class Cart
	{
		public int OrderId { get; }
		public int TotalCount { get; }
		public decimal TotalPrice { get; }
		public Cart(int orderId, int totalCount, decimal totalPrice)
		{
			OrderId = orderId;
			TotalCount = totalCount;
			TotalPrice = totalPrice;
		}
	}
}
