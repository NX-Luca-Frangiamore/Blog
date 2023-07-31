using Blog.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NuGet.Protocol.Plugins;

namespace Blog.Models
{
    public class DbManager : ModelDb
    {
        private readonly Context _context;

        public DbManager(Context context)
        {
            this._context = context;
        }
        public void addContenuto(int id, string _titolo, string _descrizione)
        {
            if (_titolo == null || _descrizione == null) return;
            Contenuti c=new Contenuti{titolo=_titolo, descrizione=_descrizione, EF_idUtente=id};
            this._context.contenuti.Add(c);
            this._context.SaveChanges();
        }

        public void addUtente(string username, string password)
        {
            if (username == null || password == null) return;
            Console.WriteLine("CIAOOO");
        }

        public IEnumerable<Contenuti>? get(int id)
        {
            return _context.contenuti.Where(x=>x.EF_idUtente==id);

        }
        public Dictionary<int, IEnumerable<Contenuti>> get()
        {
            Dictionary<int, IEnumerable<Contenuti>> r = new Dictionary<int, IEnumerable<Contenuti>>();
            foreach (Utenti p in _context.utenti.Include(p => p.Id))
            {
                r[p.Id] = get(p.Id);
            }
            return r;
        }
        public int getId(string username, string password)
        {
            if (username == null || password == null) return 0;
            var a=  _context.utenti.Where(p => (p.username == username && p.password == password)).Select(x => x.Id).FirstOrDefault();
            return a;
        }

        
    }
}
