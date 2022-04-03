using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class EmployeeBindingModel
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Dictionary<int, (string, int)> PersonalBuilds { get; set; }
        public Dictionary<int, (string, int)> FinalProducts { get; set; }
    }
}
