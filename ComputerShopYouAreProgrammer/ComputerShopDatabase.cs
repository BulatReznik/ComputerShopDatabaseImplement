using ComputerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerShopDatabaseImplement
{
    public class ComputerShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-UJ3H26AC\SQLEXPRESS;Initial Catalog=ComputerShopDatabase;Integrated Security=True; MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<ComponentPersonalBuild> ComponentPersonalBuilds { set; get; }
        public virtual DbSet<ConsignmentOrder> СonsignmentOrders { set; get; }
        public virtual DbSet<Employee> Employees { set; get; }
        public virtual DbSet<FinalProduct> FinalProducts { set; get; }
        public virtual DbSet<FinalProductComponent> FinalProductComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<OrderRequest> OrderRequests { set; get; }
        public virtual DbSet<PersonalBuild> PersonalBuilds { set; get; }
        public virtual DbSet<Request> Requests { set; get; }
        public virtual DbSet<Salesman> Salesmen { set; get; }
        public virtual DbSet<Consignment> Consignments { set; get; }
    }
}