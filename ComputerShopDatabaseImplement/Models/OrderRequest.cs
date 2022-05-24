using System.ComponentModel.DataAnnotations;

namespace ComputerShopDatabaseImplement.Models
{
    //заказ, запрос
    public class OrderRequest
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int OrderId { get; set; }
        public virtual Request Request { get; set; }
        public virtual Order Order { get; set; }
    }
}