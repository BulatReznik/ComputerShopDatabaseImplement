using System.ComponentModel;

namespace ComputerShopContracts.ViewModels
{
    public class SalesmanViewModel
    {
        public int Id { get; set; }

        [DisplayName("Продавец")]
        public string SalesmanName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
