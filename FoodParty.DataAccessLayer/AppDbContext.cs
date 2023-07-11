using FoodParty.DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FoodParty.DataAccessLayer
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AutoAddDbSetClass<IEntity>(typeof(IEntity).Assembly); // TODO: Aggregate only
        }
    }
}
