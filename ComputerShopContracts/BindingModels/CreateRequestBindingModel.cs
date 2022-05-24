using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class CreateRequestBindingModel
    {
        public int SalesmanId { get; set; }
        public int OrderID { get; set; }
    }
}
