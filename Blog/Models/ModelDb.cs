namespace Blog.Models
{
    public class Dati
    {
        public string ID { get; set; }
        public string Titolo { get; set; }    
        public string Descrizione { get; set; }
        public override string ToString()
        {
            return Titolo + " - " + Descrizione;
        }
    }
    public interface ModelDb
    {
        public Dati? get(string key);
        public List<Dati>? get();
        public void set(string key, Dati d);
        public void add(List<Dati> d);
        public void setUp();
    }
}
