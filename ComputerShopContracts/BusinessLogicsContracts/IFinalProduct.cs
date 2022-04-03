using ComputerShopContracts.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BusinessLogicsContracts
{
    public interface IFinalProduct
    {
        List<FinalProductViewModel> Read(FinalProductBindingModel model);
        void CreateOrUpdate(FinalProductBindingModel model);
        void Delete(FinalProductBindingModel model);
    }
}
