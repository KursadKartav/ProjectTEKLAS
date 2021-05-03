using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeTeklas.Models
{
    public class Ogretmen
    {
        public int OgretmenId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public ICollection<OgretmenSinif> OgretmenSinifs { get; set; }
    }
}
