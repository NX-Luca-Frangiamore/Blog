using Blog.Db;

namespace Blog.Models
{
    public interface ModelDb
    {

        public IEnumerable<Contenuti>? get(int id);//(titolo,descrizione)
        public Dictionary<int,IEnumerable<Contenuti>> get();//id utente,(titolo,descrizione)
        public void addContenuto(int id,string titolo,string descrizione);
        public int getId(string username,string password);//id utente
        public void addUtente(string username,string password);
    }
}
