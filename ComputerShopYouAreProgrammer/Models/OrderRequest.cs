namespace ComputerShopDatabaseImplement.Models
{
    //заказ, запрос
    public class OrderRequest
    {
        public int Id { get; set; }
        public int СonsignmentId { get; set; }
        public int OrderId { get; set; }
        public virtual Consignment Сonsignment { get; set; }
        public virtual Order Order { get; set; }
    }
}