using Microsoft.EntityFrameworkCore;
using ProjeTeklas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeTeklas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<Ogretmen> Ogretmens { get; set; }
        public DbSet<Sinif> Sinifs { get; set; }
        public DbSet<OgretmenSinif> OgretmenSinifs { get; set; }
    }
}
