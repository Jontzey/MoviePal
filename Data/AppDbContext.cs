using Microsoft.EntityFrameworkCore;
using MoviePal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePal.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext ()
        {

        }

       public AppDbContext(DbContextOptions options) : base(options)
       {

       }

        // Creates tables
        public DbSet<Movie> Movies { get; set; }

        public DbSet<director> Directors { get; set; }

        public DbSet<actor> Actors { get; set; }

        // Sets all options
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //1 connect to what type of server
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MoviePalDb; Trusted_Connection=True;");
        }

    }
}
