using System.Collections.Generic;
using System.Text.Json;

namespace Blog.Models
{
    public class ModelJson : ModelDb
    {
        string url= "C:\\Users\\Luca Frangiamore\\Desktop\\Blog\\Blog\\Blog\\provajson.txt";

       
        public ModelJson()
        {
            Console.WriteLine("ciao");
        }
        public Dati? get(string key)
        {
            StreamReader stream = new StreamReader(url);
            string s = stream.ReadToEnd();
            List<Dati> ps = JsonSerializer.Deserialize<List<Dati>>(s);
            return ps.Where(x => x.ID == key).Select(x => x).ToList()[0];
        }
        public List<Dati>? get()
        {
            StreamReader stream = new StreamReader(url);
            string s = stream.ReadToEnd();
            List<Dati> ps = JsonSerializer.Deserialize<List<Dati>>(s);
            return ps;
        }
        public void set(string key, Dati d)
        {
            List<Dati> list=get();
            Dati ToChange=list.Where(x => x.ID == key).Select(x => x).ToList()[0];
            ToChange.Descrizione=d.Descrizione;
            ToChange.Titolo = d.Titolo;
            string f=JsonSerializer.Serialize(list);
            StreamWriter stream = new StreamWriter(url);
            stream.Write(f);
        }
        public void add(List<Dati> d)
        {
            
        }
        public void setUp()
        {
            List<Dati> list = new List<Dati>();
            string f = JsonSerializer.Serialize(list);
            StreamWriter stream = new StreamWriter(url);
            stream.Write(f);
        }
    }
}
