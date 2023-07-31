using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Db
{
    public class Contenuti
    {
      
        public int id { get; set; }
        public string titolo { get; set; }
        public string descrizione { get; set; }
        
        public int EF_idUtente { get; set; }
       
    }
}
