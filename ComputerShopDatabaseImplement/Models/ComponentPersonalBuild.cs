using System.ComponentModel.DataAnnotations;

namespace ComputerShopDatabaseImplement.Models
{
    //комплектующие, персональные сборки
    public class ComponentPersonalBuild
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int PersonalBuildId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Components { get; set; }
        public virtual PersonalBuild PersonalBuilds { get; set; }

    }
}
