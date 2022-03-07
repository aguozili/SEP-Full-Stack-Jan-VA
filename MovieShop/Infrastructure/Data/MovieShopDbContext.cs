using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {
        // inject the dbcontext options
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }



        //Create Dbset property inside the DbContext t
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    
    }
}
