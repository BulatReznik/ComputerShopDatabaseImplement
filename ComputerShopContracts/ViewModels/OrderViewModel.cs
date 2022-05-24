using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название заказа")]
        public string OrderName { get; set; }

        [DisplayName("Время создания заказа")]
        public DateTime DateOrder { get; set; }
        public Dictionary<int, string> ConsignmentOrders { get; set; }

        public int SalesmanId { get; set; }

    }
}
