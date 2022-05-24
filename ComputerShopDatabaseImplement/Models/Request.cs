using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDatabaseImplement.Models
{
    //заявки
    public class Request
    {
        public int Id { get; set; }

        //название заявки
        [Required]
        public string RequestName { get; set; }

        //описание заявки
        [Required]
        public string Description { get; set; }

        //дата создания заявки
        [Required]
        public DateTime DateRequest { get; set; }

        //к какому продавйу привязана заявка
        public int SalesmanId { get; set; }
        public virtual Salesman Salesman { get; set; }

        //связь многие ко многим с заказом
        [ForeignKey("RequestId")]
        public virtual List<OrderRequest> OrderRequests { get; set; }

        //список персональных сборок привязанных к заявке
        [ForeignKey("RequestId")]
        public virtual List<PersonalBuild> PersonalBuilds { get; set; }
    }
}
