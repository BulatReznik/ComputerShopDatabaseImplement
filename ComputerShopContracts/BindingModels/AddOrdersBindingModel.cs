using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class AddOrdersBindingModel
    {
        public int RequestId { get; set; }

        public List<int> OrdersId { get; set; }
    }
}
