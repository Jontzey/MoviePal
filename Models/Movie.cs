using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePal.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; } = null!;

        public int? ranking { get; set; }

        public string? Genre { get; set; }

        public bool IsWatched { get; set; }

        public int DirectorId { get; set; }

        // Movie har 1 director
        public director Director { get; set; } = null!;

        public List<actor>? Actors { get; set; }
    }
}
