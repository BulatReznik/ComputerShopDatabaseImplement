using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class PersonalBuildBindingModel
    {
        public int? Id { set; get; }
        public string PesonalBuildName { set; get; }
        public DateTime DatePersonalBuild { set; get; }
        public int EmployeeId { get; set; }
        public int RequestId { get; set; }
    }
}
