using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDatabaseImplement.Models
{
    //cотрудники
    public class Employee
    {
        public int Id { get; set; }

        ///имя сотрудника
        [Required]
        public string EmployeeName { get; set; }

        //email
        [Required]
        public string Email { get; set; }

        //пароль
        [Required]
        public string Password { get; set; }

        //список персональных сборок привязанных к сотруднику
        [ForeignKey("EmployeeId")]
        public List<PersonalBuild> PersonalBuilds { get; set; }

        //список готовых продуктов привязанных к сотруднику
        [ForeignKey("EmployeeId")]
        public List<FinalProduct> FinalProducts { get; set; }
    }
}
