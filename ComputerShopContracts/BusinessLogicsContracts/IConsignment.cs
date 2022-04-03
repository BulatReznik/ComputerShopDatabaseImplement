using ComputerShopContracts.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BusinessLogicsContracts
{
    public interface IConsignment
    {
        List<ConsignmentViewModel> Read(ConsignmentBindingModel model);
        void CreateOrUpdate(ConsignmentBindingModel model);
        void Delete(ConsignmentBindingModel model);
    }
}
