using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut
{
    public interface IProductRepository
    {
		Product[] GetAllByIds(IEnumerable<int> productIds);
		Product[] GetAllByTypeOrTitle(string typeOrTitle);
        Product GetById(int id);
    }
}
