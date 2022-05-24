using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDatabaseImplement.Models
{
    public class Component
    {
        public int Id { get; set; }

        //название комплектующих
        [Required]
        public string ComponentName { get; set; }

        //цена комплектующих
        [Required]
        public decimal Price { get; set; }

        //готовые товары в которых присутствуют эти комплектующие
        [ForeignKey("ComponentId")]
        public List<FinalProductComponent> FinalProductsComponents { get; set; }

        //персональные сборки в которых присутствуют эти комплектующие
        [ForeignKey("ComponentId")]
        public List<ComponentPersonalBuild> ComponentPersonalBuilds { get; set; }

        //сотрудник
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
