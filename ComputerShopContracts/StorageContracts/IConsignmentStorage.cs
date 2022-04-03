using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopContracts.StorageContracts
{
    public interface IConsignmentStorage
    {
        List<ConsignmentViewModel> GetFullList();
        List<ConsignmentViewModel> GetFilteredList(ConsignmentBindingModel model);
        ConsignmentViewModel GetElement(ConsignmentBindingModel model);
        void Insert(ConsignmentBindingModel model);
        void Update(ConsignmentBindingModel model);
        void Delete(ConsignmentBindingModel model);
    }
}
