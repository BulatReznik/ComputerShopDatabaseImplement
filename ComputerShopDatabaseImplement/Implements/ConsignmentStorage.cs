using ComputerShopContracts.BindingModels;
using ComputerShopContracts.StorageContracts;
using ComputerShopContracts.ViewModels;
using ComputerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopDatabaseImplement.Implements
{
    public class ConsignmentStorage : IConsignmentStorage
    {
        public List<ConsignmentViewModel> GetFullList()
        {
            using var context = new ComputerShopDatabase();
            return context.Consignments
            .Include(rec => rec.Salesman)
            .Include(rec => rec.ConsignmentOrders)
            .ThenInclude(rec => rec.Order)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<ConsignmentViewModel> GetFilteredList(ConsignmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDatabase();
            return context.Consignments
            .Include(rec => rec.Salesman)
            .Include(rec => rec.ConsignmentOrders)
            .ThenInclude(rec => rec.Order)
            .Where(rec => rec.ConsignmentName.Equals(model.ConsignmentName) || (rec.SalesmanId == model.SalesmanId))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public ConsignmentViewModel GetElement(ConsignmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDatabase();
            var lesson = context.Consignments
            .Include(rec => rec.Salesman)
            .Include(rec => rec.ConsignmentOrders)
            .ThenInclude(rec => rec.Order)
            .FirstOrDefault(rec => rec.ConsignmentName == model.ConsignmentName || rec.Id == model.Id);
            return lesson != null ? CreateModel(lesson) : null;
        }
        public void Insert(ConsignmentBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Consignment consignment = new Consignment()
                {
                    ConsignmentName = model.ConsignmentName
                };
                context.Consignments.Add(consignment);
                context.SaveChanges();
                CreateModel(model, consignment, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(ConsignmentBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Consignments.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(ConsignmentBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            Consignment element = context.Consignments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Consignments.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Consignment CreateModel(ConsignmentBindingModel model, Consignment consignment, ComputerShopDatabase context)
        {
            consignment.ConsignmentName = model.ConsignmentName;
            consignment.SalesmanId = model.SalesmanId;
            if (model.Id.HasValue)
            {
                var consignmentOrder = context.ConsignmentOrders.Where(rec => rec.ConsignmentId == model.Id.Value).ToList();
                context.ConsignmentOrders.RemoveRange(consignmentOrder.Where(rec =>
               !model.ConsignmentOrders.ContainsKey(rec.OrderId)).ToList());
                context.SaveChanges();
            }
            foreach (var order in model.ConsignmentOrders)
            {
                context.ConsignmentOrders.Add(new ConsignmentOrder
                {
                    ConsignmentId = consignment.Id,
                    OrderId = order.Key,
                });
                context.SaveChanges();
            }
            return consignment;
        }
        private static ConsignmentViewModel CreateModel(Consignment consignment)
        {
            return new ConsignmentViewModel
            {
                Id = consignment.Id,
                ConsignmentName = consignment.ConsignmentName,
                ConsignmentOrders = consignment.ConsignmentOrders.ToDictionary(recLT => recLT.OrderId, recLT => (recLT.Order?.OrderName))
            };
        }
    }
}
