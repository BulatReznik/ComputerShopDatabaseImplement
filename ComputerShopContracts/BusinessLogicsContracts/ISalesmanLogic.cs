using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BusinessLogicsContracts
{
    public interface ISalesmanLogic
    {
        List<SalesmanViewModel> Read(SalesmanBindingModel model);
        void CreateOrUpdate(SalesmanBindingModel model);
        void Delete(SalesmanBindingModel model);
    }
}
