using wise_nut;
using System.Linq;

namespace StoreMemory
{
    public class ProductRepository : IProductRepository
    {
        private readonly Product[] products = new[]
        {
            new Product(1, "Кешью", "Орехи", "Вкусные орехи ура ура", 1.1m),
            new Product(2, "Фундук", "Орехи", "Вкусные орехи ура ура", 1.1m),
            new Product(3, "Фисташка", "Орехи", "Вкусные орехи ура ура", 1.1m),
        };

		public Product[] GetAllByIds(IEnumerable<int> productIds)
		{
			var foundProducts = from product in products
                                join productId in productIds on product.Id equals productId
                                select product;
            return foundProducts.ToArray();
		}

		public Product[] GetAllByTypeOrTitle(string query)
        {
            return products.Where(product => product.Title.Contains(query)
                                          || product.Type.Contains(query))
                                          .ToArray();
        }
        public Product GetById(int id)
        {
            return products.Single(product => product.Id == id);
        }
    } 
}