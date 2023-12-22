using DesignPattern_ChainOfResponsibility.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern_ChainOfResponsibility.DAL.Context
{
    public class ChainOfResContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; initial Catalog=ChainOfDb; integrated Security=true");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
