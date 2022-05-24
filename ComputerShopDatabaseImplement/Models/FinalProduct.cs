using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDatabaseImplement.Models
{
    public class FinalProduct
    {
        public int Id { get; set; }

        //название готового товара
        public string FinalProductName { get; set; }

        //количество готовых товаров
        public int Count { get; set; }

        //дата создания готового товара
        public DateTime DateCreate { get; set; }

        //связб с партиями товара
        public int ConsignmentId { get; set; }
        public virtual Consignment Consignment { get; set; }

        //связь с сотрудником
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        //связь с комплектующими
        [ForeignKey("FinalProductId")]
        public List<FinalProductComponent> FinalProductComponents { get; set; }

    }
}
