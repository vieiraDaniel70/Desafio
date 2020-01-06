using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;

namespace DesafioMOBRJ.Models
{
    public class Estado
    {
        public class Small
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Large
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Full
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Thumbnails
        {
            public Small small { get; set; }
            public Large large { get; set; }
            public Full full { get; set; }
        }

        public class Attachment
        {
            public string id { get; set; }
            public string url { get; set; }
            public string filename { get; set; }
            public int size { get; set; }
            public string type { get; set; }
            public Thumbnails thumbnails { get; set; }
        }

        [Table("Campos")]

        public class Fields
        {
            [PrimaryKey]
            public string IdFields { get; set; }
            public string Sigla { get; set; }
            [Ignore]
            public List<Attachment> Attachments { get; set; }
            public string Estado { get; set; }
            public string Capital { get; set; }
            public string Regiao { get; set; }
        }

        [Table("Estados")]

        public class ClasseEstado
        {
            [PrimaryKey]
            public string id { get; set; }
            [Ignore]
            public Fields fields { get; set; }
            [Ignore]
            public DateTime createdTime { get; set; }

            //[JsonProperty("Regiao")]
            //public string ImageUrl { get; set; }
        }

        public List<ClasseEstado> records { get; set; }
    }
}
