using ComputerShopContracts.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BusinessLogicsContracts
{
    public interface IEmployeeLogic
    {
        //List<EmployeeViewModel> Read(EmployeeBindingModel model);
        void CreateOrUpdate(EmployeeBindingModel model);
        void Delete(EmployeeBindingModel model);
    }
}
