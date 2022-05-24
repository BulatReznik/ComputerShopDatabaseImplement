using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopDatabaseImplement.Models
{
    //заказы
    public class Order
    {
        public int Id { get; set; }

        ///продавец
        public int SalesmanId { get; set; }
        public virtual Salesman Salesman { get; set; }

        //название заказа
        [Required]
        public string OrderName { get; set; }

        //дата создания заказа
        [Required]
        public DateTime DateOrder { get; set; }

        //связь многие ко многим с партиями товаров
        [ForeignKey("OrderId")]
        public virtual List<ConsignmentOrder> ConsignmentOrders { get; set; }

        //связь многие ко многим с заказами
        [ForeignKey("OrderId")]
        public virtual List<OrderRequest> OrderRequests { get; set; }
    }
}
