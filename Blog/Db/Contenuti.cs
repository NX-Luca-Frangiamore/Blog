﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Db
{
    public class Contenuti
    {
        public string id { get; set; }
        public string titolo { get; set; }
        public string descrizione { get; set; }
        
        public string EF_idUtente { get; set; }
    }
}