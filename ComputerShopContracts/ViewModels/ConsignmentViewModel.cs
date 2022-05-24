using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.ViewModels
{
    public class ConsignmentViewModel
    {
        public int Id { get; set; }
        public int FinalProductId { get; set; }

        [DisplayName("Название партии товаров")]
        public string ConsignmentName { get; set; }
        public Dictionary<int, string> ConsignmentOrders { get; set; }

    }
}
