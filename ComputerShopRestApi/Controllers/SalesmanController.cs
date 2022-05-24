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
    public class SalesmanController : ControllerBase
    {
        private readonly ISalesmanLogic _salesmanLogic;
        private readonly IRequestLogic _requestLogic;
        private readonly IOrderLogic _orderLogic;
        private readonly IConsignmentLogic _consignmentLogic;
        public SalesmanController(ISalesmanLogic logic, IRequestLogic requestLogic, IOrderLogic orderLogicLogic, IConsignmentLogic consignmentLogic)
        {
            _salesmanLogic = logic;
            _requestLogic = requestLogic;
            _orderLogic = orderLogicLogic;
            _consignmentLogic = consignmentLogic;
        }

        [HttpGet]
        public SalesmanViewModel Login(string login, string password)
        {
            var list = _salesmanLogic.Read(new SalesmanBindingModel
            {
                Email = login,
                Password = password
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        [HttpPost]
        public void Register(SalesmanBindingModel model) => _salesmanLogic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(SalesmanBindingModel model) => _salesmanLogic.CreateOrUpdate(model);

        [HttpGet]
        public List<RequestViewModel> GetSalesmanRequestList(int salesmanId) => _requestLogic.Read(new RequestBindingModel { SalesmanId = salesmanId });

        [HttpGet]
        public List<OrderViewModel> GetSalesmanOrderList(int salesmanId) => _orderLogic.Read(new OrderBindingModel { SalesmanId = salesmanId });

        [HttpGet]
        public List<ConsignmentViewModel> GetSalesmanConsignmentList(int salesmanId) => _consignmentLogic.Read(new ConsignmentBindingModel { SalesmanId = salesmanId });

    }
}
