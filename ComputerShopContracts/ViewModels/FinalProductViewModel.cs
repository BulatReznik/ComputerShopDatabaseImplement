using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.ViewModels
{
    public class FinalProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название кредитной программы")]
        public string FinalProductName { get; set; }




        //количество готовых товаров
        //public int Count { get; set; }

        //дата создания готового товара
        public DateTime DateCreate { get; set; }

        //связб с партиями товара
        public int ConsignmentId { get; set; }
        //public virtual Consignment Consignment { get; set; }

        //связь с сотрудником
        //public int EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }

        ////связь с комплектующими
        //[ForeignKey("FinalProductId")]
        //public List<FinalProductComponent> FinalProductComponents { get; set; }

    }
}
