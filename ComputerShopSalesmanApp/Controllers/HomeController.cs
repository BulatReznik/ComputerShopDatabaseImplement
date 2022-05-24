using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;
using ComputerShopSalesmanApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShopSalesmanApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Salesman);
        }

        [HttpPost]
        public void Privacy(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                APISalesman.PostRequest("api/salesman/updatedata", new SalesmanBindingModel
                {
                    Id = Program.Salesman.Id,
                    SalesmanName = fio,
                    Email = login,
                    Password = password
                });
                Program.Salesman.SalesmanName = fio;
                Program.Salesman.Email = login;
                Program.Salesman.Password = password;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.Salesman = APISalesman.GetRequest<SalesmanViewModel>($"api/salesman/login?login={login}&password={password}");
                if (Program.Salesman == null)
                {
                    throw new Exception("Неверный логин/пароль");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                APISalesman.PostRequest("api/salesman/register", new SalesmanBindingModel
                {
                    SalesmanName = fio,
                    Email = login,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        public IActionResult Consignment()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APISalesman.GetRequest<List<ConsignmentViewModel>>($"api/salesman/GetSalesmanConsignmentList?salesmanId={Program.Salesman.Id}"));
        }

        [HttpGet]
        public IActionResult ConsignmentCreate()
        {
            ViewBag.FinalProducts = APISalesman.GetRequest<List<FinalProductViewModel>>("api/client/FinalProductList");
            return View();
        }

        [HttpPost]
        public void ConsignmentCreate(string consignmentName, string passport, string telephone, List<int> finalProductsId)
        {
            List<FinalProductViewModel> finalProduct = new List<FinalProductViewModel>();
            foreach (var finalProductId in finalProductsId)
            {
                finalProduct.Add(APISalesman.GetRequest<FinalProductViewModel>($"api/client/GetFinalProductViewModel?finalProductViewModelId={finalProductId}"));
            }
            if (!string.IsNullOrEmpty(consignmentName) && !string.IsNullOrEmpty(passport) && !string.IsNullOrEmpty(telephone) && finalProduct != null)
            {
                APISalesman.PostRequest("api/consignment/CreateOrUpdateClient", new ConsignmentBindingModel
                {
                    ConsignmentName = consignmentName,
                    ////orders?
                    //FinalProducts = finalProduct.ToDictionary(x => x.Id, x => x.FinalProductName), //SalesmanId TODO
                    SalesmanId = Program.Salesman.Id
                });
                Response.Redirect("Consignment");
                return;
            }
            throw new Exception("Название заказа");
        }

        [HttpGet]
        public IActionResult ConsignmentUpdate(int сonsignmentId)
        {
            ViewBag.Client = APISalesman.GetRequest<ConsignmentViewModel>($"api/consignment/GetConsignment?consignmentId={сonsignmentId}");
            ViewBag.FinalProducts = APISalesman.GetRequest<List<FinalProductViewModel>>("api/consignment/GetConsignmentList");
            return View();
        }

        [HttpPost]
        public void ConsignmentUpdate(int consignmentId, string clientFIO, string passport, string telephone, List<int> finalProductsId)
        {
            if (!string.IsNullOrEmpty(clientFIO) && !string.IsNullOrEmpty(passport) && !string.IsNullOrEmpty(telephone) && finalProductsId != null)
            {
                var consignment = APISalesman.GetRequest<ConsignmentViewModel>($"api/consignment/GetConsignment?consignmentId={consignmentId}");
                if (consignment == null)
                {
                    return;
                }
                List<FinalProductViewModel> finalProducts = new List<FinalProductViewModel>();
                foreach (var finalProductId in finalProductsId)
                {
                    finalProducts.Add(APISalesman.GetRequest<FinalProductViewModel>($"api/consignment/GetFinalProduct?finalProductId={finalProductId}"));
                }
                APISalesman.PostRequest("api/consignment/CreateOrUpdateConsignment", new ConsignmentBindingModel
                {
                    Id = consignment.Id,
                    ConsignmentName = consignment.ConsignmentName,
                    //FinalProducts = finalProducts.ToDictionary(x => x.Id, x => x.FinalProductName),
                    SalesmanId = Program.Salesman.Id
                });
                Response.Redirect("Consignment");
                return;
            }
            throw new Exception("Введите Название партии товаров");
        }

        [HttpGet]
        public void ConsignmentDelete(int consignmentId)
        {
            var consignment = APISalesman.GetRequest<ConsignmentViewModel>($"api/consignment/GetConsignment?consignmentId={consignmentId}");
            APISalesman.PostRequest("api/consignment/DeleteConsignment", consignment);
            Response.Redirect("Consignment");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult Order()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APISalesman.GetRequest<List<OrderViewModel>>($"api/salesman/GetSalesmanOrderList?salesmanId={Program.Salesman.Id}"));
        }

        [HttpGet]
        public IActionResult OrderCreate()
        {
            return View();
        }

        [HttpPost]
        public void OrderCreate(string orderName, DateTime orderDate)
        {
            if (!string.IsNullOrEmpty(orderName)) //сделать дата не нулл?
            {
                APISalesman.PostRequest("api/order/CreateOrUpdateOrder", new OrderBindingModel
                {
                    OrderName = orderName,
                    DateOrder = orderDate,
                    OrderConsignments = new Dictionary<int, string>(),
                    SalesmanId = Program.Salesman.Id
                });
                Response.Redirect("Order");
                return;
            }
            throw new Exception("Введите Название и дату заказа");
        }

        [HttpGet]
        public IActionResult OrderUpdate(int orderId)
        {
            ViewBag.Order = APISalesman.GetRequest<OrderViewModel>($"api/order/GetOrder?orderId={orderId}");
            return View();
        }

        [HttpPost]
        public void OrderUpdate(int orderId, string orderName)
        {
            if (!string.IsNullOrEmpty(orderName)) //сделать дата не нулл?
            {
                var order = APISalesman.GetRequest<OrderViewModel>($"api/order/GetOrder?orderId={orderId}");
                if (order == null)
                {
                    return;
                }
                APISalesman.PostRequest("api/order/CreateOrUpdateOrder", new OrderBindingModel
                {
                    Id = order.Id,
                    OrderName = orderName,
                    DateOrder = DateTime.Now,
                    //OrderConsignments = order.ConsignmentOrders,
                    SalesmanId = Program.Salesman.Id
                });
                Response.Redirect("Order");
                return;
            }
            throw new Exception("Введите наименование вклада и процентную ставку");
        }

        [HttpGet]
        public void OrderDelete(int orderId)
        {
            var order = APISalesman.GetRequest<OrderViewModel>($"api/order/GetOrder?orderId={orderId}");
            APISalesman.PostRequest("api/order/DeleteOrder", order);
            Response.Redirect("Order");
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult Request2()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APISalesman.GetRequest<List<RequestViewModel>>($"api/salesman/GetSalesmanRequestList?salesmanId={Program.Salesman.Id}"));
        }

        [HttpGet]
        public IActionResult RequestCreate()
        {
            ViewBag.Orders = APISalesman.GetRequest<List<OrderViewModel>>("api/order/GetOrderList");
            return View();
        }

        [HttpPost]
        public void RequestCreate(string requestName, string description)
        {
            if (!string.IsNullOrEmpty(requestName) && !string.IsNullOrEmpty(description))
            {
                APISalesman.PostRequest("api/request/CreateOrUpdateRequest", new RequestBindingModel
                {
                    RequestName = requestName,
                    Description = description,
                    OrderRequests = new Dictionary<int, (string, int)>(),
                    //DateRequest,
                    //DateImplement,
                    //DateFrom,
                    //DateTo,
                    //RequestStatus,
                    SalesmanId = Program.Salesman.Id
                });
                Response.Redirect("Request");
                return;
            }
            throw new Exception("Введите сумму пополнения и выберите вклад");
        }

        [HttpGet]
        public IActionResult RequestUpdate(int requestId)
        {
            ViewBag.Orders = APISalesman.GetRequest<List<OrderViewModel>>("api/order/GetOrderList");
            ViewBag.Request = APISalesman.GetRequest<RequestViewModel>($"api/request/GetRequest?requestId={requestId}");
            return View();
        }

        [HttpPost]
        public void RequestUpdate(int requestId, string requestName, string description)
        {
            if (!string.IsNullOrEmpty(requestName) && !string.IsNullOrEmpty(description))
            {
                var request = APISalesman.GetRequest<RequestViewModel>($"api/request/GetRequest?requestId={requestId}");
                if (request == null)
                {
                    return;
                }
                APISalesman.PostRequest("api/request/CreateOrUpdateRequest", new RequestBindingModel
                {
                    Id = requestId,
                    RequestName = requestName,
                    Description = description,
                    OrderRequests = new Dictionary<int, (string, int)>(),
                    //DateRequest, TODO
                    //DateImplement,
                    //DateFrom,
                    //DateTo,
                    //RequestStatus,
                    SalesmanId = Program.Salesman.Id
                });
                Response.Redirect("Request");
                return;
            }
            throw new Exception("Введите сумму пополнения и выберите вклад");
        }

        [HttpGet]
        public void RequestDelete(int requestId)
        {
            var request = APISalesman.GetRequest<RequestViewModel>($"api/request/GetRequest?requestId={requestId}");
            APISalesman.PostRequest("api/request/DeleteRequest", request);
            Response.Redirect("Request");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult AddOrderConsignments()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Orders = APISalesman.GetRequest<List<OrderViewModel>>("api/order/GetOrderList");
            ViewBag.Consignments = APISalesman.GetRequest<List<ConsignmentViewModel>>($"api/salesman/GetSalesmanConsignmentList?salesmanId={Program.Salesman.Id}");
            return View();
        }

        [HttpPost]
        public void AddOrderConsignments(int orderId, List<int> consignmentsId)
        {
            if (orderId != 0 && consignmentsId != null)
            {
                APISalesman.PostRequest("api/order/OrderConsignments", new AddConsignmentsBindingModel
                {
                    OrderId = orderId,
                    ConsignmentsId = consignmentsId
                });
                Response.Redirect("Order");
                return;
            }
            throw new Exception("Выберите заказ и партии товаров");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult AddRequestOrders()
        {
            if (Program.Salesman == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Orders = APISalesman.GetRequest<List<OrderViewModel>>("api/order/GetOrderList");
            ViewBag.Consignments = APISalesman.GetRequest<List<ConsignmentViewModel>>($"api/salesman/GetSalesmanConsignmentList?salesmanId={Program.Salesman.Id}");
            return View();
        }

        [HttpPost]
        public void AddRequestOrders(int requestId, List<int> ordersId)
        {
            if (requestId != 0 && ordersId != null)
            {
                APISalesman.PostRequest("api/order/OrderConsignments", new AddOrdersBindingModel
                {
                    RequestId = requestId,
                    OrdersId = ordersId
                });
                Response.Redirect("Request");
                return;
            }
            throw new Exception("Выберите заявку и заказ");
        }
    }
}
