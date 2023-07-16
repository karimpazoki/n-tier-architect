using FoodParty.DomainLayer.Contracts;
using FoodParty.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodParty.DataAccessLayer
{
    public class AppDbContext : DbContext, IAppDbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.AutoAddDbSetClass<IEntity>(typeof(IEntity).Assembly); // TODO: Aggregate only
            modelBuilder.Entity<DealProject>();
        }
    }
}
