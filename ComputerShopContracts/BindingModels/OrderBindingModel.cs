using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public string OrderName { get; set; }
        public DateTime DateOrder { get; set; }
        public int SalesmanId { get; set; }
        public Dictionary<int, string> OrderConsignments { get; set; }
    }
}
