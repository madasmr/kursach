using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut
{
	public class OrderDelivery
	{
		public string UniqueCode { get; }
		public string Description { get; }
		public decimal Price { get; }
		public string Commentary { get; }
		public IReadOnlyDictionary<string, string> Parameters { get; }
		public OrderDelivery(string uniqueCode,
							 string description,
							 decimal price,
							 string commentary,
							 IReadOnlyDictionary<string, string> parameters)
		{
			if (string.IsNullOrWhiteSpace(uniqueCode))
				throw new ArgumentException(nameof(uniqueCode));
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentException(nameof(description));
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));
			UniqueCode = uniqueCode;
			Description = description;
			Price = price;
			Commentary = commentary;
			Parameters = parameters;
		}
	}
}
