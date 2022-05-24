using System.ComponentModel.DataAnnotations;

namespace ComputerShopDatabaseImplement.Models
{
    public class FinalProductComponent
    {
        public int Id { get; set; }
        public int FinalProductId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual FinalProduct FinalProduct { get; set; }
        public virtual Component Component { get; set; }
    }
}
