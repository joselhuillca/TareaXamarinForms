using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduticXamarin.Models
{
    class Noticia
    {
        public string title { get; set; }
        public string kwic { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        public string iurl { get; set; }
        public string domain { get; set; }
        public string author { get; set; }
        public bool news { get; set; }
        public string votes { get; set; }
        public int date { get; set; }
        public SubNoticia[] related;

    }
}
