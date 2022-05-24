using ComputerShopContracts;
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
    public class RequestLogic: IRequestLogic
    {
        private readonly IRequestStorage _requestStorage;
        public RequestLogic(IRequestStorage requestStorage)
        {
            _requestStorage = requestStorage;
        }

        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            if (model == null)
            {
                return _requestStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<RequestViewModel>
                {
                    _requestStorage.GetElement(model)
                };
            }
            return _requestStorage.GetFilteredList(model);
        }

        public void CreateRequest(CreateRequestBindingModel model)
        {
            _requestStorage.Insert(new RequestBindingModel
            {
                Status = RequestStatus.Принята,
                DateRequest = DateTime.Now,
                SalesmanId = model.SalesmanId
            });
        }

        public void DeliveryRequest(ChangeStatusBindingModel model)
        {
            var request = _requestStorage.GetElement(new RequestBindingModel { Id = model.RequestId });
            if (request == null)
            {
                throw new Exception("Заявка не найдена");
            }
            if (request.Status != Enum.GetName(typeof(RequestStatus), 2))
            {
                throw new Exception("Заявка не в статусе \"Готова\"");
            }
            _requestStorage.Update(new RequestBindingModel
            {
                Id = request.Id,
                DateRequest = request.DateRequest,
                DateImplement = request.DateImplement,
                Status = RequestStatus.Выдана,
                SalesmanId =request.SalesmanId,
                Description=request.Description
            });
        }

        public void FinishRequest(ChangeStatusBindingModel model)
        {
            var request = _requestStorage.GetElement(new RequestBindingModel { Id = model.RequestId });
            if (request == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (request.Status != Enum.GetName(typeof(RequestStatus), 1))
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _requestStorage.Update(new RequestBindingModel
            {
                Id = request.Id,
                DateRequest = request.DateRequest,
                DateImplement = request.DateImplement,
                Status = RequestStatus.Готова,
                SalesmanId = request.SalesmanId,
                Description = request.Description

            });
        }


        public void TakeRequestInWork(ChangeStatusBindingModel model)
        {
            var request = _requestStorage.GetElement(new RequestBindingModel { Id = model.RequestId });
            if (request == null)
            {
                throw new Exception("Заявка не найдена");
            }
            if (request.Status != Enum.GetName(typeof(RequestStatus), 0))
            {
                throw new Exception("Заявка не в статусе \"Принятa\"");
            }
            _requestStorage.Update(new RequestBindingModel
            {
                Id = request.Id,
                DateRequest = request.DateRequest,
                DateImplement = request.DateImplement,
                Status = RequestStatus.Готова,
                SalesmanId = request.SalesmanId
            });
        }

        public void Delete(RequestBindingModel model)
        {
            var element = _requestStorage.GetElement(new RequestBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Удаляемый элемент не найден");
            }
            _requestStorage.Delete(model);
        }

        public void CreateOrUpdate(RequestBindingModel model) //TODO
        {
            var element = _requestStorage.GetElement(new RequestBindingModel
            {
                Id = model.Id,
                DateRequest = model.DateRequest,
                DateImplement = model.DateImplement,
                Status = RequestStatus.Готова,
                SalesmanId = model.SalesmanId
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть запрос с таким названием");
            }
            if (model.Id.HasValue)
            {
                _requestStorage.Update(model);
            }
            else
            {
                _requestStorage.Insert(model);
            }
        }
    }
}
