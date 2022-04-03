using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class RequestBindingModel
    {
        public int Id { get; set; }
        public string RequestName { get; set; }
        public string Description { get; set; }
        public DateTime DateRequest { get; set; }
        public int SalesmanId { get; set; }
        public Dictionary<int, (string, int)> OrderRequests { get; set; }
        public Dictionary<int, (string, int)> PersonalBuilds { get; set; }
    }
}
