using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDatabaseImplement.Models
{
    //продавец
    public class Salesman
    {
        public int Id { get; set; }

        //имя продавца
        [Required]
        public string SalesmanName { get; set; }

        //email
        [Required]
        public string Email { get; set; }

        //пароль
        [Required]
        public string Password { get; set; }

        //Cписок заявок у этого продавца
        [ForeignKey("SalesmanId")]
        public List<Request> Requests { get; set; }

        //Cписок заказов у этого продавца
        [ForeignKey("SalesmanId")]
        public List<Order> Orders { get; set; }

        //Cписок партиц товаров у этого продавца
        [ForeignKey("SalesmanId")]
        public List<Consignment> Consignments { get; set; }
    }
}
