using ComputerShopContracts.BindingModels;
using ComputerShopContracts.BusinessLogicsContracts;
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
    public class OrderStorage: IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new ComputerShopDatabase();
            return context.Orders
            .Include(rec => rec.Salesman)
            .Select(CreateModel)
            .ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDatabase();
            return context.Orders
                .Include(rec => rec.Salesman)
            .Where(rec => rec.OrderName.Contains(model.OrderName) || (rec.SalesmanId == model.SalesmanId))
            .Select(CreateModel)
            .ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDatabase();
            var order = context.Orders
                .Include(rec => rec.Salesman)
            .FirstOrDefault(rec => rec.OrderName == model.OrderName || rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            context.Orders.Add(CreateModel(model, new Order()));
            context.SaveChanges();
        }

        public void Update(OrderBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Заказ не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(OrderBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Заказ не найден");
            }
        }

        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.DateOrder = model.DateOrder;
            order.OrderName = model.OrderName;
            order.SalesmanId = model.SalesmanId;
            return order;
        }
        private static OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                DateOrder = DateTime.Now,
                OrderName = order.OrderName
            };
        }
    }
}

