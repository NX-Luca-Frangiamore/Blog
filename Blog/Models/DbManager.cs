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
        public async void addContenuto(int id, string _titolo, string _descrizione)
        {
            if (_titolo == null || _descrizione == null) return;
            Contenuto c=new Contenuto{titolo=_titolo, descrizione=_descrizione, EF_idUtente=id};
            this._context.contenuti.Add(c);
            this._context.SaveChanges();
        }

        public async void addUtente(string _username, string _password)
        {
            if (_username == null || _password == null) return;
            Utente utente=new Utente { username= _username, password = _password };
            this._context.utenti.Add(utente);
            this._context.SaveChanges();
        }

        public async Task<IEnumerable<Contenuto>?> get(int id)
        {
            return _context.contenuti.Where(x=>x.EF_idUtente==id);

        }
        public async Task<Dictionary<int, IEnumerable<Contenuto>>> get()
        {
            Dictionary<int, IEnumerable<Contenuto>> r = new Dictionary<int, IEnumerable<Contenuto>>();
            foreach (Utente p in _context.utenti.Include(p => p.Id))
            {

                r[p.Id] = await get(p.Id);
            }
            return r;
        }
        public async Task<int> getId(string username, string password)
        {
            if (username == null || password == null) return 0;
            var a=  _context.utenti.Where(p => (p.username == username && p.password == password)).Select(x => x.Id).FirstOrDefault();
            return a;
        }

        
    }
}
