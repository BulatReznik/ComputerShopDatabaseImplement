using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class ConsignmentBindingModel
    {
        public int Id { get; set; }
        public string СonsignmentName { get; set; }
        public Dictionary<int, (string, int)> FinalProducts { get; set; }
        public Dictionary<int, (string, int)> СonsignmentOrders { get; set; }

    }
}
