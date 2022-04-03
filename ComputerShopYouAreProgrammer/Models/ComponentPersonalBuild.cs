namespace ComputerShopDatabaseImplement.Models
{
    //компоненты, персональные сборки
    public class ComponentPersonalBuild
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int PersonalBuildId { get; set; }
        public virtual Component Components { get; set; }
        public virtual PersonalBuild PersonalBuilds { get; set; }
    }
}
