using MovieSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Movie> Movies { get; set; }
    }
}
