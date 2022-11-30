using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePal.Models
{
    public class director
    {

        public int? DirectorId { get; set; }

        public string Firstname { get; set; } = null!;

        public string LastName { get; set; } = null!;

        // 1 director can have Many movies
        public List<Movie>? Movies { get; set; }
    }
}
