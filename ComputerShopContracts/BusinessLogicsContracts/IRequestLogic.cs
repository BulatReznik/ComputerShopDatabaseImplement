using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BusinessLogicsContracts
{
    public interface IRequestLogic
    {
        List<RequestViewModel> Read(RequestBindingModel model);
        void CreateRequest(CreateRequestBindingModel model);
        void TakeRequestInWork(ChangeStatusBindingModel model);
        void FinishRequest(ChangeStatusBindingModel model);
        void DeliveryRequest(ChangeStatusBindingModel model);
        void CreateOrUpdate(RequestBindingModel model);
        void Delete(RequestBindingModel model);
    }
}
