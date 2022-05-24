using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class AddConsignmentsBindingModel
    {
        public int OrderId { get; set; }

        public List<int> ConsignmentsId { get; set; }
    }
}
