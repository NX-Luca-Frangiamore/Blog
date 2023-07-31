using Microsoft.EntityFrameworkCore;
using Blog.Db;
namespace Blog.Db
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
       
        public DbSet<Contenuti> contenuti=>Set<Contenuti>();
        public DbSet<Utenti> utenti => Set<Utenti>();


    }
}
