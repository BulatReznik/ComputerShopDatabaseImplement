using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDatabaseImplement.Models
{
    //партия товаров
    public class Consignment
    {
        public int Id { get; set; }

        //Название партии товаров
        [Required]
        public string СonsignmentName { get; set; }

        //связь с готовыми товарами
        [ForeignKey("СonsignmentId")]
        public List<FinalProduct> FinalProducts { get; set; }

        //связь с заказами
        [ForeignKey("СonsignmentId")]
        public List<ConsignmentOrder> СonsignmentOrders { get; set; }

    }
}
