using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BindingModels
{
    public class FinalProductBindingModel
    {
        public int Id { get; set; }
        public string FinalProductName { get; set; }
        public int Count { get; set; }
        public DateTime DateCreate { get; set; }
        public int СonsignmentId { get; set; }
        public int PersonalBuildId { get; set; }
        public Dictionary<int, (string, int)> FinalProductComponents { get; set; }
    }
}
