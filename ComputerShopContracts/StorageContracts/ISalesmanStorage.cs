using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopContracts.StorageContracts
{
    public interface ISalesmanStorage
    {
        List<SalesmanViewModel> GetFullList();
        List<SalesmanViewModel> GetFilteredList(SalesmanBindingModel model);
        SalesmanViewModel GetElement(SalesmanBindingModel model);
        void Insert(SalesmanBindingModel model);
        void Update(SalesmanBindingModel model);
        void Delete(SalesmanBindingModel model);
    }
}
