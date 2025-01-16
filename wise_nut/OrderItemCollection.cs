﻿using wise_nut.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace wise_nut
{
	public class OrderItemCollection : IReadOnlyCollection<OrderItem>
	{
		private readonly OrderDto orderDto;
		private readonly List<OrderItem> items;
		public OrderItemCollection(OrderDto orderDto)
		{
			if (orderDto == null)
				throw new ArgumentNullException(nameof(orderDto));
			this.orderDto = orderDto;
			items = orderDto.Items
							.Select(OrderItem.Mapper.Map)
							.ToList();
		}
		public int Count => items.Count;
		public IEnumerator<OrderItem> GetEnumerator()
		{
			return items.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return (items as IEnumerable).GetEnumerator();
		}
		public OrderItem Get(int productId)
		{
			if (TryGet(productId, out OrderItem orderItem))
				return orderItem;
			throw new InvalidOperationException("Product not found.");
		}
		public bool TryGet(int productId, out OrderItem orderItem)
		{
			var index = items.FindIndex(item => item.ProductId == productId);
			if (index == -1)
			{
				orderItem = null;
				return false;
			}
			orderItem = items[index];
			return true;
		}
		public OrderItem Add(int productId, decimal price, int count)
		{
			if (TryGet(productId, out OrderItem orderItem))
				throw new InvalidOperationException("Product already exists.");
			var orderItemDto = OrderItem.DtoFactory.Create(orderDto, productId, price, count);
			orderDto.Items.Add(orderItemDto);
			orderItem = OrderItem.Mapper.Map(orderItemDto);
			items.Add(orderItem);
			return orderItem;
		}
		public void Remove(int productId)
		{
			var index = items.FindIndex(item => item.ProductId == productId);
			if (index == -1)
				throw new InvalidOperationException("Can't find product to remove from order.");
			orderDto.Items.RemoveAt(index);
			items.RemoveAt(index);
		}
	}
}
