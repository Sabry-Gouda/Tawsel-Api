using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tawsel.models;

namespace tawsel.models
{
    public class tawseel : IdentityDbContext<ApplicationUser>
    {
        public tawseel()
        {

        }
        public tawseel(DbContextOptions option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PremissionRoleController>().HasKey(n => new { n.RoleID, n.PageId, n.permissionId });
        }


        public virtual DbSet<Premssion> Premssions { get; set; }
        public virtual DbSet<PremissionRoleController> PremissionRoleControllers { get; set; }
        public virtual DbSet<CustomRole> CustomRoles { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<page> pages { get; set; }
        public virtual DbSet<ShipmentWeight> WeightSettings { get; set; }
        public virtual DbSet<OrderTypes> OrderTypes { get; set; }
        public DbSet<tawsel.models.ShippingType> ShippingType { get; set; }
        public DbSet<tawsel.models.CashType> CashType { get; set; }
        public DbSet<tawsel.models.product> products { get; set; }

    }
}
