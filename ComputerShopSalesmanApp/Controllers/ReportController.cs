using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShopSalesmanApp.Controllers
{
    public class ReportController : Controller
    { 
         private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        public IActionResult ReportWord()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        public IActionResult ReportExcel()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        public IActionResult ReportPDF()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

    }
}
