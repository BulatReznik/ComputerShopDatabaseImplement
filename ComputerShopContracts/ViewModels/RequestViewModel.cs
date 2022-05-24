using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public int SalesmanId { get; set; }

        [DisplayName("Название заявки")]
        public string RequestName { get; set; }

        [DisplayName("Имя Продавца")]
        public string SalesmanName { get; set; }

        [DisplayName("Дата создания заявки")]
        public DateTime DateRequest { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Статус")]
        public string Status { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
        public Dictionary<int, string> OrderRequests { get; set; }

    }
}
