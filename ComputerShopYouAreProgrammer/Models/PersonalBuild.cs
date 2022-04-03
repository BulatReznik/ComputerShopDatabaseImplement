using System;

namespace ComputerShopDatabaseImplement.Models
{
    //персональная сборка
    public class PersonalBuild
    {
        public int Id { set; get; }

        //название персональной сборки
        public string PesonalBuildName { set; get; }

        //дата создания персональной сборки
        public DateTime DatePersonalBuild { set; get; }

        //к какому сотруднику привязана персональная сборка
        public int EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }

        //к какому запросу привязана персональная сборка
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
    }
}
