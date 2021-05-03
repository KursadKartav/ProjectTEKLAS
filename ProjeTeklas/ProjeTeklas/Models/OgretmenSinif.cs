using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeTeklas.Models
{
    public class OgretmenSinif
    {
        public int Id { get; set; }
        public int SinifId { get; set; }
        public virtual Sinif Sinif { get; set; }
        public int OgretmenId { get; set; }
        public virtual Ogretmen Ogretmen { get; set; }
    }
}
