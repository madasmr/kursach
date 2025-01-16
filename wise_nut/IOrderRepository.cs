using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut
{
    public interface IOrderRepository
    {
        Order Create();
        Order GetById(int id);
        void Update(Order order);
    }
}
