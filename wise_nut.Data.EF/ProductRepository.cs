using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace wise_nut.Data.EF
{
	class ProductRepository : IProductRepository
	{
		private readonly DbContextFactory dbContextFactory;
		public ProductRepository(DbContextFactory dbContextFactory)
		{
			this.dbContextFactory = dbContextFactory;
		}

		public Product[] GetAllByIds(IEnumerable<int> productIds)
		{
			var dbContext = dbContextFactory.Create(typeof(ProductRepository));
			return dbContext.Products
							.Where(product => productIds.Contains(product.Id))
							.AsEnumerable()
							.Select(Product.Mapper.Map)
							.ToArray();
		}

		public Product[] GetAllByTypeOrTitle(string typeOrTitle)
		{
			var dbContext = dbContextFactory.Create(typeof(ProductRepository));
			var parameter = new SqlParameter("@typeOrTitle", typeOrTitle);
			return dbContext.Products
							.FromSqlRaw("SELECT * FROM Products WHERE CONTAINS((Type, Title), @typeOrTitle)",
										parameter)
							.AsEnumerable()
							.Select(Product.Mapper.Map)
							.ToArray();
		}

		public Product GetById(int id)
		{
			var dbContext = dbContextFactory.Create(typeof(ProductRepository));
			var dto = dbContext.Products
							   .Single(product => product.Id == id);
			return Product.Mapper.Map(dto);
		}
	}
}
