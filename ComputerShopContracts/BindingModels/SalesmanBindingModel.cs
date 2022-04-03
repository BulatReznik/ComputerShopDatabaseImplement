using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopContracts.BindingModels
{
    public class SalesmanBindingModel
    {
        public int? Id { get; set; }
        public string SalesmanName { set; get; }
        public string Email { set; get; }
        public string Password { get; set; }
    }
}
