using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.BusinessLogicsContracts;
using ComputerShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController
    {
        private readonly IOrderLogic _orderLogic;

        public OrderController(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        [HttpGet]
        public List<OrderViewModel> GetOrderList() => _orderLogic.Read(null)?.ToList();

        [HttpGet]
        public OrderViewModel GetOrder(int orderId) => _orderLogic.Read(new OrderBindingModel { Id = orderId })?[0];

        [HttpPost]
        public void CreateOrUpdateOrder(OrderBindingModel model) => _orderLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteOrder(OrderBindingModel model) => _orderLogic.Delete(model);

        [HttpPost]
        public void AddOrderConsignments(AddConsignmentsBindingModel model) => _orderLogic.AddConsignments(model);

    }
}
