using ComputerShopContracts.StorageContracts;
using ComputerShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopDatabaseImplement.Models;

namespace ComputerShopDatabaseImplement.Implements
{
    public class RequestStorage: IRequestStorage
    {
        public List<RequestViewModel> GetFullList()
        {
            using var context = new ComputerShopDatabase();
            return context.Requests
                .Include(rec => rec.Salesman)
                .Include(rec => rec.OrderRequests)
                .ThenInclude(rec => rec.Order)
                .Select(CreateModel)
                .ToList();
        }
        public List<RequestViewModel> GetFilteredList(RequestBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ComputerShopDatabase();
            return context.Requests
                .Include(rec => rec.Salesman)
                .Include(rec => rec.OrderRequests)
                .ThenInclude(rec => rec.Order)
                .Where(rec => (rec.SalesmanId == model.SalesmanId || (rec.DateRequest >= model.DateFrom && rec.DateRequest <= model.DateTo)))
                .Select(CreateModel)
                .ToList();
        }
        public RequestViewModel GetElement(RequestBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ComputerShopDatabase();
            var request = context.Requests
                .Include(rec => rec.Salesman)
                .Include(rec => rec.OrderRequests)
                .ThenInclude(rec => rec.Order)
                .FirstOrDefault(rec => rec.Id == model.Id);
            return request != null ? CreateModel(request) : null;
        }
        public void Insert(RequestBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Request request = new Request()
                {
                    RequestName = model.RequestName
                };
                context.Requests.Add(request);
                context.SaveChanges();
                CreateModel(model, request, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(RequestBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var request = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);

                if (request == null)
                {
                    throw new Exception("Заявка не найдена");
                }

                CreateModel(model, request, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(RequestBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            var patient = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
            Request element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Requests.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Request CreateModel(RequestBindingModel model, Request request, ComputerShopDatabase context)
        {
            request.RequestName = model.RequestName;
            request.SalesmanId = model.SalesmanId.Value;
            if (model.Id.HasValue)
            {
                var disciplineTypeReporting = context.OrderRequests.Where(rec =>
               rec.RequestId == model.Id.Value).ToList();
                context.OrderRequests.RemoveRange(disciplineTypeReporting.Where(rec =>
               !model.OrderRequests.ContainsKey(rec.OrderId)).ToList());
                context.SaveChanges();
            }
            foreach (var pc in model.OrderRequests)
            {
                context.OrderRequests.Add(new OrderRequest
                {
                    RequestId = request.Id,
                    OrderId = pc.Key,
                });
                context.SaveChanges();
            }
            return request;
        }
        private static RequestViewModel CreateModel(Request request)
        {
            return new RequestViewModel
            {
                Id = request.Id,
                RequestName = request.RequestName,
                OrderRequests = request.OrderRequests.ToDictionary(recTD => recTD.OrderId,
               recTD => recTD.Order?.OrderName)
            };
        }
    }
}
