using Blog.Db;

namespace Blog.Models
{
    public interface ModelDb
    {

        public IEnumerable<Contenuti>? get(string id);//(titolo,descrizione)
        public Dictionary<string,IEnumerable<Contenuti>> get();//id utente,(titolo,descrizione)
        public void addContenuto(string id,string titolo,string descrizione);
        public string getId(string username,string password);//id utente
        public void addUtente(string username,string password);
    }
}
