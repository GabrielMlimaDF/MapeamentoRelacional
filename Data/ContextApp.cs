using Microsoft.EntityFrameworkCore;
using Models.Data.Mappings;
using Models.Models;

namespace Models.Data
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StatusOperador> StatusOperadores { get; set; }
        public DbSet<Operador> Operadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StatusOperadorMap());
            modelBuilder.ApplyConfiguration(new OperadorMap());
           
               }

    }
}