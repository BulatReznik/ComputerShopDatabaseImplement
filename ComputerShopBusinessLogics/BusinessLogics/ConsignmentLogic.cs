using ComputerShopContracts.BindingModels;
using ComputerShopContracts.BusinessLogicsContracts;
using ComputerShopContracts.StorageContracts;
using ComputerShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopBusinessLogics.BusinessLogics
{
    public class ConsignmentLogic : IConsignmentLogic
    {
        private readonly IConsignmentStorage _consignmentStorage;
        public ConsignmentLogic(IConsignmentStorage consignmenStorage)
        {
            _consignmentStorage = consignmenStorage;
        }
        public List<ConsignmentViewModel> Read(ConsignmentBindingModel model)
        {
            if (model == null)
            {
                return _consignmentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ConsignmentViewModel> { _consignmentStorage.GetElement(model)};
            }
            return _consignmentStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ConsignmentBindingModel model)
        {
            var element = _consignmentStorage.GetElement(new ConsignmentBindingModel
            {
                ConsignmentName = model.ConsignmentName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть партия товаров с таким названием");
            }
            if (model.Id.HasValue)
            {
                _consignmentStorage.Update(model);
            }
            else
            {
                _consignmentStorage.Insert(model);
            }
        }
        public void Delete(ConsignmentBindingModel model)
        {
            var element = _consignmentStorage.GetElement(new ConsignmentBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Партия товаров не найдена");
            }
            _consignmentStorage.Delete(model);
        }
    }
}
