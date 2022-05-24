using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.ViewModels
{
    public class ReportOrderRequestConsignmentViewModel
    {
        public string OrderName { get; set; }
        public string RequestName { get; set; }
        public string ConsignmentName { get; set; }
        public DateTime DateRequest { get; set; }
    }
}
