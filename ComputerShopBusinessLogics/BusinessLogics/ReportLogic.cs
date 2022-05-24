using ComputerShopBusinessLogics.OfficePackage;
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
    public class ReportLogic: IReportLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IConsignmentStorage _consignmentStorage;
        private readonly IRequestStorage _requestStorage;

        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToPdf _saveToPdf;

        public List<ReportOrderFinalProductViewModel> GetOrderFinalProducts()
        {
            throw new NotImplementedException();
        }

        public List<ReportOrderRequestConsignmentViewModel> GetOrderRequestConsignments(ReportBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveOrderRequestConsignmentsToPdfFile(ReportBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void SaverderFinalProductsToExcelFile(ReportBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void SaverderFinalProductsToWordFile(ReportBindingModel model)
        {
            throw new NotImplementedException();
        }



        //private readonly IFinalProductStorage _finalProduct;  //TODO

    }
}
