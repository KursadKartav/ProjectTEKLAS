using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeTeklas.Models
{
    public class Sinif
    {
        public int SinifId { get; set; }
        public string SinifAdi { get; set; }
        public ICollection<Ogrenci> Ogrencis { get; set; }
        public ICollection<OgretmenSinif> OgretmenSinifs { get; set; }
    }
}
