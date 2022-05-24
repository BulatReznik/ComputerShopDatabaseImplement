using ComputerShopContracts.BindingModels;
using ComputerShopContracts.StorageContracts;
using ComputerShopContracts.ViewModels;
using ComputerShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopDatabaseImplement.Implements
{
    public class SalesmanStorage: ISalesmanStorage
    {
        public List<SalesmanViewModel> GetFullList()
        {
            using (var context = new ComputerShopDatabase())
                return context.Salesmans.Select(CreateModel).ToList();
        }

        public List<SalesmanViewModel> GetFilteredList(SalesmanBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDatabase();
            return context.Salesmans.Where(rec => rec.Email == model.Email && rec.Password == model.Password).Select(CreateModel).ToList();
        }

        public SalesmanViewModel GetElement(SalesmanBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ComputerShopDatabase();
            var salesman = context.Salesmans.FirstOrDefault(rec => rec.Email == model.Email || rec.Id == model.Id);
            return salesman != null ? CreateModel(salesman) : null;
        }

        public void Insert(SalesmanBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            context.Salesmans.Add(CreateModel(model, new Salesman()));
            context.SaveChanges();
        }

        public void Update(SalesmanBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            var element = context.Salesmans.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Продавец не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(SalesmanBindingModel model)
        {
            using var context = new ComputerShopDatabase();
            Salesman salesman = context.Salesmans.FirstOrDefault(rec => rec.Id == model.Id);
            if (salesman != null)
            {
                context.Salesmans.Remove(salesman);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Продавец не найден");
            }
        }

        private Salesman CreateModel(SalesmanBindingModel model, Salesman salesman)
        {
            salesman.SalesmanName = model.SalesmanName;
            salesman.Email = model.Email;
            salesman.Password = model.Password;
            return salesman;
        }
        private static SalesmanViewModel CreateModel(Salesman salesman)
        {
            return new SalesmanViewModel
            {
                Id = salesman.Id,
                Email = salesman.Email,
                SalesmanName = salesman.SalesmanName,
                Password = salesman.Password
            };
        }
    }
}
