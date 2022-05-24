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
        public string ConsignmentName { get; set; }

        //связь с готовыми товарами
        [ForeignKey("ConsignmentId")]
        public List<FinalProduct> FinalProducts { get; set; }

        //связь с заказами
        [ForeignKey("ConsignmentId")]
        public List<ConsignmentOrder> ConsignmentOrders { get; set; }
        public int SalesmanId { get; set; }
        public virtual Salesman Salesman { get; set; }

    }
}
