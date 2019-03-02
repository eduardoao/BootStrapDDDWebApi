using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Data.Mapping;


namespace  Data.Context
{
    public class DataAccessContext: DbContext
    {
        //Injeção de dependência
        public DataAccessContext(DbContextOptions<DataAccessContext> options): base(options)
        {
        }

        public DataAccessContext()
        {                
        }
                       

        public DbSet<Usuario> Usuarios { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration.GetConnectionString("DataBaseConnection"));
            }
        }

    }
}
