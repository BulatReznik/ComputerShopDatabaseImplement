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
    public class ConsignmentController
    {
        private readonly IConsignmentLogic _consignmentLogic;
        private readonly IFinalProductLogic _finalProductLogic;

        public ConsignmentController(IConsignmentLogic consignmentLogic, IFinalProductLogic finalProductLogic)
        {
            _consignmentLogic = consignmentLogic;
            _finalProductLogic = finalProductLogic;
        }

        [HttpGet]
        public List<ConsignmentViewModel> GetConsignmentList() => _consignmentLogic.Read(null)?.ToList();

        [HttpGet]
        public List<FinalProductViewModel> GetLoanProgramList() => _finalProductLogic.Read(null)?.ToList();

        [HttpGet]
        public FinalProductViewModel GetFinalProduct(int finalProductId) => _finalProductLogic.Read(new FinalProductBindingModel { Id = finalProductId })?[0];


        [HttpGet]
        public ConsignmentViewModel GetConsignment(int consignmentId) => _consignmentLogic.Read(new ConsignmentBindingModel { Id = consignmentId })?[0];

        [HttpPost]
        public void CreateOrUpdateConsignment(ConsignmentBindingModel model) => _consignmentLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteConsignment(ConsignmentBindingModel model) => _consignmentLogic.Delete(model);

    }
}
