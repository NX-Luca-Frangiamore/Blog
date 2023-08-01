using Blog.Db;

namespace Blog.Models
{
    public interface ModelDb
    {

        public Task<IEnumerable<Contenuto>?> get(int id);//(titolo,descrizione)
        public Task<Dictionary<int,IEnumerable<Contenuto>>> get();//id utente,(titolo,descrizione)
        public void addContenuto(int id,string titolo,string descrizione);
        public Task<int> getId(string username,string password);//id utente
        public void addUtente(string username,string password);
    }
}
