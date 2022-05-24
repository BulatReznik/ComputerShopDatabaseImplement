using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BusinessLogicsContracts
{
    public interface IFinalProductLogic
    {
        List<FinalProductViewModel> Read(FinalProductBindingModel model);
        void CreateOrUpdate(FinalProductBindingModel model);
        void Delete(FinalProductBindingModel model);
    }
}
