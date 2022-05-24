using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.ViewModels
{
    public class ReportOrderFinalProductViewModel
    {
        public string OrderName { get; set; }
        public List<Tuple<string, DateTime>> FinalProducts { get; set; }

    }
}
