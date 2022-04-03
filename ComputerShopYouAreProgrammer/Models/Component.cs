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
        public List<FinalProduct> FinalProducts { get; set; }
    }
}
