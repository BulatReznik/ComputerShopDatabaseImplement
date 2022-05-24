using ComputerShopContracts.BindingModels;
using ComputerShopContracts.BusinessLogicsContracts;
using ComputerShopContracts.StorageContracts;
using ComputerShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.BusinessLogics
{
    public class SalesmanLogic : ISalesmanLogic
    {
        private readonly ISalesmanStorage _salesmanStorage;
        public SalesmanLogic(ISalesmanStorage SalesmanStorage)
        {
            _salesmanStorage = SalesmanStorage;
        }
        public List<SalesmanViewModel> Read(SalesmanBindingModel model)
        {
            if (model == null)
            {
                return _salesmanStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SalesmanViewModel> { _salesmanStorage.GetElement(model) };
            }
            return _salesmanStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SalesmanBindingModel model)
        {
            var element = _salesmanStorage.GetElement(new SalesmanBindingModel
            {
                Email = model.Email
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть продавец с таким логином");
            }
            if (model.Id.HasValue)
            {
                _salesmanStorage.Update(model);
            }
            else
            {
                _salesmanStorage.Insert(model);
            }
        }
        public void Delete(SalesmanBindingModel model)
        {
            var element = _salesmanStorage.GetElement(new SalesmanBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Продавец не найден");
            }
            _salesmanStorage.Delete(model);
        }

    }
}
