using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class ConsignmentBindingModel
    {
        public int? Id { get; set; }
        public string ConsignmentName { get; set; }
        public Dictionary<int, string> ConsignmentOrders { get; set; }
        public int SalesmanId { get; set; }

    }
}
