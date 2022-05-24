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
    public class OrderLogic: IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IConsignmentStorage _consignmentStorage;

        public OrderLogic(IOrderStorage orderStorage, IConsignmentStorage consignmentStorage)
        {
            _orderStorage = orderStorage;
            _consignmentStorage = consignmentStorage;
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel
            {
                OrderName = model.OrderName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть заказ с таким названием");
            }
            if (model.Id.HasValue)
            {
                _orderStorage.Update(model);
            }
            else
            {
                _orderStorage.Insert(model);
            }
        }

        public void Delete(OrderBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Заказы не найденЫ");
            }
            _orderStorage.Delete(model);
        }

        public void AddConsignments(AddConsignmentsBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });

            if (order == null)
            {
                throw new Exception("Склад не найден");
            }

            foreach (var consignmentId in model.ConsignmentsId)
            {
                var consignment = _consignmentStorage.GetElement(new ConsignmentBindingModel
                {
                    Id = consignmentId
                });

                if (consignment == null)
                {
                    throw new Exception("Компонент не найден");
                }

                if (!order.ConsignmentOrders.ContainsKey(consignmentId))
                {
                    order.ConsignmentOrders.Add(consignmentId, consignment.ConsignmentName);
                }
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                OrderName = order.OrderName,
                DateOrder = DateTime.Now,
                SalesmanId = order.SalesmanId,
                OrderConsignments = order.ConsignmentOrders
            });
        }
    }
}
