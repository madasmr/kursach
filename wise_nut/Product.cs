using System.Text.RegularExpressions;
using wise_nut.Data;
using System;

namespace wise_nut
{
	public class Product
	{
		private readonly ProductDto dto;
		public int Id => dto.Id;
		public string Title
		{
			get => dto.Title;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException(nameof(Title));
				dto.Title = value.Trim();
			}
		}
		public string Type
		{
			get => dto.Type;
			set => dto.Type = value;
		}
		public string Description
		{
			get => dto.Description;
			set => dto.Description = value;
		}
		public decimal Price
		{
			get => dto.Price;
			set => dto.Price = value;
		}

		internal Product(ProductDto dto)
		{
			this.dto = dto;
		}

		public static class DtoFactory
		{
			public static ProductDto Create(string title,
										 string description,
										 decimal price)
			{
				if (string.IsNullOrWhiteSpace(title))
					throw new ArgumentException(nameof(title));
				return new ProductDto
				{
					Title = title.Trim(),
					Description = description?.Trim(),
					Price = price,
				};
			}
		}
		public static class Mapper
		{
			public static Product Map(ProductDto dto) => new Product(dto);
			public static ProductDto Map(Product domain) => domain.dto;
		}
	}
}
