using wise_nut.Web.App;
using System.Collections.Generic;
using System.Linq;

namespace wise_nut.Web.App
{
	public class ProductService
	{
		private readonly IProductRepository productRepository;

		public ProductService(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		public ProductModel GetById(int id)
		{
			var product = productRepository.GetById(id);

			return Map(product);
		}

		public IReadOnlyCollection<ProductModel> GetAllByQuery(string query)
		{
			var products = productRepository.GetAllByTypeOrTitle(query);

			return products.Select(Map).ToArray();
		}

		private ProductModel Map(Product product)
		{
			return new ProductModel
			{
				Id = product.Id,
				Title = product.Title,
				Type = product.Type,
				Description = product.Description,
				Price = product.Price,
			};
		}
	}
}
