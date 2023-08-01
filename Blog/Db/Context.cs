using Microsoft.EntityFrameworkCore;
using Blog.Db;
namespace Blog.Db
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
       
        public DbSet<Contenuto> contenuti=>Set<Contenuto>();
        public DbSet<Utente> utenti => Set<Utente>();


    }
}
