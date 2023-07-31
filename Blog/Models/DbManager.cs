using Blog.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Blog.Models
{
    public class DbManager : ModelDb
    {
        private readonly Context _context;

        public DbManager(Context context)
        {
            this._context = context;
        }
        public void addContenuto(string id, string titolo, string descrizione)
        {
            throw new NotImplementedException();
        }

        public void addUtente(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contenuti>? get(string id)
        {
            return _context.contenuti.Where(x=>x.id==id).Select(x=>x);

        }
        public Dictionary<string, IEnumerable<Contenuti>> get()
        {
            Dictionary<string, IEnumerable<Contenuti>> r = new Dictionary<string, IEnumerable<Contenuti>>();
            foreach (Utenti p in _context.utenti.Include(p => p.Id))
            {
                r[p.Id] = get(p.Id);
            }
            return r;
        }
        public string getId(string username, string password)
        {
            var a=  _context.utenti.Where(p => (p.username == username && p.password == password)).Select(x => x.Id).FirstOrDefault();
            return a;
        }

        
    }
}
