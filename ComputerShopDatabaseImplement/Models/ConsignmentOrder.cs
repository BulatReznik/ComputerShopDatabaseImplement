using System.ComponentModel.DataAnnotations;

namespace ComputerShopDatabaseImplement.Models
{
    //партия товаров, заказ
    public class ConsignmentOrder
    {
        public int Id { get; set; }
        public int ConsignmentId { get; set; }
        public int OrderId { get; set; }
        public virtual Consignment Consignment { get; set; }
        public virtual Order Order { get; set; }
    }
}
