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
    public class RequestController : ControllerBase
    {
        private readonly IRequestLogic _requestLogic;
        public RequestController(IRequestLogic requestLogic)
        {
            _requestLogic = requestLogic;
        }
        [HttpGet]
        public List<RequestViewModel> GetRequestList() => _requestLogic.Read(null)?.ToList();

        [HttpGet]
        public RequestViewModel GetRequest(int requestId) => _requestLogic.Read(new RequestBindingModel { Id = requestId })?[0];

        [HttpPost]
        public void CreateOrUpdateRequest(RequestBindingModel model) => _requestLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteRequest(RequestBindingModel model) => _requestLogic.Delete(model);
    }
}
