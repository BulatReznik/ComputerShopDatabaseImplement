using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopContracts.BusinessLogicsContracts
{
    public interface IReportLogic


    {   
        //получение списка персональных сборок по выбранным заказам
        List<ReportOrderFinalProductViewModel> GetOrderFinalProducts();
        
        //получение списка  заказов за определенный период с партиями товаров и заявками
        List<ReportOrderRequestConsignmentViewModel> GetOrderRequestConsignments(ReportBindingModel model);

        /// <summary>
        /// Сохранение списка персональных сборок по выбранным заказам в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaverderFinalProductsToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение списка персональных сборок по выбранным заказам в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaverderFinalProductsToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrderRequestConsignmentsToPdfFile(ReportBindingModel model);

    }
}
